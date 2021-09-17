using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StrightPlatform : MonoBehaviour
{
   [SerializeField] private PlatformType m_platformType;
   [SerializeField] private Rigidbody m_rigidbody;
   [SerializeField] private float m_startPosition, m_endPosition;
   [SerializeField] private float m_speed;
   [SerializeField] private float m_waitTimeStartPoint, m_waitTimeEndPoint;
   
   private float m_normalize;
   private bool m_isMove;
   private bool m_moveDirection;
   private Vector2 m_startPoint
   {
      get
      {
         if (m_platformType == PlatformType.Horizontal)
         {
            return new Vector2(m_startPosition, transform.position.y);
         }

         return new Vector2(transform.position.x, m_startPosition);
      }
   }

   private Vector2 m_endPoint
   {
      get
      {
         if (m_platformType == PlatformType.Horizontal)
         {
            return new Vector2(m_endPosition, transform.position.y);
         }

         return new Vector2(transform.position.x, m_endPosition);
      }
   }

   private float m_length => Mathf.Abs(m_startPosition) + Mathf.Abs(m_endPosition);

   private void Start()
   {
      StartCoroutine(Move());
   }

   private IEnumerator Move()
   {
      m_isMove = true;
      while (true)
      {
         m_normalize += Time.fixedDeltaTime / m_length * m_speed * (m_moveDirection ? -1 : 1);
         m_normalize = Mathf.Clamp01(m_normalize);

         m_rigidbody.MovePosition(Vector2.Lerp(m_startPoint, m_endPoint, Mathf.SmoothStep(0, 1, m_normalize)));

         if (m_normalize == 1)
         {
            yield return new WaitForSeconds(m_waitTimeEndPoint);
            m_moveDirection = !m_moveDirection;
         }
         else if (m_normalize == 0)
         {
            yield return new WaitForSeconds(m_waitTimeStartPoint);
            m_moveDirection = !m_moveDirection;
         }
         yield return new WaitForFixedUpdate();
      }
   }

   private void OnValidate()
   {
      m_rigidbody = GetComponent<Rigidbody>();
   }
}
