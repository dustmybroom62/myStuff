package edu.galileo.android.mytodolist.data;

import android.net.Uri;
import android.provider.BaseColumns;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by Larry on 3/28/2018.
 */

public class TodoListContract {
    public static final String CONTENT_AUTHORITY = "edu.galileo.android.mytodolist";
    public static final Uri BASE_CONTENT_URI = Uri.parse("content://" + CONTENT_AUTHORITY);

    public static final String PATH_TODO = "todo";
    public static final String DATE_FORMAT = "yyyyMMdd";

    public static final String QUERY_EQUAL              = "=?";

    public static String getDbDateString(Date date) {
        // Because the API returns a unix timestamp (measured in seconds),
        // it must be converted to milliseconds in order to be converted to valid date.
        SimpleDateFormat sdf = new SimpleDateFormat(DATE_FORMAT);
        return sdf.format(date);
    }

    /**
     * Converts a dateText to a long Unix time representation
     *
     * @param dateText the input date string
     * @return the Date object
     */
    public static Date getDateFromDb(String dateText) {
        SimpleDateFormat dbDateFormat = new SimpleDateFormat(DATE_FORMAT);
        try {
            return dbDateFormat.parse(dateText);
        }catch (ParseException e) {
            e.printStackTrace();
            return null;
        }
    }

    public static final class TodoEntry implements BaseColumns {
        public static final String TABLE_NAME = "todo";
        public static final String COLUMN_DESCRIPTION = "descp";
        public static final String WHERE_TODO_ID                   = _ID + QUERY_EQUAL;
        public static final String COLUMN_DATE = "date";
        public static final String COLUMN_DONE = "done";

        public static final Uri CONTENT_URI = BASE_CONTENT_URI.buildUpon().appendPath(PATH_TODO).build();
        public static final String CONTENT_TYPE = "vnd.android.cursor.dir/" + CONTENT_AUTHORITY + "/" + PATH_TODO;
        public static final String CONTENT_ITEM_TYPE = "vnd.android.cursor.item/" + CONTENT_AUTHORITY + "/" + PATH_TODO;

    }
}
