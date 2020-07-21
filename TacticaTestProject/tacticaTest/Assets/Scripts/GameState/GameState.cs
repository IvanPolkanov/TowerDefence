using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameState
{
    public virtual void Activate()
    {
        Debug.Log("No overrided");
    }


    public virtual void Deactivate()
    { 
    
    }

}
