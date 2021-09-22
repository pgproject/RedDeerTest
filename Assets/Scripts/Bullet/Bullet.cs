using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_timeToSwitchOff;
    [SerializeField] private Rigidbody m_rigidbody;
    private Vector3 m_direction;
    
    private void OnEnable()
    {
        m_camera = Camera.main;
        
        m_direction = m_camera.transform.forward;
        StartCoroutine(SwitchOffAfterTime());
    }

    private void FixedUpdate()
    {
        m_rigidbody.velocity = m_direction * m_speed;
    }

    private IEnumerator SwitchOffAfterTime()
    {
        yield return new WaitForSeconds(m_timeToSwitchOff);
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        other.collider.GetComponent<Goal>()?.IncrementResult();
        gameObject.SetActive(false);
    }
}
