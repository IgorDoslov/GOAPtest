using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class CleanWee : Action
{
    public override bool EnterAction()
    {
        gameObjTarget = World.Instance.GetQueue("wees").RemoveResource();
        if (gameObjTarget == null)
        {
            return false;
        }
        inventory.AddItem(gameObjTarget);
        World.Instance.ModifyState("FreeWee", -1);
        return true;
    }

    public override bool ExitAction()
    {
        inventory.RemoveItem(gameObjTarget);
        Destroy(gameObjTarget);
        return true;
    }
}
