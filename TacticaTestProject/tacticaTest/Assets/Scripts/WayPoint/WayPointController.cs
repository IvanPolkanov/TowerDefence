using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointController : MonoBehaviour
{
    public List<GameObject> wayPoints = new List<GameObject>();

    public void ShowText()
    {
        Debug.Log("Wow it is really works!!!");
    }

    public List<Transform> GetWayPoints()
    {
        var tempList = new List<Transform>();
        foreach (Transform tempPoint in transform)
        {
            tempList.Add(tempPoint);
        }
        return tempList;
    }

    private void OnDrawGizmos()
    {
        for (var i = 1; i < transform.childCount; i++)
        {
           var tempTransform =transform.GetChild(i);
                Gizmos.DrawLine(transform.GetChild(i - 1).position, transform.GetChild(i).position);

        }
    }

}
