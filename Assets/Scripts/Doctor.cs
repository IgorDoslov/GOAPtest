﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : Agent
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        Invoke("GetTired", Random.Range(10, 20));
        Invoke("NeedRelief", Random.Range(10, 20));
    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(10, 20));
    }

    void NeedRelief()
    {
        beliefs.ModifyState("busting", 0);
        Invoke("NeedRelief", Random.Range(2, 5));
    }

    public GameObject player;
    public override void LateUpdate()
    {
        base.LateUpdate();
        float dist = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(dist);
        if (dist <= 5f)
        {
            
            beliefs.ModifyState("Run", 1);
        }
        else
        {
            beliefs.RemoveState("Run");
        }
    }
}