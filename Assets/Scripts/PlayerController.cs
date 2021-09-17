using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rigidbody;
    private float m_movingSpeed => GeneralAccess.Instance.PlayerMovementStats.SpeedMoving;
    private InputAccess m_inputAccess => GeneralAccess.Instance.InputAccess;
    private InputAction m_move => m_inputAccess.Move.reference;

    void Update()
    {
        Vector2 targetVelocity = m_move.ReadValue<Vector2>() * Vector2.one * m_movingSpeed;

        m_rigidbody.velocity =
            transform.rotation * new Vector3(targetVelocity.x, m_rigidbody.velocity.y, targetVelocity.y);
    }

    private void OnValidate()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
}
