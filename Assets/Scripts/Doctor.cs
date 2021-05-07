using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

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
        if (!beliefs.ContainsKey("exhausted"))
            beliefs.Add("exhausted", new WorldState("exhausted", 0));
        Invoke("GetTired", Random.Range(10, 20));
    }

    void NeedRelief()
    {
        if (!beliefs.ContainsKey("busting"))
            beliefs.Add("busting", new WorldState("busting", 0));
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
            StopAction();
            if (!beliefs.ContainsKey("Run"))
                beliefs.Add("Run", new WorldState("Run", 0));
        }
        else
        {
            beliefs.Remove("Run");
        }
    }
}
