using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform m_startTransform;
    [SerializeField] private Pool m_bulletPool;
    
    public void Shoot()
    {
        GameObject bullet = m_bulletPool.GetObject(m_startTransform.position);
    }
}
