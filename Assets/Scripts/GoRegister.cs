using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoRegister : Action
{
    public override bool EnterAction()
    {
        return true;
    }

    public override bool ExitAction()
    {
        if (!beliefs.ContainsKey("atHospital"))
            beliefs.Add("atHospital", new WorldState("atHospital", 0));
        return true;
    }
}
