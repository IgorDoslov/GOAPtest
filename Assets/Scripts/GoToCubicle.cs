using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;


public class GoToCubicle : Action
{
    public override bool EnterAction()
    {
        gameObjTarget = inventory.FindItemWithTag("Cubicle");
        if (gameObjTarget == null)
            return false;
        return true;
    }

    public override bool ExitAction()
    {
        World.Instance.ModifyState("TreatingPatient", 1);
        World.Instance.GetQueue("cubicles").AddResource(gameObjTarget);
        inventory.RemoveItem(gameObjTarget);
        World.Instance.ModifyState("FreeCubicle", 1);
        return true;
    }
}
