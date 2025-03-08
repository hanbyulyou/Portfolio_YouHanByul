package com.example.vitacheck

import adapter.VitaminAdapter
import alarm.AlarmReceiver
import android.app.AlarmManager
import android.app.PendingIntent
import android.content.Context
import android.content.Intent
import android.content.SharedPreferences
import android.os.Bundle
import android.util.Log
import android.view.inputmethod.InputMethodManager
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.widget.SearchView
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.vitacheck.databinding.ActivityMainBinding
import database.VitaminDatabaseHelper
import java.text.SimpleDateFormat
import java.util.Calendar
import java.util.Date
import java.util.Locale

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding
    private lateinit var dbHelper: VitaminDatabaseHelper
    private lateinit var adapter: VitaminAdapter
    private lateinit var sharedPreferences: SharedPreferences

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        // データベースの初期化
        dbHelper = VitaminDatabaseHelper(this)

        // SharedPreferencesの初期化
        sharedPreferences = getSharedPreferences("vitamin_prefabs", MODE_PRIVATE)

        // 日付チェック
        checkAndResetVitaminState()

        // RecyclerViewの設定
        binding.recyclerView.layoutManager = LinearLayoutManager(this)

        // アダプタをここで初期化し、設定する前にセット
        adapter = VitaminAdapter(dbHelper.getAllVitamins()) { vitamin ->
            dbHelper.updateVitaminChecked(vitamin.id, !vitamin.isChecked)
            refreshData()
        }
        binding.recyclerView.adapter = adapter

        // 追加ボタンがクリックされたとき
        binding.fab.setOnClickListener {
            val intent = Intent(this, AddVitaminActivity::class.java)
            startActivity(intent)
        }

        // 初期化ボタンがクリックされたとき
        binding.resetFab.setOnClickListener {
            resetVitamins()
        }

        // 毎日のリセットをスケジュール
        scheduleDailyReset()
    }

    private fun filterVitamins(query: String?) {
        val filteredVitamins = dbHelper.getAllVitamins().filter { vitamin ->
            vitamin.name.contains(query ?:"", ignoreCase = true) || vitamin.days.contains(query ?: "", ignoreCase = true)
        }
        adapter.updateData(filteredVitamins)
    }

    private fun checkAndResetVitaminState(){
        val currentDate = SimpleDateFormat("yyyy-MM-dd", Locale.getDefault()).format(Date())
        val lastDate = sharedPreferences.getString("last_reset_date", "")

        if (currentDate != lastDate) {
            // 日付が異なればリセットし、新しい日付を保存
            resetVitamins()
            sharedPreferences.edit().putString("last_reset_date", currentDate).apply()
        }

    }

    private fun resetVitamins() {
        dbHelper.deleteAllVitamins() // データベースのリセット

        if (::adapter.isInitialized) {
            adapter.updateData(emptyList()) // アダプタに空のリストを渡す
        } else {
            Log.e("MainActivity", "アダプタが初期化されていません")
        }

        // RecyclerViewを更新
        binding.recyclerView.post {
            refreshData()
        }
    }

    override fun onResume() {
        super.onResume()
        refreshData()
    }

    private fun refreshData() {
        if (::adapter.isInitialized) { // アダプタが初期化されているかチェック
            val vitamins = dbHelper.getAllVitamins()
            adapter.updateData(vitamins)
        } else {
            Log.e("MainActivity", "アダプタが初期化されていません")
        }
    }

    private fun scheduleDailyReset(){
        val calendar = Calendar.getInstance().apply {
            set(Calendar.HOUR_OF_DAY, 0)
            set(Calendar.MINUTE, 0)
            set(Calendar.SECOND, 0)
            set(Calendar.MILLISECOND, 0)
        }

        val alarmManager = getSystemService(Context.ALARM_SERVICE) as AlarmManager
        val intent = Intent(this, AlarmReceiver::class.java)
        val pendingIntent = PendingIntent.getBroadcast(this, 0, intent, PendingIntent.FLAG_IMMUTABLE)

        // 毎日午前0時にリセットするアラームを設定
        alarmManager.setInexactRepeating(
            AlarmManager.RTC_WAKEUP,
            calendar.timeInMillis,
            AlarmManager.INTERVAL_DAY,
            pendingIntent
        )

    }
}
