using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="new build info",menuName ="Config/Build info",order =57)]
public class BuildingInfo : ScriptableObject
{
    [SerializeField] Sprite m_icon;
    [SerializeField] GameObject m_prefab;
    [SerializeField] string m_name;
    [SerializeField] float m_cost;
    [SerializeField] float m_damage;
    [SerializeField] float m_attackRange;
    [SerializeField] float m_reloadTime;

    public float attackRange
    {
        get { return m_attackRange; }
    }

    public string buildingName
    {
        get { return m_name; }
    }

    public float reloadTime
    {
        get { return m_reloadTime; }
    }

    public float damage
    {
        get { return m_damage; }
    }

    public float cost
    {
        get { return m_cost; }
    }

    public GameObject prefab
    {
        get { return m_prefab; }
    }

    public Sprite icon
    { 
    get { return m_icon; }
    }

    private void OnValidate()
    {
        if (m_attackRange < 1)
            m_attackRange = 1;

        if (m_reloadTime < 0)
            m_reloadTime = 0;

        if (m_damage < 1)
            m_damage = 1;

        if (m_cost < 1)
            m_cost = 1;
    }


}
