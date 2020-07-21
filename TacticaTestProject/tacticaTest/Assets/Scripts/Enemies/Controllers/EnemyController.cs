using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : UnitBase,IUnit
{

    private Vector3 targetPosition;
    public Action<GameObject> onStopSelf;
    private Action onDie;
    public Action<GameObject> onDieSelf;
    public Action<GameObject> onDieByKill;
    public Action<float,float> onHpChange;

    //private Action additionalAction;

    public string hmm;


    public void AddOnDieEvent(Action onDieAction)
    {
        onDie = onDieAction;
    }

    public void AddToOnDieEvent(Action additionalAction)
    {
        onDie += additionalAction;
    }

    public void TakeDamage(float damage)
    {
        //Debug.Log(currentHealthPoints + "?" + healthPoints);
        currentHealthPoints -= damage;
        if (currentHealthPoints <= 0)
            DieByKill();
        else
            onHpChange?.Invoke(currentHealthPoints,healthPoints);

    }

    public void DieByKill()
    {
        GetComponent<Collider>().enabled = false;
        GameStats.EnemyDie(goldPerKill);
        onDie?.Invoke();
       // onDieByKill?.Invoke(gameObject);
        onDieSelf?.Invoke(gameObject);
    }

    public void Die()
    {
        GetComponent<Collider>().enabled = false;
        GameStats.EnemyDieByEndZone(damage);
        onDie?.Invoke();
        onDieSelf?.Invoke(gameObject);
    }

    public void SetUpSettings(EnemySpawnInfo enemySpawnInfo)
    {
        moveSpeed = enemySpawnInfo.moveSpeed;
        stopDistance = enemySpawnInfo.stopDistance;
        healthPoints = enemySpawnInfo.maxXp;
        currentHealthPoints = enemySpawnInfo.startXp * (1 +GameStats.level * 0.1f);
        healthPoints = enemySpawnInfo.maxXp *(1 + GameStats.level * 0.1f);
        damage = enemySpawnInfo.damage;
        goldPerKill = enemySpawnInfo.goldPerKill;

        onHpChange?.Invoke(currentHealthPoints, healthPoints);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Start()
    {
        SubsribeEvents();
    }

    private void SubsribeEvents()
    {
        GetComponent<EnemyCollisionController>().onEndZoneAchieved = Die;
    }

    private void Update()
    {
        hmm = currentHealthPoints + "/" + healthPoints;
        MoveToTargetPosition();    
    }

    private void MoveToTargetPosition()
    {
        
        if (targetPosition == transform.position) return;

        var direction = (targetPosition - transform.position);
        if (direction.magnitude <= stopDistance)
        {
            transform.position = targetPosition;
            onStopSelf?.Invoke(gameObject);
        }
        else
        {
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        }

        
    }
}
