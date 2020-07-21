using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBarController : MonoBehaviour
{
    [SerializeField] Transform canvas;
    [SerializeField] Image hpBar;

    private Transform currentCamera;

    private void Start()
    {
        GetComponent<EnemyController>().onHpChange += OnHpChange;
        currentCamera = CameraContainer.currentCamera;
    }

    private void Update()
    {
        LookOnCamera();   
    }

    private void LookOnCamera()
    {
        canvas.LookAt(currentCamera);
    }

    private void OnHpChange(float currentXp,float maxXp)
    {
        hpBar.fillAmount = currentXp / maxXp;
    }
}
