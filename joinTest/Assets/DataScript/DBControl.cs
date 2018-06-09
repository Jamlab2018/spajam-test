using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBControll : MonoBehaviour {

    public const string DB = "JSONDB.db";       // DB名
    public static SqliteDatabase sqlDB = new SqliteDatabase(DB);

    public static DataTable select(string query)
    {
        DataTable dt = sqlDB.ExecuteQuery(query);
        
        return dt;
    }
    
    public static int execute(string query)
    {
        try
        {
            sqlDB.ExecuteNonQuery(query);
            Debug.Log("complete : " + query);
            return 1;
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            return 0;
        }
    }
}
