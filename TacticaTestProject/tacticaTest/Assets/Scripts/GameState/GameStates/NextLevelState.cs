using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class NextLevelState : GameState
{

    private MainGameStateMachine mainGameStateMachine;
    private Timer breakTimer = new Timer(GameStats.mainConfig.breakBetweenLevels * 1000);

    public NextLevelState(MainGameStateMachine mainGameStateMachine)
    {
        this.mainGameStateMachine = mainGameStateMachine;
    }

    public override void Activate()
    {
        
        breakTimer.Elapsed += OnBreakEnd;
        breakTimer.AutoReset = false;
        breakTimer.Enabled=true;
    }

    private void OnBreakEnd(object sender, ElapsedEventArgs e)
    {
        mainGameStateMachine.ChangeState(mainGameStateMachine.levelState);
    }

    public override void Deactivate()
    {
        breakTimer.Stop();
        breakTimer.Elapsed -= OnBreakEnd;
    }

}
