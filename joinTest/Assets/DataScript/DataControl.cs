using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

/// <summary>
/// データ保存及び取得
/// </summary>
public class DataControl : MonoBehaviour {

    // テーブル名
    const string tablename = "jtable";
	
	//------------------------------------------
	/// <summary>
	/// Json分解
	/// </summary>
	/// <returns>The decode.</returns>
	/// <param name="json">Json.</param>
	//------------------------------------------
	public static JsonNode jsonDecode(string json) {
		JsonNode node = JsonNode.Parse(json);
		return node;
	}

	//------------------------------------------
	/// <summary>
	/// json型の値を保存
	/// </summary>
	/// <param name="id">ユニークID</param>
	/// <param name="json">Json.</param>
	//------------------------------------------
	public static int dataInsert(string json, string filepath="") {

        JsonNode jn = jsonDecode(json);

		string query = "INSERT INTO " + tablename;

		/*
		query +=
			" VALUES(NULL," +
			"'" + jn["result"]["name"].Get<string>() + "'," +
			"'" + jn["result"]["formatted_address"].Get<string>() + "'," +
			"'" + jn["result"]["formatted_phone_number"].Get<string>() + "'," +
			"''," +
			jn["result"]["rating"].Get<double>() + "," +
			"0" +"," +
			"''," +
			"'" + filepath + "'," +
			"''," +
			"''," +
			"''," +
			"''," +
			"''," +
			"'" + jn["result"]["place_id"].Get<string>() + "'," +
			")";
		*/
		query += " VALUES(NULL," +
			"'" + jn["result"]["name"].Get<string>() + "'," +
			"'" + jn["result"]["formatted_address"].Get<string>() + "'," +
			"'" + jn["result"]["formatted_phone_number"].Get<string>() + "'," +
			"''," +
			jn["result"]["rating"].Get<double>() + "," +
			"0," +
			"''," +
			"'" + filepath + "'," +
			"''," +
			"''," +
			"''," +
			"''," +
			"''," +
			"'" + jn["result"]["place_id"].Get<string>() + "'" +
			")";
		Debug.Log (query);
        // データ追加
		int result = DBControll.execute(query);

		return result;
	}

    
    /// <summary>
    /// データを複数件取得
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
	public static DataTable getData(string where = ""){
        DataTable dt = new DataTable();
        string query = "";
        if (where.Equals(""))
        {
            query = "SELECT * FROM " + tablename + ";";
        } else
        {
            query = "SELECT * FROM " + tablename + " WHERE " + where + ";";
        }

        // データを取得
        dt = DBControll.select(query);

        Debug.Log(query);

		return dt;
	}

    /// <summary>
    /// データを1件取得
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    public static DataRow getOneData(string where)
    {
        DataTable dt = new DataTable();

        string query = "SELECT * FROM " + tablename + " WHERE "+ where +";";

        // データを取得
        dt = DBControll.select(query);

        if (dt == null)
        {
            return null;
        }
        else
        {
            return dt[0];
        }
    }

	/// <summary>
	/// 最新のIdを1件取得
	/// </summary>
	/// <param name="where"></param>
	/// <returns></returns>
	public static int getMaxId()
	{
		DataTable dt = new DataTable();

		string query = "SELECT max(id) AS id FROM " + tablename + ";";

		// データを取得
		dt = DBControll.select(query);

		if (dt == null)
		{
			return 0;
		}
		else
		{
			return (int)dt.Rows[0]["id"];
		}
	}
}
