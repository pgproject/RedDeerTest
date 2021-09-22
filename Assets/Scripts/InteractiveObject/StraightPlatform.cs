using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPlatform : MovementObject
{
   [SerializeField] private PlatformMoveType m_platformType;
   [SerializeField] private float m_waitTimeStartPoint, m_waitTimeEndPoint;
   
   protected override Vector3 m_startPoint
   {
      get
      {
         if (m_platformType == PlatformMoveType.X_Axis)
         {
            return new Vector3(m_startPosition, transform.position.y, transform.position.z);
         } 
         if(m_platformType == PlatformMoveType.Y_Axis)
         {
            return new Vector3(transform.position.x, m_startPosition, transform.position.z);
         }
         
         return new Vector3(transform.position.x,  transform.position.y, m_startPosition);
      }
   }

   protected override Vector3 m_endPoint
   {
      get
      {
         if (m_platformType == PlatformMoveType.X_Axis)
         {
            return new Vector3(m_endPosition, transform.position.y, transform.position.z);
         }

         if (m_platformType == PlatformMoveType.Y_Axis)
         {
            return new Vector3(transform.position.x, m_endPosition, transform.position.z);
         }
         
         return new Vector3(transform.position.x, transform.position.y, m_endPosition);
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

         m_rigidbody.MovePosition(Vector3.Lerp(m_startPoint, m_endPoint, Mathf.SmoothStep(0, 1, m_normalize)));

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
