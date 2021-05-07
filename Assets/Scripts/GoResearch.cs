using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;


public class GoResearch : Action
{
    public override bool EnterAction()
    {
        gameObjTarget = World.Instance.GetQueue("offices").RemoveResource();
        if (gameObjTarget == null)
            return false;
        inventory.AddItem(gameObjTarget);
        World.Instance.ModifyState("FreeOffice", -1);
        return true;
    }

    public override bool ExitAction()
    {
        World.Instance.GetQueue("offices").AddResource(gameObjTarget);
        inventory.RemoveItem(gameObjTarget);
        World.Instance.ModifyState("FreeOffice", 1);
        return true;
    }
}
