package com.example.vitacheck

import android.os.Bundle
import android.widget.ImageButton
import androidx.appcompat.app.AppCompatActivity
import com.example.vitacheck.databinding.ActivityAddVitaminBinding
import com.example.vitacheck.databinding.ActivityMainBinding
import com.google.android.material.chip.Chip
import database.VitaminDatabaseHelper

class AddVitaminActivity : AppCompatActivity() {

    private lateinit var binding: ActivityAddVitaminBinding
    private lateinit var dbHelper: VitaminDatabaseHelper

    override fun onCreate(savedInstanceState: Bundle?){
        super.onCreate(savedInstanceState)
        binding = ActivityAddVitaminBinding.inflate(layoutInflater)
        setContentView(binding.root)

        dbHelper = VitaminDatabaseHelper(this)

        // 保存ボタンがクリックされたイベント
        binding.saveButton.setOnClickListener{
            val vitaminName = binding.vitaminNameEditText.text.toString()

            // チップグループから選択された曜日を取得
            val selectedDays = binding.daysChipGroup.checkedChipIds
                .map { chipId -> findViewById<Chip>(chipId).text.toString() }
                .joinToString(",") // 曜日をカンマ区切りで連結

            // 選択された曜日がなければ、デフォルト値「毎日」を設定
            val daysToSave = if(selectedDays.isNotEmpty()) selectedDays else "毎日"

            if (vitaminName.isNotEmpty()) {
                dbHelper.addVitamin(vitaminName, selectedDays)
                finish() // アクティビティを終了し、メイン画面に戻る
            }
        }

        // キャンセルボタンがクリックされたイベント
        binding.cancelButton.setOnClickListener {
            finish() // そのまま終了
        }

        // 戻るボタン
        binding.backButton.setOnClickListener {
            onBackPressed()
        }

    }
}
