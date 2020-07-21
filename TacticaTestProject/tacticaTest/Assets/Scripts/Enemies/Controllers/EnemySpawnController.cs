using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class EnemySpawnController : MonoBehaviour
{
    public EnemySpawnInfo enemySpawnInfo;
    public EnemySpawnControllerInfo enemySpawnControllerInfo;
    public List<WayPointController> wayPointControllers;

    private Transform spawnPoint;

    private float currentSpawnTime = 0;
    private float spawnsLeft = 0;
    private bool isStartSpawningFlag=false;

    private Transform enemiesRoot;
    private SpawnPool spawnPool;
    private EnemyWayPointManager enemyWayPointManager;

    private Action onNewGameClear;

    #region MonoBegaviour CallBacks
    private void Start()
    {
        SetCurrentSpawnTime(enemySpawnControllerInfo.spawnTime);
        CreateEnemiesPool();
        CreateEnemyWayPointManager();
        SubscribeOnEvents();
    }

    private void Update()
    {
        UpdateSpawnTime();
    }

    #endregion


    private void SubscribeOnEvents()
    {
        NewGameState.onNewGameStart += Reset;
    }

    private void Reset()
    {
        // clear all dependencies
        enemyWayPointManager.Clear();
        spawnPool.ReturnAllGivenObjects();
        spawnPool.Clear();
    }

    public void Activate(int level)
    {
        //Debug.Log(level);
        spawnsLeft = enemySpawnControllerInfo.CalculateSpawnCount(level);
        isStartSpawningFlag = true;
    }

    private void CreateEnemyWayPointManager()
    {
        enemyWayPointManager = new EnemyWayPointManager(wayPointControllers);
    }

    private void CreateEnemiesPool()
    {
        enemiesRoot = new GameObject("EnemiesRoot").transform;
        spawnPool = new SpawnPool(enemySpawnInfo.spawnPrefab, enemiesRoot);
    }

    private void SetCurrentSpawnTime(float newTime)
    {
        currentSpawnTime = newTime;
    }

    private void UpdateSpawnTime()
    {
        if (spawnsLeft == 0)
        {
            if (isStartSpawningFlag)
            {
                isStartSpawningFlag = false;
                GameStats.onEnemiesEnd?.Invoke();
            }
            return;
        }
        currentSpawnTime -= Time.deltaTime;
        if (currentSpawnTime <= 0)
        {
            SetCurrentSpawnTime(enemySpawnControllerInfo.spawnTime);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemy = spawnPool.GetObject();
        enemy.transform.position = new Vector3(0, 0, 0);
        Action onDieActon = () =>
          {
              spawnPool.ReturnObject(enemy);
          };
        enemy.GetComponent<EnemyController>().AddOnDieEvent(onDieActon);
        enemy.GetComponent<EnemyController>().SetUpSettings(enemySpawnInfo);
        enemy.GetComponent<Collider>().enabled = true;
        enemyWayPointManager.AddEnemy(enemy);
        enemy.SetActive(true);
        spawnsLeft--;
    }




}
