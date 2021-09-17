using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : InteractiveObject
{

    private bool m_isMove;
    public bool IsMove => m_isMove;
   
    protected override IEnumerator Move()
    {
        m_isMove = true;
        while (true)
        {
            m_normalize += Time.fixedDeltaTime / m_length * m_speed * (m_moveDirection ? -1 : 1);
            m_normalize = Mathf.Clamp01(m_normalize);

            m_rigidbody.MovePosition(Vector2.Lerp(m_startPoint, m_endPoint, Mathf.SmoothStep(0, 1, m_normalize)));

            if (m_normalize == 1)
            {
                yield break;
                m_moveDirection = !m_moveDirection;
            }
            else if (m_normalize == 0)
            {
                yield break;
                m_moveDirection = !m_moveDirection;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    public void Interact()
    {
        StartCoroutine(Move());
    }

    public override bool CanUse()
    {
        return !m_isMove;
    }
}
