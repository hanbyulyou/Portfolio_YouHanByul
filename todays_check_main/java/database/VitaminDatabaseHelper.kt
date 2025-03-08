package database

import android.content.ContentValues
import android.content.Context
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper

data class Vitamin(val id: Int, val name: String, val isChecked: Boolean, val days: String, val isDeleted: Boolean, val deletedAt: String?)

class VitaminDatabaseHelper(context: Context) :
    SQLiteOpenHelper(context, "Vitamins.db", null, 3)    {

    override fun onCreate(db: SQLiteDatabase) {
        val createTableQuery = """
            CREATE TABLE Vitamins (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT NOT NULL,
                isChecked INTEGER DEFAULT 0,
                days TEXT,
                isDeleted INTEGER DEFAULT 0,
                deletedAt TEXT
            )
        """
        db.execSQL(createTableQuery)
    }

    override fun onUpgrade(db: SQLiteDatabase, oldVersion: Int, newVersion: Int) {
        if (oldVersion < 3) {
            if (!columnExists(db, "Vitamins", "days")) {
                db.execSQL("ALTER TABLE Vitamins ADD COLUMN days TEXT")
            }
            if (!columnExists(db, "Vitamins", "deletedAt")) {
                db.execSQL("ALTER TABLE Vitamins ADD COLUMN deletedAt TEXT")
            }
        }
    }

    // 特定のカラムが存在するか確認する関数
    private fun columnExists(db: SQLiteDatabase, tableName: String, columnName: String): Boolean {
        val cursor = db.rawQuery("PRAGMA table_info($tableName)", null)
        val columnIndex = cursor.getColumnIndex("name")

        var exists = false
        while (cursor.moveToNext()) {
            if (cursor.getString(columnIndex) == columnName) {
                exists = true
                break
            }
        }
        cursor.close()
        return exists
    }

    fun getAllVitamins(): List<Vitamin> {
        val db = readableDatabase
        val cursor = db.rawQuery("SELECT * FROM Vitamins", null)
        val vitamins = mutableListOf<Vitamin>()

        try {
            while (cursor.moveToNext()){
                val id = cursor.getInt(cursor.getColumnIndexOrThrow("id"))
                val name = cursor.getString(cursor.getColumnIndexOrThrow("name"))
                val isChecked = cursor.getInt(cursor.getColumnIndexOrThrow("isChecked")) == 1
                val days = cursor.getString(cursor.getColumnIndexOrThrow("days")) ?:""
                val isDeleted = cursor.getInt(cursor.getColumnIndexOrThrow("isDeleted")) == 1
                val deletedAt = cursor.getString(cursor.getColumnIndexOrThrow("deletedAt"))
                vitamins.add(Vitamin(id, name, isChecked, days, isDeleted, deletedAt))
            }
        } finally {
            cursor.close() // カーソルは常に閉じる
        }
        return vitamins
    }

    fun addVitamin(name: String, days: String) {
        val db = writableDatabase
        val values = ContentValues().apply {
            put("name",name)
            put("days",days)
            put("isChecked",0)
            put("isDeleted",0)
            put("deletedAt", "")
        }
        db.insert("Vitamins",null,values)
        db.close()
    }

    fun updateVitaminChecked(id: Int, isChecked: Boolean) {
        val db = writableDatabase
        val values = ContentValues().apply {
            put("isChecked", if (isChecked) 1 else 0)
        }
        db.update("Vitamins", values, "id = ?", arrayOf(id.toString()))
    }

    fun deleteVitamin(id: Int) {
        val db = writableDatabase
        db.delete("Vitamins", "id=?", arrayOf(id.toString()))
        db.close()
    }

    fun permanentlyDeleteOldVitamins() {
        val db = writableDatabase
        db.delete("Vitamins", "isDeleted = ?", arrayOf("1"))
        db.close()
    }

    fun deleteAllVitamins(){
        val db = writableDatabase
        db.delete("Vitamins",null,null)
        db.close()
    }

    fun resetAllVitamins() {
        val db = writableDatabase
        val values = ContentValues().apply {
            put("isChecked",0) // すべてのチェックボックスを未チェックにリセット
        }
        db.update("Vitamins", values, null, null)
    }

    // 現在の日付を "yyyy-MM-dd HH:mm:ss" 形式で返す
    private fun getCurrentDate(): String {
        return "" // TODO: 日付のロジックを実装
    }

    // n日以前の日付を "yyyy-MM-dd HH:mm:ss" 形式で返す
    private fun getCurrentDateMinusDays(days: Int): String {
        return "" // TODO: 日付のロジックを実装
    }

}
