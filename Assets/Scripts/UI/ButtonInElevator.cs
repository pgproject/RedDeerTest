using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInElevator : MonoBehaviour
{
   private Elevator m_elevator;
   [SerializeField] private ElevatorUI m_UIEleveator;
   [SerializeField] private Text m_id;
   public void ClickedButton(Transform floorTransform)
   {
       m_UIEleveator.OpenClose();        
       m_elevator.SetFloor(floorTransform.position); 
       m_elevator.Interact(true,Convert.ToInt32(m_id.text));
   }

   public void SetElevator(Elevator elevator)
   {
       m_elevator = elevator;
   }
}
