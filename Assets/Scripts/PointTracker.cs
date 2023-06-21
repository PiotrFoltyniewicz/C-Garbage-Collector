using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PointTracker : MonoBehaviour
{
    TextMeshProUGUI pointsText;
    TextMeshProUGUI timeText;
    int currentPoints = 0;
    float currentTime;
    GameDifficulty gameDifficulty;
    void Awake()
    {
        pointsText = GameObject.Find("Canvas/PointsText").GetComponent<TextMeshProUGUI>();
        timeText = GameObject.Find("Canvas/TimeText").GetComponent<TextMeshProUGUI>();
        gameDifficulty = GameObject.Find("GameManager").GetComponent<GameDifficulty>();
        pointsText.text = "Points: ";
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        timeText.text = "Time survived:\n" + Math.Round(currentTime, 2).ToString();
    }

    public void SetPoints(int points)
    {
        currentPoints += (int)(points * gameDifficulty.GetPointsMultiplier());
        pointsText.text = "Points:\n" + currentPoints.ToString();
    }

    public void SaveGamePoints()
    {
        GameData.points = currentPoints;
    }
}
