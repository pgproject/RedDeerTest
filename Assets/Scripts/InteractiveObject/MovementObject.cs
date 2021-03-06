using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public abstract class MovementObject : MonoBehaviour
{
    [SerializeField] private bool m_showStartEndPoint;
    [ConditionalHide("m_showStartEndPoint", true), SerializeField] protected float m_startPosition, m_endPosition;
    
    [SerializeField] protected Rigidbody m_rigidbody;
    [SerializeField] protected float m_speed;
    protected float m_length => Mathf.Abs(m_startPosition) + Mathf.Abs(m_endPosition);

    protected virtual Vector3 m_startPoint => new Vector3(transform.position.x, m_startPosition, transform.position.z);

    protected virtual Vector3 m_endPoint => new Vector3(transform.position.x, m_endPosition, transform.position.z);

    protected abstract IEnumerator Move();
    protected bool m_moveDirection;
    [SerializeField] protected float m_normalize;

    protected virtual void OnValidate()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
}
