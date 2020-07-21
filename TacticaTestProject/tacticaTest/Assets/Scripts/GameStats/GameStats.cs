using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameStats 
{

    static GameStats()
    {
       mainConfig= (GameSettingsConfig)(Resources.Load("Config/Main") as ScriptableObject);
    }

    public static Action<float> onGoldChange;
    public static Action<int> onLifeCountChange;
    public static Action<int> onLifeEnd;
    public static Action onEnemiesEnd;

    public static GameSettingsConfig mainConfig;

    private static int lifeCount;
    private static float goldAmount;
    private static int enemiesKilled;
    public static int level=0;


    public static void Reset()
    {
        lifeCount = mainConfig.startLifeCount;
        goldAmount = mainConfig.startGoldAmount;
        level = 0;
        enemiesKilled = 0;
        onLifeCountChange?.Invoke(lifeCount);
        onGoldChange?.Invoke(goldAmount);
    }

    public static bool TryGetGold(float cost)
    {
        if (goldAmount - cost >= 0)
        {
            goldAmount -= cost;
            onGoldChange?.Invoke(goldAmount);
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void UpdateLifeCount(int newLifeCount)
    {
        lifeCount = newLifeCount;
        onLifeCountChange?.Invoke(newLifeCount);
    }

    public static void UpdateGoldCount(float newGoldAmount)
    {
        goldAmount = newGoldAmount;
        onGoldChange?.Invoke(goldAmount);
    }

    public static void EnemyDie(float goldPerKill)
    {
        goldAmount += goldPerKill;
        enemiesKilled++;
        onGoldChange?.Invoke(goldAmount);
    }

    public static void EnemyDieByEndZone(int damage)
    {
        lifeCount -= damage;
        if (lifeCount == 0)
            onLifeEnd?.Invoke(enemiesKilled);
        else
        onLifeCountChange?.Invoke(lifeCount);
    }

}
