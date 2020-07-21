using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlacer : MonoBehaviour
{

    private GameObject ghostObject;
    private GhostCollisionController ghostCollisionController;
    private BuildingInfo currentBuildInfo;

    private void Start()
    {
        SubscribeOnSelectionChange();
        SubscribeOnLeftButton();
    }

    private void SubscribeOnLeftButton()
    {
        MouseEvents.onLeftMouseClick += OnLeftButton;
    }

    private void OnLeftButton()
    {
        if (ghostObject != null)
            TryBuild();
    }

    private void TryBuild()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return;
        }

        if (ghostCollisionController.IsCollisionsFree())
        {
            if (GameStats.TryGetGold(currentBuildInfo.cost))
            {
               var towerSettings= ghostObject.GetComponent<ITower>();
                towerSettings.damage = currentBuildInfo.damage;
                towerSettings.reloadTime = currentBuildInfo.reloadTime;
                towerSettings.attackRadius = currentBuildInfo.attackRange;
                Destroy(ghostObject.GetComponent<GhostCollisionController>());
                towerSettings.SetState(true);

                SecretTowerContainer.AddTower(ghostObject);

                ghostObject = null;
            }
        }
    }

    private void SubscribeOnSelectionChange()
    {
        SelectioManager.onSelectionChange += OnSelectionChange;
    }

    private void OnSelectionChange(BuildingInfo buildingInfo)
    {
        if (buildingInfo == null)
        {
            if (ghostObject != null)
                Destroy(ghostObject);
        }
        else
        {
            if (ghostObject != null)
                Destroy(ghostObject);
            currentBuildInfo = buildingInfo;
            CreateGhost();
        }
    }

    private void CreateGhost()
    {
        ghostObject = Instantiate(currentBuildInfo.prefab);
        ghostObject.GetComponent<ITower>().SetState(false);
        ghostCollisionController = ghostObject.AddComponent<GhostCollisionController>();
    }

    private void Update()
    {
        CheckMoveAvailability();    
    }

    private void CheckMoveAvailability()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("buildAvailable"))
            {
                if (ghostObject != null)
                    MoveGhost(hit);
            }
        }
    }


    private void MoveGhost(RaycastHit hit)
    {
        ghostObject.transform.position = hit.transform.position + hit.transform.up*3.001f;
    }

}
