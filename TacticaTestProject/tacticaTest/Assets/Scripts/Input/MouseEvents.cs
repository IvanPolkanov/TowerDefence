using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseEvents : MonoBehaviour
{
    public static Action onRightMouseClick;
    public static Action onLeftMouseClick;

    private void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0))
            onLeftMouseClick?.Invoke();

        if (Input.GetMouseButtonDown(1))
            onRightMouseClick?.Invoke();
    }
}
