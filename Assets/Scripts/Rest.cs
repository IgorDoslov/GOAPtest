using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class Rest : Action
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("exhausted");
        return true;
    }
}
