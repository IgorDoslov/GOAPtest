﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GOAP;

public class UpdateWorld : MonoBehaviour
{
    public Text states;

    // Update is called once per frame
    void LateUpdate()
    {
        Dictionary<string, WorldState> worldstates = World.Instance.Getstates();
        states.text = "";
        foreach(KeyValuePair<string, WorldState> s in worldstates)
        {
            states.text += s.Key + ", " + s.Value + "\n";
        }
    }
}
