using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
   void Interact(bool innerUse, int floorId = 0);

   bool CanUse();
}
