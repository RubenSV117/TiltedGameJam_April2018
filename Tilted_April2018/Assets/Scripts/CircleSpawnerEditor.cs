using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CircleSpawner))]
public class CircleSpawnerEditor : Editor
{
    public void OnSceneGUI()
    {
        CircleSpawner spawner = target as CircleSpawner;
        Handles.color = Color.red;
        Handles.DrawWireDisc(spawner.transform.position, spawner.transform.up, spawner.circleRadius);
    }
}
