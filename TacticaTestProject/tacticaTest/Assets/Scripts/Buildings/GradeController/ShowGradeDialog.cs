using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowGradeDialog : MonoBehaviour
{
    [SerializeField] GameObject gradeCanvas;
    [Space(20)]
    [SerializeField] TextMeshProUGUI gradeText;
    [SerializeField] TextMeshProUGUI gradeCost;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;

    private GradeItem currentGradeItem=null;
    private GradeInfo currentGradeInfo = null;
    private ITower currentTower;

    private void Start()
    {
        SubscribeEvents();    
    }

    private void SubscribeEvents()
    {
        MouseEvents.onLeftMouseClick += OnLeftMouseClick;
        noButton.onClick.AddListener(delegate
        {
            OnNoButton();
        });

        yesButton.onClick.AddListener(delegate
        {
            OnYesButton();    
        });
    }

    private void OnYesButton()
    {
        if (GameStats.TryGetGold(currentGradeItem.cost))
        {
            currentGradeInfo.UpGrade();
            currentTower.GradeTower(currentGradeItem.damageAddition, currentGradeItem.reloadReduce);
            ShowOffDialog();
        }

    }

    private void OnNoButton()
    {
        ShowOffDialog();
    }

    private void ShowOffDialog()
    {
        gradeCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnLeftMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("tower"))
            {
                if (Input.GetKey(KeyCode.G))
                {
                    Time.timeScale = 0;
                    currentGradeInfo = hit.transform.GetComponent<GradeInfo>();
                    currentGradeItem = currentGradeInfo.GetCurrentGrade();
                    currentTower = hit.transform.GetComponent<ITower>();
                    if (currentGradeItem != null)
                        LoadAllInfo();
                    else
                    {
                        ShowOffDialog();
                    }
                }
            }
        }
    }

    private void LoadAllInfo()
    {
        gradeText.text = currentGradeItem.infoText;
        gradeCost.text ="Cost: "+ currentGradeItem.cost.ToString();
        gradeCanvas.SetActive(true);
    }


}
