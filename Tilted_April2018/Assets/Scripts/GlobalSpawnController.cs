using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GlobalSpawnController
{
    public static bool CanAdd
    {
        get
        {
            return enemies.Count == maxEnemies ? false : true;
        }
    }

    public static int maxEnemies = 100;

    static List<GameObject> enemies = new List<GameObject>();

    public static void AddEnemy(GameObject enemy)
    {
        if (CanAdd) enemies.Add(enemy);
    }
}