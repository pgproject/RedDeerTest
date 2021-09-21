using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractive
{
    [SerializeField] private List<InteractiveObject> m_interactiveObject = new List<InteractiveObject>();
    [SerializeField] private int m_floorId;
    
    public void Interact(bool innerUse, int floorId = 0)
    {
        for (int i = 0; i < m_interactiveObject.Count; i++)
        {
            if (CanUse())
            {
                m_interactiveObject[i].Interact(true, m_floorId);
            }
        }
    }

    public bool CanUse()
    {
        return m_interactiveObject.Any(x => x.CanUse());
    }
}
