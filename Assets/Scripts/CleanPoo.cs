using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class CleanPoo : Action
{
    public override bool EnterAction()
    {
        gameObjTarget = World.Instance.GetQueue("poos").RemoveResource();
        if (gameObjTarget == null)
        {
            return false;
        }
        inventory.AddItem(gameObjTarget);
        World.Instance.ModifyState("FreePoo", -1);
        return true;
    }

    public override bool ExitAction()
    {
        inventory.RemoveItem(gameObjTarget);
        Destroy(gameObjTarget);
        return true;
    }
}
