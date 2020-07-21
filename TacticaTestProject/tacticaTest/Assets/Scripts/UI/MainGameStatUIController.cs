using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class MainGameStatUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldAmountInfo;
    [SerializeField] TextMeshProUGUI lifeCountInfo;

    private void Awake()
    {
        SubscribeOnChangeEvents();
    }

    private void SubscribeOnChangeEvents()
    { 
        GameStats.onGoldChange += OnGoldChange;
        GameStats.onLifeCountChange += OnLifeCountChange;
    }

    private void OnLifeCountChange(int lifeCount)
    {
        lifeCountInfo.text = lifeCount.ToString();
    }

    private void OnGoldChange(float goldAmount)
    {
        goldAmountInfo.text = goldAmount.ToString();
    }

}
