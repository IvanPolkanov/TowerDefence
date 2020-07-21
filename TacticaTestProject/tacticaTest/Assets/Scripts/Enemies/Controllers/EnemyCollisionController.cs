using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCollisionController : MonoBehaviour
{
    public Action onEndZoneAchieved;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("endZone"))
        {
            onEndZoneAchieved?.Invoke();
        }
    }
}
