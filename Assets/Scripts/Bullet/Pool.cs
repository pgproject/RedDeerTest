using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Pool : MonoBehaviour
{

    [SerializeField] private GameObject m_prefabTToCreate;
    [SerializeField] private int m_amountAtStart;
    [SerializeField] private GameObject m_parent;
    private List<GameObject> m_poolObjects = new List<GameObject>();

    private void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < m_amountAtStart; i++)
        {
            GameObject obj = Instantiate(m_prefabTToCreate, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0), m_parent.transform);
            obj.SetActive(false);
            m_poolObjects.Add(obj);
        }
    }
    
    public GameObject GetObject(Vector3 pos)
    {
        for (int i = 0; i < m_poolObjects.Count; i++)
        {
            if (!m_poolObjects[i].activeSelf)
            {
                m_poolObjects[i].transform.position = pos;
                m_poolObjects[i].SetActive(true);
                return m_poolObjects[i];
            }
        }
        GameObject obj = Instantiate(m_prefabTToCreate, pos, Quaternion.Euler(0, 0, 0), m_parent.transform);
        m_poolObjects.Add(obj);
        return obj;
    }

  
}
