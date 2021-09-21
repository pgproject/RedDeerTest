using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ElevatorUI m_elevatorUI;
    [SerializeField] private GameObject m_elevetorUIGameObject;
    [SerializeField] private Text m_hoursText;
    [SerializeField] private Text m_minuteText;
    [SerializeField] private Text m_secondsText;

    [SerializeField] private Text m_resultText;

    private const int UNIT_TIME = 60;
    private const int ADD_ZERO_TO_TEXT = 10;
    private int m_hours;
    private int m_minute;
    private int m_seconds;
    private int m_result;
    
    private InputAccess m_inputAccess => GeneralAccess.Instance.InputAccess;
    private InputAction m_closeUIButton => m_inputAccess.CloseUIButton.reference;
    void Update()
    {
        if (m_closeUIButton.triggered && m_elevetorUIGameObject.activeSelf)
        {
            m_elevatorUI.OpenClose();    
        }
        
        m_seconds = Mathf.RoundToInt(Time.realtimeSinceStartup) - (m_minute * UNIT_TIME) - (m_hours * UNIT_TIME * UNIT_TIME);

        if (m_seconds >= UNIT_TIME)
        {
            m_minute++;
            if (m_minute < ADD_ZERO_TO_TEXT)
            {
                m_minuteText.text = "0" +  m_minute + ":";

            }
            else
            {
                m_minuteText.text = m_minute + ":";
            }
        }

        if (m_minute >= UNIT_TIME)
        {        
            m_hours++;

            if (m_hours < ADD_ZERO_TO_TEXT)
            {
                m_hoursText.text = "0" + m_hours + ":";
            }
            else
            {
                m_hoursText.text = m_hours + ":";
            }
        }

        if (m_seconds < ADD_ZERO_TO_TEXT)
        {
            m_secondsText.text = "0" + m_seconds;
        }
        else
        {
            m_secondsText.text = m_seconds.ToString();
        }
    }

    public void SetResult()
    {
        m_result++;
        m_resultText.text = m_result.ToString();
    }
}
