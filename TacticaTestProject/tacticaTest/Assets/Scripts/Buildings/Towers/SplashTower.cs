using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTower : MonoBehaviour, ITower
{
    public float damage { get; set; }
    public float reloadTime { get; set; }

    public float attackRadius { get; set; }

    public bool isEnabled { get; set; }

    private float currentReloadTime = 0;
    private TowerCollisionController towerCollisionController;

    public void GradeTower(float damage, float reloadTime)
    {
        this.damage += damage;
        this.reloadTime -= reloadTime;
        if (reloadTime <= 0) reloadTime = 0.1f;
    }

    private void Start()
    {
        GetCollisionController();
    }

    private void OnEnable()
    {
        UpdateColliderSize();
    }

    public void SetState(bool state)
    {
        enabled = state;
    }

    private void UpdateColliderSize()
    {
        transform.GetChild(0).GetComponent<SphereCollider>().radius *= attackRadius;
    }

    private void GetCollisionController()
    {
        towerCollisionController = transform.GetChild(0).GetComponent<TowerCollisionController>();
    }

    private void Update()
    {
        if (towerCollisionController.IsAnyEnemies())
            UpdateReloadTime();
    }

    private void UpdateReloadTime()
    {
        currentReloadTime -= Time.deltaTime;
        if (currentReloadTime <= 0)
        {
            currentReloadTime = reloadTime;
            Shoot();
        }
    }

    private void Shoot()
    {
        var enemy = towerCollisionController.GetClosestEnemy();
        if (enemy == null)
            reloadTime = 0;
        else
            enemy.GetComponent<EnemyController>().TakeDamage(damage);
    }
}
