using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Asset/GeneralAccess", order = 0, fileName = "GeneralAccess")]
public sealed class GeneralAccess : ScriptableObject
{
    private static GeneralAccess m_instance;

    public static GeneralAccess Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = Resources.Load<GeneralAccess>("GeneralAccess");

            return m_instance;
        }
    }

    private GeneralAccess()
    {
    }

    [SerializeField] private InputAccess m_inputAccess;
    public InputAccess InputAccess => m_inputAccess;

    [SerializeField] private PlayerMovementStats m_playerMovementStats;
    public PlayerMovementStats PlayerMovementStats => m_playerMovementStats;

}
