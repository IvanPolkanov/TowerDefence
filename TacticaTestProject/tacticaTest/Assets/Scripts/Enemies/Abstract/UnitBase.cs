using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBase :MonoBehaviour
{
    protected float healthPoints;
    protected float currentHealthPoints;
    protected float moveSpeed;
    protected float stopDistance;
    protected int damage;
    protected float goldPerKill;
}
