using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemySpawnController))]
[CanEditMultipleObjects]
public class EnemySpawnControllerEditor : Editor
{
    private EnemySpawnController enemySpawnController;

    private SerializedProperty enemySpawnInfoProperty;
    private SerializedProperty enemySpawnControllerInfo;
    private SerializedProperty wayPointControllers;

    private void OnEnable()
    {
        enemySpawnController = (EnemySpawnController)target;

        enemySpawnInfoProperty=serializedObject.FindProperty("enemySpawnInfo");
        enemySpawnControllerInfo= serializedObject.FindProperty("enemySpawnControllerInfo");
        wayPointControllers = serializedObject.FindProperty("wayPointControllers");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(enemySpawnInfoProperty);

        GUILayout.Label("Enemy start xp: " + enemySpawnController.enemySpawnInfo.startXp);
        GUILayout.Label("Enemy max xp: "+enemySpawnController.enemySpawnInfo.maxXp);
        GUILayout.Label("Enemt speed: "+enemySpawnController.enemySpawnInfo.moveSpeed);

        GUILayout.Space(20);

        EditorGUILayout.PropertyField(enemySpawnControllerInfo);
        GUILayout.Label("Enemy time between spawn: "+enemySpawnController.enemySpawnControllerInfo.spawnTime);

        GUILayout.Space(20);
        EditorGUILayout.PropertyField(wayPointControllers);
        
        serializedObject.ApplyModifiedProperties();
    }

}
