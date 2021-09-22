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
    [SerializeField] private UIManager m_uiManager;
    private float m_movingSpeed => GeneralAccess.Instance.PlayerMovementStats.SpeedMoving;
    private float m_jumpHeight => GeneralAccess.Instance.PlayerMovementStats.JumpHeight;
    
    private InputAccess m_inputAccess => GeneralAccess.Instance.InputAccess;
    private InputAction m_move => m_inputAccess.Move.reference;
    private InputAction m_interaction => m_inputAccess.InteractionButton.reference;
    private InputAction m_shootAction => m_inputAccess.ShootAction.reference;
    private InputAction m_jumpAction => m_inputAccess.JumpAction.reference;
    private bool m_isGround;

    private int m_countJump;
    private const int LAYER_GROUND = 8;
    
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

        if (m_jumpAction.triggered && m_isGround)
        {
            m_rigidbody.velocity = new Vector3(0, m_jumpHeight, 0);
            m_countJump++;
            m_uiManager.CountJump(m_countJump);
        }
    }

    private void OnValidate()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LAYER_GROUND)
        {
            m_isGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LAYER_GROUND)
        {
            m_isGround = false;
        }
    }
}
