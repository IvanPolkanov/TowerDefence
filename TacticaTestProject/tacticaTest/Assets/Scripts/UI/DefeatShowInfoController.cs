using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DefeatShowInfoController : MonoBehaviour
{
    [SerializeField] GameObject defeatCanvas;
    [SerializeField] Button newGameButton;
    [SerializeField] TextMeshProUGUI killCountInfoText;

    public static Action onNewGameButton;

    private void Start()
    {
        SubscribeOnLifeEnd();
        SubscribeOnNewGameButton();
    }

    private void SubscribeOnNewGameButton()
    {
        newGameButton.onClick.AddListener(delegate
        {
            defeatCanvas.SetActive(false);
            onNewGameButton?.Invoke();
        });
    }

    private void SubscribeOnLifeEnd()
    {
        GameStats.onLifeEnd += OnLifeEnd;
    }

    private void OnLifeEnd(int killCount)
    {
        killCountInfoText.text = "Ur kill "+killCount.ToString()+" enemies";
        defeatCanvas.SetActive(true);
    }

}
