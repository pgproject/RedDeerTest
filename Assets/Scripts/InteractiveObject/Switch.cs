using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractive
{
    [SerializeField] private List<InteractiveObject> m_interactiveObject = new List<InteractiveObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        for (int i = 0; i < m_interactiveObject.Count; i++)
        {
            if (CanUse())
                m_interactiveObject[i].Interact();    
        }
    }

    public bool CanUse()
    {
        return m_interactiveObject.Any(x => x.CanUse());
    }
}
