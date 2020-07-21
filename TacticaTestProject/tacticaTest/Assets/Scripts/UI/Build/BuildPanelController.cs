using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildPanelController : MonoBehaviour
{
    [SerializeField] GameObject buildingsPanel;
    [SerializeField] GameObject buildingButtonPrefab;
    [Space(20)]
    [SerializeField] List<BuildingInfo> buildings;

    private void Start()
    {
        CreateBuildingsButtons();
        SelectioManager.Initialize();
    }

    private void CreateBuildingsButtons()
    {
        foreach (var building in buildings)
        {
            var tempBuildingButton = Instantiate(buildingButtonPrefab);
            tempBuildingButton.transform.SetParent(buildingsPanel.transform);
            tempBuildingButton.transform.localScale = new Vector3(1, 1, 1);
            tempBuildingButton.GetComponent<Image>().sprite = building.icon;
            tempBuildingButton.GetComponent<Button>().onClick.AddListener(delegate
            {
                SelectioManager.UpdateSelection(building);
            });
        }
    }
}
