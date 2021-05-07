using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GOAP
{
    public abstract class Action : MonoBehaviour
    {
        public string actionName = "Action";
        public float cost = 1.0f;
        public GameObject gameObjTarget;
        public Vector3 vec3Destination = Vector3.zero;
        public string targetTag;
        public float duration = 0;
        public WorldState[] preConditions;
        public WorldState[] afterEffects;
        public NavMeshAgent navAgent;

        public Dictionary<string, WorldState> preconditionsDic;
        public Dictionary<string, WorldState> effectsDic;

        public Inventory inventory;
        public Dictionary<string, WorldState> beliefs;

        public bool running = false;

        public Action()
        {
            preconditionsDic = new Dictionary<string, WorldState>();
            effectsDic = new Dictionary<string, WorldState>();
        }

        public void Awake()
        {
            navAgent = gameObject.GetComponent<NavMeshAgent>();

            if (preConditions != null)
                foreach (WorldState w in preConditions)
                {
                    preconditionsDic.Add(w.key, new WorldState(w.key,w.value));
                }

            if (afterEffects != null)
                foreach (WorldState w in afterEffects)
                {
                    effectsDic.Add(w.key, new WorldState(w.key, w.value));
                }

            inventory = GetComponent<Agent>().inventory;
            beliefs = GetComponent<Agent>().beliefs;
        }

        public bool IsAchievable()
        {
            return true;
        }

        public bool IsAchievableGiven(Dictionary<string, WorldState> conditions)
        {
            foreach (KeyValuePair<string, WorldState> p in preconditionsDic)
            {
                if (!conditions.ContainsKey(p.Key))
                {
                    return false;
                }
            }
            return true;
        }

        public abstract bool EnterAction();
        public abstract bool ExitAction();


    }
}