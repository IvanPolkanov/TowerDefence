using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayPointManager
{

    //private List<Transform> wayPoints;
    private List<WayPointController> wayPointControllers;
    private int currentWayPointIndex = 0;


    private static Dictionary<GameObject, int> currentEnemiesIndexes = new Dictionary<GameObject, int>();
    private static Dictionary<GameObject, WayPointController> currentEnemiesWayPointControllerIndexes =
        new Dictionary<GameObject, WayPointController>();

    public void Clear()
    {
        currentWayPointIndex = 0;
        currentEnemiesIndexes = new Dictionary<GameObject, int>();
        currentEnemiesWayPointControllerIndexes = new Dictionary<GameObject, WayPointController>();
    }

    public static void ClearDirectrly()
    {
      //  currentEnemiesIndexes = new Dictionary<GameObject, int>();
      //  currentEnemiesWayPointControllerIndexes = new Dictionary<GameObject, WayPointController>();
    }

    public EnemyWayPointManager(List<WayPointController> wayPointControllers)
    {
        // wayPoints = wayPointController.GetWayPoints();
        this.wayPointControllers = wayPointControllers;
    }

    public void AddEnemy(GameObject enemy)
    {
        var enemyController = enemy.GetComponent<EnemyController>();
        var currentWayPointController = wayPointControllers[currentWayPointIndex];

        AddEnemyToDictionaries(enemy, currentWayPointController);
       // currentEnemiesIndexes.Add(enemy, 1);
       // currentEnemiesWayPointControllerIndexes.Add(enemy, currentWayPointController);


        enemy.transform.position = currentWayPointController.GetWayPoints()[0].position;// wayPoints[0].position;
        enemyController.MoveTo(currentWayPointController.GetWayPoints()[1].position);

        currentWayPointIndex += 1;
        if (currentWayPointIndex == wayPointControllers.Count)
            currentWayPointIndex = 0;

        SubscribeOnEnemyActions(enemyController);
    }

    private void SubscribeOnEnemyActions(EnemyController enemyController)
    { 
        enemyController.onDieSelf += OnEnemyDie;
        enemyController.onStopSelf += OnEnemyStop;
        enemyController.onDieByKill += OnEnemyDie;
    }

    private void UnSubscribeEnemyActions(EnemyController enemyController)
    {
        enemyController.onDieSelf -= OnEnemyDie;
        enemyController.onStopSelf -= OnEnemyStop;
        enemyController.onDieByKill -= OnEnemyDie;
    }

    private void AddEnemyToDictionaries(GameObject enemy,WayPointController currentWayPointController)
    {
        currentEnemiesIndexes.Add(enemy, 1);
        currentEnemiesWayPointControllerIndexes.Add(enemy, currentWayPointController);
    }

    private void OnEnemyStop(GameObject enemy)
    {
        WayPointController wayPointController;
        currentEnemiesWayPointControllerIndexes.TryGetValue(enemy,out wayPointController);

        var wayPoints = wayPointController.GetWayPoints();


        int currentWayPointIndex;
        currentEnemiesIndexes.TryGetValue(enemy,out currentWayPointIndex);
        if (currentWayPointIndex + 1 < wayPoints.Count)
        {
            currentWayPointIndex += 1;
            currentEnemiesIndexes[enemy] = currentWayPointIndex;
            enemy.GetComponent<EnemyController>().MoveTo(wayPoints[currentWayPointIndex].position);
        }
    }

    private void OnEnemyDie(GameObject enemy)
    {
        //remove it from currentEnemiesIndexes 
        UnSubscribeEnemyActions(enemy.GetComponent<EnemyController>());
        currentEnemiesIndexes.Remove(enemy);
        currentEnemiesWayPointControllerIndexes.Remove(enemy);
    }

}
