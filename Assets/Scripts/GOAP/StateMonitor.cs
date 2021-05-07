using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public class StateMonitor : MonoBehaviour
    {
        public string state;
        public float stateStrength;
        public float stateDecayRate;
        public Dictionary<string, WorldState> beliefs;
        public GameObject resourcePrefab;
        public string queueName;
        public string worldState;
        public Action action;

        bool stateFound = false;
        float initialStrength;

        // Start is called before the first frame update
        void Awake()
        {
            beliefs = GetComponent<Agent>().beliefs;
            initialStrength = stateStrength;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (action.running)
            {
                stateFound = false;
                stateStrength = initialStrength;
            }

            if (!stateFound && HasState(state))
                stateFound = true;

            if (stateFound)
            {
                stateStrength -= stateDecayRate * Time.deltaTime;
                if (stateStrength <= 0)
                {
                    Vector3 location = new Vector3(transform.position.x, resourcePrefab.transform.position.y, transform.position.z); // Make it sit on the ground at the location of the agent
                    GameObject p = Instantiate(resourcePrefab, location, resourcePrefab.transform.rotation);
                    stateFound = false; // restart if needed
                    stateStrength = initialStrength;
                    RemoveState(state);
                    World.Instance.GetQueue(queueName).AddResource(p);
                    World.Instance.ModifyState(worldState, 1);
                }
            }
        }

        public bool HasState(string key)
        {
            return beliefs.ContainsKey(key);
        }

        void AddState(string key, int value)
        {
            beliefs.Add(key, new WorldState(key, value));
        }

        public void AddBeliefState(string key)
        {
            beliefs.Add(key, new WorldState(key, 0));
        }

        public void ModifyState(string key, int value)
        {
            if (beliefs.ContainsKey(key))
            {
                beliefs[key].value += value; // modify the value of that state by the amount in value
                if (beliefs[key].value <= 0) // if the state has no values left, remove it
                    RemoveState(key);
            }
            else
                beliefs.Add(key, new WorldState(key, value)); // if state doesn't exist then add it
        }

        public void RemoveState(string key)
        {
            if (beliefs.ContainsKey(key))
                beliefs.Remove(key);
        }

        public void SetState(string key, int value)
        {
            if (beliefs.ContainsKey(key))
                beliefs[key].value = value;
            else
                beliefs.Add(key, new WorldState(key, value));
        }
    }
}
