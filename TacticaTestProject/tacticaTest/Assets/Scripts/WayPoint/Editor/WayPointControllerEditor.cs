using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(WayPointController))]
public class WayPointControllerEditor : Editor
{

    private Transform parent;
    private List<GameObject> wayPoints;
    private Color waypointsColor = Color.white;

    private void Awake()
    {
        WayPointController wayPointController = (WayPointController)target;
        wayPoints = wayPointController.wayPoints;
        parent = wayPointController.transform;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Clear waypoints"))
        {
            for (var i = 0; i < wayPoints.Count; i++)
            {
                DestroyImmediate(wayPoints[i]);
            }
            wayPoints.Clear();
        }
        var tempColor = EditorGUILayout.ColorField("Waypoints color", waypointsColor);
        if (waypointsColor != tempColor)
        {
            waypointsColor = tempColor;
            RedrawWaypointsMaterialColor(tempColor);
        }
    }

    private void RedrawWaypointsMaterialColor(Color newColor)
    {
        
            foreach (GameObject t in wayPoints)
            {
                Renderer rend = t.GetComponent<Renderer>();

                if (rend != null)
                    rend.sharedMaterial.color = newColor;
            }
    }

    void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown&&Event.current.button==0)
        {
            Ray worldRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(worldRay, out hitInfo))
            {
                if (!hitInfo.transform.CompareTag("WayPoint"))
                {
                    CreateNewWaypoint(hitInfo.point,hitInfo.normal);
                }
            }
        }
        Selection.activeObject = parent.gameObject;
    }

    private void CreateNewWaypoint(Vector3 position,Vector3 normal)
    {
        GameObject waypointInstance = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        waypointInstance.transform.position = position +
            normal * waypointInstance.GetComponent<SphereCollider>().radius;
        waypointInstance.GetComponent<Renderer>().material =
            Resources.Load("Materials/WaypointMaterial") as Material;
        waypointInstance.transform.SetParent(parent);
        waypointInstance.tag = "WayPoint";
        wayPoints.Add(waypointInstance);
        EditorUtility.SetDirty(waypointInstance);
    }

}
