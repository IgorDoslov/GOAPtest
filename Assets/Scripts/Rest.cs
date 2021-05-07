using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class Rest : Action
{
    public override bool EnterAction()
    {
        return true;
    }

    public override bool ExitAction()
    {
        beliefs.Remove("exhausted");
        return true;
    }
}
