using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Table : MonoBehaviour
{
    // Reference to inputOutput component to get player prefs.
    [SerializeField] InputOutput inputOutput;
    // Prefab of line in table.
    [SerializeField] GameObject prefabLine;
    // Offset on yAxis of begin of table's line
    [Range(-200,200)]
    [SerializeField] float yAxis = 0f;
    // Space through every line
    [Range(-200,200)]
    [SerializeField] float stepOfLines = -40f;
    // Reference to Content's transform component.
    RectTransform contentTransform;
    private void Start()
    {
        contentTransform = GetComponent<ScrollRect>().content;
        // Make vector that respond for position of every line.
        Vector2 pos = new Vector2(0,yAxis);
        // Get table
        var table = inputOutput.GetTable();
        foreach (var dataLine in table)
        {
            // Instantiate from prefab every line
            var curLine = Instantiate(prefabLine, pos, Quaternion.identity, contentTransform) as GameObject;
            // Got text component and after field them
            var col = curLine.GetComponentsInChildren<TextMeshProUGUI>();
            col[0].SetText(dataLine.name);
            col[1].SetText(dataLine.score.ToString());
            col[2].SetText(dataLine.levelName);
            // Make space
            pos.y = pos.y + stepOfLines;
        }
    }

}
