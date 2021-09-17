using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_playerController;
    private InputAccess m_inputAccess => GeneralAccess.Instance.InputAccess;
    private PlayerMovementStats m_playerMovemementStats => GeneralAccess.Instance.PlayerMovementStats;
    private InputAction m_mouseDeltaInput => m_inputAccess.MouseDelta.reference;

    private float m_mouseSensitivity => m_playerMovemementStats.MouseSensitivity;
    private float m_smoothing => m_playerMovemementStats.SmoothingCamera;
    
    private Vector2 m_frameVelocity;
    private Vector2 m_velocity;
    private Vector2 m_mouseDelta;
    private Vector2 m_rawFrameVelocity;

    private float m_minYRotation => m_playerMovemementStats.MinYRotation;
    private float m_maxYRotation => m_playerMovemementStats.MaxYRotation;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        m_mouseDelta = m_mouseDeltaInput.ReadValue<Vector2>();
        
        m_rawFrameVelocity = Vector2.Scale(m_mouseDelta, Vector2.one * m_mouseSensitivity);
        
        m_frameVelocity = Vector2.Lerp(m_frameVelocity, m_rawFrameVelocity, 1 / m_smoothing);
        m_velocity += m_frameVelocity;

        m_velocity.y = Mathf.Clamp(m_velocity.y, m_minYRotation, m_maxYRotation);

        transform.localRotation = Quaternion.AngleAxis(-m_velocity.y, Vector3.right);
        m_playerController.localRotation = Quaternion.AngleAxis(m_velocity.x,  Vector3.up);
    }
}
