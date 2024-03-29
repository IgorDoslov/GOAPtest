﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public class Node
    {
        public Node parent;
        public float cost;
        public Dictionary<string, WorldState> state; // world state
        public Action action;

        public Node(Node a_parent, float a_cost, Dictionary<string, WorldState> a_allStates, Action a_action)
        {
            parent = a_parent;
            cost = a_cost;
            state = new Dictionary<string, WorldState>(a_allStates);
            action = a_action;
        }

        public Node(Node a_parent, float a_cost, Dictionary<string, WorldState> a_allStates, Dictionary<string, WorldState> a_beliefStates, Action a_action)
        {
            parent = a_parent;
            cost = a_cost;
            state = new Dictionary<string, WorldState>(a_allStates);
            foreach (KeyValuePair<string, WorldState> belief in a_beliefStates)
            {
                if (!state.ContainsKey(belief.Key))
                    state.Add(belief.Key, belief.Value);
            }
            action = a_action;
        }
    }
}