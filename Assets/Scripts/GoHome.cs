using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoHome : Action
{
    public override bool PrePerform()
    {
        beliefs.RemoveState("atHospital");

        return true;
    }

    public override bool PostPerform()
    {
        Destroy(this.gameObject, 1);
        return true;
    }
}
