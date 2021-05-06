using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : Agent
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        //SubGoal s1 = new SubGoal("isWaiting", 1, true);
        //goalsDic.Add(s1, 3);

        //SubGoal s2 = new SubGoal("isTreated", 1, true);
        //goalsDic.Add(s2, 5);
        Invoke("NeedRelief", Random.Range(10, 20));

    }

    void NeedRelief()
    {
        beliefs.ModifyState("busting", 0);
        Invoke("NeedRelief", Random.Range(2, 5));
    }
}
