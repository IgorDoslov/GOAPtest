using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GetPatient : Action
{
    GameObject resource;
    public override bool EnterAction()
    {
        gameObjTarget = World.Instance.GetQueue("patients").RemoveResource();
        if (gameObjTarget == null)
            return false;

        resource = World.Instance.GetQueue("cubicles").RemoveResource();
        if (resource != null)
        {
            inventory.AddItem(resource);
        }
        else
        {
            World.Instance.GetQueue("patients").AddResource(gameObjTarget);
            gameObjTarget = null;
            return false;
        }
        World.Instance.ModifyState("FreeCubicle", -1);
        return true;
    }

    public override bool ExitAction()
    {
        World.Instance.ModifyState("Waiting", -1);
        if(gameObjTarget)
        {
            gameObjTarget.GetComponent<Agent>().inventory.AddItem(resource);
        }
        return true;
    }
}
