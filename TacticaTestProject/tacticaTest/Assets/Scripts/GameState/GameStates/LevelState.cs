using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : GameState
{
    private EnemySpawnController enemySpawnController;
    private MainGameStateMachine mainGameStateMachine;
    public LevelState(MainGameStateMachine mainGameStateMachine)
    {
        this.mainGameStateMachine = mainGameStateMachine;
        enemySpawnController = GameObject.Find("Controllers").GetComponent<ControllersManager>().enemySpawnController;
    }

    public override void Activate()
    {
        GameStats.onEnemiesEnd += OnEnemiesEnd;
        enemySpawnController.Activate(GameStats.level++);
    }

    public override void Deactivate()
    {
        GameStats.onEnemiesEnd -= OnEnemiesEnd;
    }

    private void OnEnemiesEnd()
    {
        mainGameStateMachine.ChangeState(mainGameStateMachine.nextLevelState);
    }

}
