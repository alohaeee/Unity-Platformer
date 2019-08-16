using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


// Table data class. Include player's name, score and last level played.
public class TableData
{
    public string name;
    public int score;
    public string levelName;

    public TableData()
    {}
    public TableData(string name, int score, string levelName)
    {
        this.name = name;
        this.score = score;
        this.levelName = levelName;
    }
}

public class InputOutput : MonoBehaviour
{
    // Size of Table. How much PlayerPrefs will be save.
    public const int sizeOfTable = 5;

    // Get list of table data with size depending on sizeOfTable variable
    public List<TableData> GetTable()
    {
        List<TableData> table = new List<TableData>();

        for (int i = 1; i <= sizeOfTable; i++)
        {
            if (PlayerPrefs.HasKey("Player Name: " + i))
            {
                TableData tableData = new TableData();
                tableData.name = PlayerPrefs.GetString("Player Name: " + i); ;
                tableData.score = PlayerPrefs.GetInt("Player Score: " + i); ;
                tableData.levelName = PlayerPrefs.GetString("Level Name: " + i);
                table.Add(tableData);
            }
            else break;
        }
        return table;
    }

    // Save player info for score table using linked list and playerPrefs.
    public void SavePlayer(string playerName, int score, string levelName)
    {
        LinkedList<TableData> table = new LinkedList<TableData>();
        TableData curResults = new TableData(playerName, score, levelName);
        bool isInserted = false;

        for (int i = 1; i <= sizeOfTable; i++)
        {
            if (PlayerPrefs.HasKey("Player Name: " + i))
            {
                TableData tableData = new TableData();
                tableData.name = PlayerPrefs.GetString("Player Name: " + i); ;
                tableData.score = PlayerPrefs.GetInt("Player Score: " + i); ;
                tableData.levelName = PlayerPrefs.GetString("Level Name: " + i);
                table.AddLast(tableData);
                // if we haven't inputed yet will check for good position for our current result
                if (!isInserted && table.Last.Value.score <= curResults.score)
                {
                    table.AddBefore(table.Last, curResults);
                    isInserted = true;
                }
            }
            else break;
        }
        // if good position was't found just add last
        if (!isInserted) table.AddLast(curResults);
        // we need to update player prefs only if we insert result in good position or 
        // if after "add last" count of our table less then const size.
        if (isInserted || table.Count <= sizeOfTable)
        {
            int count = 1;
            foreach (var line in table)
            {
                if (count > sizeOfTable) break;
                PlayerPrefs.SetString("Player Name: " + count, line.name);
                PlayerPrefs.SetInt("Player Score: " + count, line.score);
                PlayerPrefs.SetString("Level Name: " + count, line.levelName);
                count++;
            }
        }
    }

    public void SaveData(string playerName, int beginLevelScore)
    {
        PlayerPrefs.SetString("Transfer Name", playerName);
        PlayerPrefs.SetInt("Transfer Score", beginLevelScore);
    }
    public void SaveData(string playerName)
    {
        PlayerPrefs.SetString("Transfer Name", playerName);
    }
    public void SaveData(int beginLevelScore)
    {
        PlayerPrefs.SetInt("Transfer Score", beginLevelScore);
    }
    public void GetData(ref string playerName, ref int beginLevelScore)
    {
        if (PlayerPrefs.HasKey("Transfer Name")) playerName = PlayerPrefs.GetString("Transfer Name");
        if (PlayerPrefs.HasKey("Transfer Score")) beginLevelScore = PlayerPrefs.GetInt("Transfer Score");
    }
}
