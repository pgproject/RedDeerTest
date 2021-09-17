using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    private List<IInteractive> m_interactiveObject = new List<IInteractive>();
    private const int LAYER_INTERACTIVE = 7;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LAYER_INTERACTIVE)
        {
            m_interactiveObject.Add(other.GetComponent<IInteractive>());
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
