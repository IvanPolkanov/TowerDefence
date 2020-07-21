using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class DefeatGameState : GameState
{
    private MainGameStateMachine mainGameStateMachine;
    public DefeatGameState(MainGameStateMachine mainGameStateMachine)
    {
        this.mainGameStateMachine = mainGameStateMachine;
        SubscribeOnEvents();
    }

    private void SubscribeOnEvents()
    { 
        GameStats.onLifeEnd += OnLifeEnd;
        DefeatShowInfoController.onNewGameButton += delegate
        {
            mainGameStateMachine.ChangeState(mainGameStateMachine.newGameState);
            ;
        };
    
    }

    public override void Activate()
    {
        Time.timeScale = 0;
    }

    public override void Deactivate()
    {
       Time.timeScale = 1;
    }

    private void OnLifeEnd(int enemiesKilled)
    {
        mainGameStateMachine.ChangeState(mainGameStateMachine.defeatState);
    }

}
