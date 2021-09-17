using System;
using UnityEngine;

[Serializable]
public class PlayerMovementStats
{
    private PlayerMovementStats()
    {
        
    }
        
    [SerializeField] private float m_smoothingCamera;
    public float SmoothingCamera => m_smoothingCamera;

    [SerializeField] private float m_mouseSensitivity;
    public float MouseSensitivity => m_mouseSensitivity;

    [SerializeField] private float m_speedMoving;
    public float SpeedMoving => m_speedMoving;

    [SerializeField] private float m_minYRotation;
    public float MinYRotation => m_minYRotation;

    [SerializeField] private float m_maxYRotation;
    public float MaxYRotation => m_maxYRotation;
}
