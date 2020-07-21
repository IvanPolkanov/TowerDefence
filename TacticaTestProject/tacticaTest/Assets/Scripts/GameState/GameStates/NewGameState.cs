using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewGameState : GameState
{
    private MainGameStateMachine mainGameStateMachine;
    public static Action onNewGameStart;

    public NewGameState(MainGameStateMachine mainGameStateMachine)
    {
       
        this.mainGameStateMachine = mainGameStateMachine;
    }

   

    public override void Activate()
    {
        //GameStats.UpdateGoldCount(GameStats.mainConfig.startGoldAmount);
        //GameStats.UpdateLifeCount(GameStats.mainConfig.startLifeCount);
        //GameStats.level = 0;

        GameStats.Reset();
        SecretTowerContainer.ClearAll();
        
          onNewGameStart?.Invoke();
      //  EnemyWayPointManager.ClearDirectrly();

        mainGameStateMachine.ChangeState(mainGameStateMachine.levelState);
        
    }

}
