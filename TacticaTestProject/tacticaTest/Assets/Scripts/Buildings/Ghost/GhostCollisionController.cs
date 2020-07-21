using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollisionController : MonoBehaviour
{
    private int collisionCount=0;

    public bool IsCollisionsFree()
    {
        return (collisionCount == 0);
    }

    private void OnTriggerEnter(Collider other)
    {
            if(other.CompareTag("tower"))
        collisionCount++;
    }

    private void OnTriggerExit(Collider other)
    {
            if (other.CompareTag("tower"))
                collisionCount--;
    }

}
