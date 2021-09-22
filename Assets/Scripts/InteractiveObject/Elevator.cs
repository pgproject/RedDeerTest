using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : InteractiveObject
{
    [SerializeField] private ElevatorUI m_elevatorUI;
    [SerializeField] private List<Transform> m_floorsTransform = new List<Transform>();
    private bool m_isMove;
    private int m_currentFloorId;
    public bool IsMove => m_isMove;
   
    protected override IEnumerator Move()
    {
        m_startPosition = transform.position.y;
        m_endPosition = m_floorsTransform[m_currentFloorId].position.y;
        
        m_isMove = true;
        while (true)
        {
            m_normalize += Time.fixedDeltaTime / m_length * m_speed * (m_moveDirection ? -1 : 1);
            m_normalize = Mathf.Clamp01(m_normalize);

            m_rigidbody.MovePosition(Vector3.Lerp(m_startPoint, m_endPoint, Mathf.SmoothStep(0, 1, m_normalize)));

            if (m_normalize == 1)
            {
                m_isMove = false;
                yield break;
            }
            if (m_normalize == 0)
            {
                m_isMove = false;
                yield break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    public override void Interact(bool innerUse, int floorId)
    {
        if (innerUse)
        {
            if(m_currentFloorId == floorId)
            {
                return;
            }
            m_endPosition = m_floorsTransform[floorId].position.y;
            m_normalize = 0;
            m_currentFloorId = floorId;
            StartCoroutine(Move());
        }
        else
        {
            m_elevatorUI.OpenClose();
        }
        
    }

    public override bool CanUse()
    {
        return !m_isMove;
    }

    public void SetFloor(Vector3 floorPosition)
    {
        m_endPosition = floorPosition.y;
    }

    public void ButtonInElevator()
    {
        m_elevatorUI.SetButton(this);
    }
}
