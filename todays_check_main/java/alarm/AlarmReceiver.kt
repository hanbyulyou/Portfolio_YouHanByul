package alarm

import android.content.BroadcastReceiver
import android.content.Context
import android.content.Intent
import android.util.Log
import database.VitaminDatabaseHelper

class AlarmReceiver : BroadcastReceiver() {
    override fun onReceive(context: Context, intent: Intent?) {
        val dbHelper = VitaminDatabaseHelper(context)
        dbHelper.resetAllVitamins()
    }
}