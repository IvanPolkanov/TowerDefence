using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestPointCoparer : IComparer<Transform>
{

    private Transform center;

    public ClosestPointCoparer(Transform center)
    {
        this.center = center;
    }

    public int Compare(Transform x, Transform y)
    {
        var xDistance = (x.position - center.position).magnitude;
        var yDistance = (y.position - center.position).magnitude;

        if (xDistance < yDistance) return -1;
        if (xDistance == yDistance) return 0;
        return 1;
    }
}
