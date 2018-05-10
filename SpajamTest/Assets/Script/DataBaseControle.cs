using System.Collections.Generic;
using UnityEngine;

public class DataBaseControle : MonoBehaviour {

    public const  string DB = "JSONDB.db";       // DB名
    public const  string tableName= "jtable";  // テーブル名
    public static SqliteDatabase sqlDB = new SqliteDatabase(DB);
    

    public static string jsonSelect(int id)
    {
        string where = " WHERE id = " + id;
        string query = "SELECT * FROM " + tableName + where +";";

        var dt = sqlDB.ExecuteQuery(query);
        return (string)dt.Rows[0]["json"];
    }
    
    public static void jsonUpdate(int id,string json)
    {
        string query = "UPDATE " + tableName + " SET json = '" + json + "' WHERE id = " + id + ";";
        sqlDB.ExecuteNonQuery(query);
    }

    public static void jsonInsert(int id, string json)
    {
        string query = "INSERT INTO " + tableName + " VALUES("+id + ",'"+ json + "');";
        Debug.Log(query);
        sqlDB.ExecuteNonQuery(query);
    }
}
