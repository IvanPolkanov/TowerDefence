using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStateMachine : GameStateMachineBase
{
    public GameState newGameState;
    public GameState levelState;
    public GameState defeatState;
    public GameState nextLevelState;

    private void Start()
    {
        CreateGameStates();
        SetFirstState();
    }

    private void SetFirstState()
    {
        currentState = newGameState;
        currentState.Activate();
    }

    private void CreateGameStates()
    {
        levelState = new LevelState(this);
        newGameState = new NewGameState(this);
        defeatState = new DefeatGameState(this);
        nextLevelState = new NextLevelState(this);
    }




}
