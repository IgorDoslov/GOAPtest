using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class CleanPoo : Action
{
    public override bool PrePerform()
    {
        target = World.Instance.GetQueue("poos").RemoveResource();
        if (target == null)
        {
            return false;
        }
        inventory.AddItem(target);
        World.Instance.GetWorld().ModifyState("FreePoo", -1);
        return true;
    }

    public override bool PostPerform()
    {
        inventory.RemoveItem(target);
        Destroy(target);
        return true;
    }
}
