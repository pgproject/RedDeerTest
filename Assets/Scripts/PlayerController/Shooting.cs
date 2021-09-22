using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform m_startTransform;
    [SerializeField] private Pool m_bulletPool;
    
    public void Shoot()
    {
        m_bulletPool.GetObject(m_startTransform.position);
    }
}
