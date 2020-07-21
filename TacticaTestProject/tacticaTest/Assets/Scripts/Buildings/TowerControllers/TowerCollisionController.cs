using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCollisionController : MonoBehaviour
{

    private List<Transform> enemiesInsideRange=new List<Transform>();

    public Transform GetClosestEnemy()
    {
        ClearTrash();
        if (enemiesInsideRange.Count == 0)
            return null;
        else
        {
            enemiesInsideRange.Sort(new ClosestPointCoparer(transform));
            return enemiesInsideRange[0];
        }
    }

    private void ClearTrash()
    {
        List<Transform> tempList = new List<Transform>();
        foreach (var enemy in enemiesInsideRange)
        {
            if (!enemy.gameObject.activeSelf)
                tempList.Add(enemy.transform);
        }
        foreach (var enemy in tempList)
            enemiesInsideRange.Remove(enemy);
    }

    public bool IsAnyEnemies()
    {
        ClearTrash();
        return !(enemiesInsideRange.Count == 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("enemy"))
        {
            enemiesInsideRange.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("enemy"))
        {
            enemiesInsideRange.Remove(other.transform);
        }
    }
}
