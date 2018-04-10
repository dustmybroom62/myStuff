package edu.galileo.android.mytodolist.data;

import android.content.ContentProvider;
import android.content.ContentUris;
import android.content.ContentValues;
import android.content.UriMatcher;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import edu.galileo.android.mytodolist.data.TodoListContract.TodoEntry;

/**
 * Created by Larry on 3/28/2018.
 */

public class TodoListProvider extends ContentProvider {
    private static final int TODO = 100;
    private static final int TODO_ID = 101;

    // The URI Matcher used by this content provider.
    private static final UriMatcher sUriMatcher = buildUriMatcher();
    private TodoListDBHelper mOpenHelper;

    private static UriMatcher buildUriMatcher() {
        // All paths added to  the UriMatcher have a corresponding code to return when a match is
        // found. The code passed into the constructor represents the code to return for the root
        // URI. It's common to use NO_MATCH as the code for this case.
        final UriMatcher matcher = new UriMatcher(UriMatcher.NO_MATCH);
        final String authority = TodoListContract.CONTENT_AUTHORITY;

        // for each type of URI you want to add, create a corresponding code.

        matcher.addURI(authority, TodoListContract.PATH_TODO, TODO);
        matcher.addURI(authority, TodoListContract.PATH_TODO + "/#", TODO_ID);

        return matcher;
    }

    @Override
    public boolean onCreate() {
        mOpenHelper = new TodoListDBHelper(getContext());
        return false;
    }

    @Nullable
    @Override
    public Cursor query(@NonNull Uri uri, @Nullable String[] projection, @Nullable String selection, @Nullable String[] selectionArgs
            , @Nullable String sortOrder) {
        // switch to determine request type by URI
        Cursor retCursor;
        switch (sUriMatcher.match(uri)) {
            case TODO:
                retCursor = mOpenHelper.getReadableDatabase().query(
                        TodoEntry.TABLE_NAME
                        , projection
                        , selection
                        , selectionArgs
                        , null
                        , null
                        , sortOrder
                );
                break;
            case TODO_ID:
                retCursor = mOpenHelper.getReadableDatabase().query(
                        TodoEntry.TABLE_NAME
                        , projection
                        , TodoEntry._ID + " = '" + ContentUris.parseId(uri) + "'"
                        , null
                        , null
                        , null
                        , sortOrder
                );
                break;
            default:
                throw new UnsupportedOperationException("Unknown uri: " + uri);
        }
        retCursor.setNotificationUri(getContext().getContentResolver(), uri);
        return retCursor;
    }

    @Nullable
    @Override
    public String getType(@NonNull Uri uri) {
        return null;
    }

    @Nullable
    @Override
    public Uri insert(@NonNull Uri uri, @Nullable ContentValues contentValues) {
        final SQLiteDatabase db = mOpenHelper.getWritableDatabase();
        final int match = sUriMatcher.match(uri);
        Uri returnUri;

        switch (match) {
            case TODO:
                long _id = db.insert(TodoEntry.TABLE_NAME, null, contentValues);
                if (_id > 0) {
                    returnUri = TodoEntry.CONTENT_URI;
                } else {
                    throw new SQLException("failed to insert row into " + uri);
                }
                break;
            default:
                throw new UnsupportedOperationException("Unknown uri: " + uri);
        }
        getContext().getContentResolver().notifyChange(uri, null);
        return returnUri;
    }

    @Override
    public int delete(@NonNull Uri uri, @Nullable String selection, @Nullable String[] selectionArgs) {
        final SQLiteDatabase db = mOpenHelper.getWritableDatabase();
        final int match = sUriMatcher.match(uri);
        int rowsDeleted;

        switch (match) {
            case TODO:
                rowsDeleted = db.delete(
                        TodoEntry.TABLE_NAME
                        , selection
                        , selectionArgs
                );
                break;
            default:
                throw new UnsupportedOperationException("Unknown uri: " + uri);
        }
        if (null == selection || 0 != rowsDeleted) {
            getContext().getContentResolver().notifyChange(uri, null);
        }

        return rowsDeleted;
    }

    @Override
    public int update(@NonNull Uri uri, @Nullable ContentValues values, @Nullable String selection, @Nullable String[] selectionArgs) {
        final SQLiteDatabase db = mOpenHelper.getWritableDatabase();
        final int match = sUriMatcher.match(uri);
        int rowsUpdated;

        switch (match) {
            case TODO:
                rowsUpdated = db.update(
                        TodoEntry.TABLE_NAME
                        , values
                        , selection
                        , selectionArgs
                );
                break;
            default:
                throw new UnsupportedOperationException("Unknown uri: " + uri);
        }
        if (null == selection || 0 != rowsUpdated) {
            getContext().getContentResolver().notifyChange(uri, null);
        }

        return rowsUpdated;
    }

    @Override
    public int bulkInsert(@NonNull Uri uri, @NonNull ContentValues[] values) {
        final SQLiteDatabase db = mOpenHelper.getWritableDatabase();
        final int match = sUriMatcher.match(uri);
        switch (match) {
            case TODO:
                db.beginTransaction();
                int returnCount = 0;
                try {
                    for (ContentValues value : values) {
                        long _id = db.insert(TodoEntry.TABLE_NAME, null, value);
                        if (-1 != _id) {
                            returnCount++;
                        }
                    }
                    db.setTransactionSuccessful();
                } finally {
                    db.endTransaction();
                }
                getContext().getContentResolver().notifyChange(uri, null);
                return returnCount;
            default:
                return super.bulkInsert(uri, values);
        }
    }
}
