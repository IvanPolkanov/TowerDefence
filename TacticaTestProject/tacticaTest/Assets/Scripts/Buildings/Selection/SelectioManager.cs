using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class SelectioManager 
{
    private static BuildingInfo currentSelection;
    public static Action<BuildingInfo> onSelectionChange;

    public static void Initialize()
    {
        SubscribeEvents();
    }

    private static void SubscribeEvents()
    {
        MouseEvents.onRightMouseClick += ClearSelection;
    }

    private static void ClearSelection()
    {
        currentSelection = null;
        onSelectionChange?.Invoke(currentSelection);
    }




    public static void UpdateSelection(BuildingInfo newSelection)
    {
        currentSelection = newSelection;
        onSelectionChange?.Invoke(currentSelection);
    }

}
