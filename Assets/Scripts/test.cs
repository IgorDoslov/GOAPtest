﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : Action
{
     // called at the begining of this action
    public override bool PrePerform()
    {
        return true;

    }

    // On exiting the state
    public override bool PostPerform()
    {
        return true;
    }
}
