using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoToToilet : Action
{
    public override bool EnterAction()
    {
        gameObjTarget = World.Instance.GetQueue("toilets").RemoveResource();
        if (gameObjTarget == null)
            return false;
        inventory.AddItem(gameObjTarget);
        World.Instance.ModifyState("FreeToilet", -1);
        return true;
    }

    public override bool ExitAction()
    {
        World.Instance.GetQueue("toilets").AddResource(gameObjTarget);
        inventory.RemoveItem(gameObjTarget);
        World.Instance.ModifyState("FreeToilet", 1);
        beliefs.Remove("busting");
        return true;
    }
}
