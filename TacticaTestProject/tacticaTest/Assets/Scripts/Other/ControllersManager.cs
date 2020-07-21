using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersManager : MonoBehaviour
{
    [SerializeField] EnemySpawnController m_enemySpawnController;
    [SerializeField] MainGameStatUIController m_mainGameStatUIController;

    public MainGameStatUIController mainGameStatUIController
    {
        get { return m_mainGameStatUIController; }
    }

    public EnemySpawnController enemySpawnController
    {
        get { return m_enemySpawnController; }
    }





}
