using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoToWaitingRoom : Action
{
    public override bool EnterAction()
    {
        return true;
    }

    public override bool ExitAction()
    {
        World.Instance.ModifyState("Waiting", 1);
        World.Instance.GetQueue("patients").AddResource(gameObject);
        if (beliefs.TryGetValue("atHospital", out WorldState state))
            state.value += 1;
        //beliefs.ModifyState("atHospital", 1);
        return true;
    }
}
