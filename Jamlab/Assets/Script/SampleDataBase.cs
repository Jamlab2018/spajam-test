using System.Collections.Generic;
using UnityEngine;

public class SampleDataBase : MonoBehaviour {

    public const string DB = "JDB";       // DB名
    public const string tableName= "jtable";  // テーブル名
    public SqliteDatabase sqlDB;
    
    public string jsonSelect(int id)
    {
        string where = " WHERE id = " + id;
        string query = "SELECT * FROM " + tableName + where +";";

        var dt = sqlDB.ExecuteQuery(query);
        
        return (string)dt.Rows[0]["json"];
    }
    
    public void jsonUpdate(int id,string json)
    {
        sqlDB = new SqliteDatabase(DB + "db");
        string query = "UPDATE " + tableName + " SET json = '" + json + "' WHERE id = " + id + ";";
        sqlDB.ExecuteNonQuery(query);
    }

    public void jsonInsert(int id, string json)
    {
        sqlDB = new SqliteDatabase(DB + "db");
        string query = "INSERT INTO VALUES("+id + "'"+ tableName + "');";
        sqlDB.ExecuteNonQuery(query);
    }
}
