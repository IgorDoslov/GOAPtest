using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanWee : Action
{
    public override bool PrePerform()
    {
        target = World.Instance.GetQueue("wees").RemoveResource();
        if (target == null)
        {
            return false;
        }
        inventory.AddItem(target);
        World.Instance.GetWorld().ModifyState("FreeWee", -1);
        return true;
    }

    public override bool PostPerform()
    {
        inventory.RemoveItem(target);
        Destroy(target);
        return true;
    }
}
