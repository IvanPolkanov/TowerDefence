using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new enemy spawn controller info",menuName ="Config/Enemy SpawnController Info",order =5)]
public class EnemySpawnControllerInfo : ScriptableObject,ISpawnCountFormula
{
    [SerializeField] float timeBetweenSpawn;


    public float spawnTime
    {
        get { return timeBetweenSpawn; }
    }

    public int CalculateSpawnCount(int level)
    {
        return level + (level+1) * 3;
    }
}
