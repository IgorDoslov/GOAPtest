﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class Run : Action
{
    public GameObject objToRunTOwards;
     // called at the begining of this action
    public override bool EnterAction()
    {
        gameObjTarget = objToRunTOwards;
        if (gameObjTarget == null)
        {
            return false;
        }
        return true;

    }

    // On exiting the state
    public override bool ExitAction()
    {
        Debug.Log("ran away");
        return true;
    }
}
