using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoHome : Action
{
    public override bool EnterAction()
    {

        beliefs.Remove("atHospital");

        return true;
    }

    public override bool ExitAction()
    {
        Destroy(gameObject, 1);
        return true;
    }
}
