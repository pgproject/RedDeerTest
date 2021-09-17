using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MovementObject, IInteractive
{
    protected override IEnumerator Move()
    {
        yield break;
    }
    
    public virtual void Interact()
    {
        StartCoroutine(Move());
    }

    public abstract bool CanUse();
}
