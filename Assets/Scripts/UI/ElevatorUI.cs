using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorUI : MonoBehaviour
{
    [SerializeField] private GameObject m_uiElevator;

    private bool m_isClose = true;
    
    public void OpenClose()
    {
        m_isClose = !m_isClose;
        m_uiElevator.SetActive(m_isClose);
    }
}
