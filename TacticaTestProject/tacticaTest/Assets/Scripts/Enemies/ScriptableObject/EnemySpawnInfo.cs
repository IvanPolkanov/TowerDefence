using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new enemy spawn info",menuName ="Config/Enemy spawn info",order =54)]
public class EnemySpawnInfo : ScriptableObject
{
    [SerializeField] GameObject m_spawnPrefab;
    [SerializeField] float m_maxXp;
    [SerializeField] float m_startXp;
    [SerializeField] float m_moveSpeed;
    [SerializeField] float m_stopDistance;
    [SerializeField] int m_damage;
    [SerializeField] float m_goldPerKill;

    public float stopDistance
    {
        get { return m_stopDistance; }
    }

    public float goldPerKill
    {
        get { return m_goldPerKill; }
    }

    public int damage
    {
        get { return m_damage; }
    }

    public float moveSpeed
    {
        get { return m_moveSpeed;}
    }

    public float startXp
    {
        get { return m_startXp; }
    }

    public float maxXp
    {
        get { return m_maxXp; }
    }

    public GameObject spawnPrefab
    {
        get { return m_spawnPrefab; }
    }

    private void OnValidate()
    {
        if (m_maxXp < 1)
            m_maxXp = 1;

        if (m_startXp < 1)
            m_startXp = 1;

        if (m_startXp > m_maxXp)
            m_startXp = m_maxXp;

        if (m_moveSpeed <0)
            m_moveSpeed = 0;
    }

}
