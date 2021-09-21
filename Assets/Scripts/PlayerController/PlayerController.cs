using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private InteractWithObject m_interactWithObject;
    [SerializeField] private PlayerInput m_playerInput;
    [SerializeField] private Shooting m_shooting;
    private float m_movingSpeed => GeneralAccess.Instance.PlayerMovementStats.SpeedMoving;
    private InputAccess m_inputAccess => GeneralAccess.Instance.InputAccess;
    private InputAction m_move => m_inputAccess.Move.reference;
    private InputAction m_interaction => m_inputAccess.InteractionButton.reference;
    private InputAction m_shootAction => m_inputAccess.ShootAction.reference;
    
    private void Start()
    {
        m_inputAccess.SetActionInputAsset(m_playerInput);
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = m_move.ReadValue<Vector2>() * Vector2.one * m_movingSpeed;

        m_rigidbody.velocity =
            transform.rotation * new Vector3(targetVelocity.x, m_rigidbody.velocity.y, targetVelocity.y);
    }

    private void Update()
    {
        if (m_interaction.triggered && m_interactWithObject.InteractiveObject.Any())
        {
            m_interactWithObject.InteractiveObject[0].Interact(false);
        }

        if (m_shootAction.triggered)
        {
            m_shooting.Shoot();
        }
    }

    private void OnValidate()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    
}
