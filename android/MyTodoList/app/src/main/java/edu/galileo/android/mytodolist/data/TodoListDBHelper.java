package edu.galileo.android.mytodolist.data;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import edu.galileo.android.mytodolist.data.TodoListContract.TodoEntry;

/**
 * Created by Larry on 3/28/2018.
 */

public class TodoListDBHelper extends SQLiteOpenHelper {
    // if you change the db schema, you must increment the db version
    private static final int DB_VERSION = 1;

    public static final String DB_NAME = "todolist.db";

    public TodoListDBHelper(Context context) {
        super(context, DB_NAME, null, DB_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        final String SQL_CREATE_TODO_TABLE = "CREATE TABLE " + TodoEntry.TABLE_NAME + " ("
                + TodoEntry._ID + " INTEGER PRIMARY KEY, "
                + TodoEntry.COLUMN_DATE + "TEXT NOT NULL, "
                + TodoEntry.COLUMN_DONE + "INTEGER, "
                + "UNIQUE (" + TodoEntry.COLUMN_DATE + ", " + TodoEntry.COLUMN_DESCRIPTION + ") ON "
                + "CONFLICT IGNORE "
                + ")'";

        sqLiteDatabase.execSQL(SQL_CREATE_TODO_TABLE);
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        sqLiteDatabase.execSQL("DROP TABLE IF EXISTS " + TodoEntry.TABLE_NAME);
        onCreate(sqLiteDatabase);
    }
}
