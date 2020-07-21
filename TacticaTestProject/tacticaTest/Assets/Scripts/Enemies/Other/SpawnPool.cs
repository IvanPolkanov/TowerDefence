using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPool 
{

    private Queue<GameObject> m_objectsPool=new Queue<GameObject>();
    private GameObject prefab;
    private Transform parent;

    private List<GameObject> givenObjects = new List<GameObject>();

    public SpawnPool(GameObject prefab, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;
    }


    public GameObject GetObject()
    {
        if (m_objectsPool.Count <1)
        {
            GrowPool();   
        }
       var tempObj = m_objectsPool.Dequeue();
        givenObjects.Add(tempObj);
        return tempObj;
    }

    public void ReturnAllGivenObjects()
    {
        Debug.Log(givenObjects.Count + "/" + m_objectsPool.Count);
        foreach (var tempObject in givenObjects.ToList())
        {
            ReturnObject(tempObject);
        }
        Debug.Log(givenObjects.Count + "/" + m_objectsPool.Count);
        givenObjects.Clear();
    }

    public void Clear()
    {
        foreach (var temp in m_objectsPool.ToList())
        {
            GameObject.Destroy(temp);
        }
        m_objectsPool.Clear();
    }

    public void ReturnObject(GameObject instance)
    {
        instance.SetActive(false);
        givenObjects.Remove(instance);
        m_objectsPool.Enqueue(instance);
    }

    private void GrowPool()
    {
        var tempObject = GameObject.Instantiate(prefab);
        tempObject.SetActive(false);
        tempObject.transform.SetParent(parent);
        m_objectsPool.Enqueue(tempObject);
    }


}
