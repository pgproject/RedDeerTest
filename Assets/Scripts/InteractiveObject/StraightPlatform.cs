using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPlatform : MovementObject
{
   [SerializeField] private PlatformType m_platformType;
   [SerializeField] private float m_waitTimeStartPoint, m_waitTimeEndPoint;
   
   protected override Vector2 m_startPoint
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

   protected override Vector2 m_endPoint
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


   private void Start()
   {
      StartCoroutine(Move());
   }

   protected override IEnumerator Move()
   {
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

}
