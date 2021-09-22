using UnityEngine;

public class ElevatorUI : MonoBehaviour
{
    [SerializeField] private GameObject m_uiElevator;
    private InputAccess m_inputAccess => GeneralAccess.Instance.InputAccess;
    private string UIMap => m_inputAccess.ActionUIMapId;
    private string MovementMap => m_inputAccess.ActionMovementMapId;
    [SerializeField] private bool m_isOpen;
    
    public void OpenClose()
    {
        m_isOpen = !m_isOpen;
        string actionMapId = m_isOpen ? UIMap : MovementMap;
        
        m_inputAccess.ChangeMap(actionMapId);
        
        m_uiElevator.SetActive(m_isOpen);
    }
}
