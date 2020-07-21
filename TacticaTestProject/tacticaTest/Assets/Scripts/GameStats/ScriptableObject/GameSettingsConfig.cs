using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new game settings config",menuName ="Config/GameSettings",order =55)]
public class GameSettingsConfig : ScriptableObject
{
    [SerializeField] float m_startGoldAmount;
    [SerializeField] int m_startLifeCount;
    [SerializeField] float m_breakBetweenLevels;


    public float breakBetweenLevels
    {
        get { return m_breakBetweenLevels; }
    }

    public int startLifeCount
    {
        get { return m_startLifeCount; }
    }

    public float startGoldAmount
    {
        get { return m_startGoldAmount; }
    }

    private void OnValidate()
    {
        if (m_startGoldAmount < 1)
            m_startGoldAmount = 1;
        if (m_startLifeCount < 1)
            m_startLifeCount = 1;
        if (m_breakBetweenLevels < 0)
            m_breakBetweenLevels = 0;
    }

}
