using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    public static GameDifficulty instance;
    float itemSpawnTime = 3f;
    (float, float) itemGravityScale = (0.2f, 0.5f);
    int itemRandomizer = 30;
    float timeToRaiseDifficulty = 15f;
    float pointsMultiplier = 1.0f;
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        timeToRaiseDifficulty -= Time.deltaTime;
        if(timeToRaiseDifficulty < 0)
        {
            timeToRaiseDifficulty = 15f;
            RaiseDifficulty();
        }
    }

    public float GetItemSpawnTime()
    {
        return itemSpawnTime;
    }

    public (float, float) GetItemGravityScaleRange()
    {
        return itemGravityScale;
    }

    public int GetItemRandomizer()
    {
        return itemRandomizer;
    }

    public float GetPointsMultiplier()
    {
        return pointsMultiplier;
    }
    void RaiseDifficulty()
    {
        if(itemSpawnTime > 0.75f) itemSpawnTime -= 0.2f;
        itemGravityScale.Item1 += 0.05f;
        itemGravityScale.Item1 += 0.05f;
        if(itemRandomizer <= 95) itemRandomizer += 5;
        pointsMultiplier *= 1.2f;
    }
}
