using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    private List<IInteractive> m_interactiveObject = new List<IInteractive>();
    public List<IInteractive> InteractiveObject => m_interactiveObject;
    private const int LAYER_INTERACTIVE = 7;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LAYER_INTERACTIVE)
        {
            m_interactiveObject.Add(other.GetComponent<IInteractive>());
            
            if(other.GetComponent<Elevator>() != null)
                other.GetComponent<Elevator>().ButtonInElevator();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LAYER_INTERACTIVE)
        {
            m_interactiveObject.Remove(other.GetComponent<IInteractive>());
        }
    }
}
