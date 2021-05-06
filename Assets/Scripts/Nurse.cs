using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : Agent
{
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        //SubGoal s1 = new SubGoal("treatPatient", 1, true);
        //goalsDic.Add(s1, 3);
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

}
