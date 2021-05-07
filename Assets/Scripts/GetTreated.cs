using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GetTreated : Action
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
        World.Instance.ModifyState("Treated", 1);
        if (beliefs.TryGetValue("isCured", out WorldState state))
            state.value += 1;
       // beliefs.ModifyState("isCured", 1);
        inventory.RemoveItem(gameObjTarget);
        return true;
    }
}
