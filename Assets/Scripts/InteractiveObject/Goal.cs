using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private UIManager m_uiManager;

    public void IncrementResult()
    {
        m_uiManager.SetResultScore();
    }
}