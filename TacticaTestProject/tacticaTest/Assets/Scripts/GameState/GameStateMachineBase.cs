using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStateMachineBase :MonoBehaviour
{
    protected GameState currentState;

    public virtual void ChangeState(GameState newState)
    {
        currentState.Deactivate();
        currentState = newState;
        currentState.Activate();
    }

}
