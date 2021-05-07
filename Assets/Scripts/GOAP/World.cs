using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GOAP
{
    [System.Serializable]
    public class WorldState
    {
        public string key;
        public int value;

        public WorldState(string key, int value)
        {
            this.key = key;
            this.value = value;
        }

        public void ModifyState(int value)
        {
            this.value += value;
        }
    }

    [ExecuteAlways]
    public class World : Singleton<World>
    {
        public Dictionary<string, WorldState> states = new Dictionary<string, WorldState>();

        private void Update()
        {
            //if (UnityEditor)
            if (resourceQueues != null ) 
            {
                foreach (ResourceQueue item in resourceQueues)
                {
                    item.gameObjectsWithTag = new List<GameObject>(FindAllGameObjectsWithTag(item.tag));
                    
                }
            }
        }

        //private readonly World instance;// = new World();
        private Dictionary<string, WorldState> worldSt = new Dictionary<string, WorldState>();
        private ResourceQueue patients;
        private ResourceQueue cubicles;
        private ResourceQueue offices;
        private ResourceQueue toilets;
        private ResourceQueue wees;
        private ResourceQueue poos;
        public Dictionary<string, ResourceQueue> resources = new Dictionary<string, ResourceQueue>();
        
        public ResourceQueue[] resourceQueues;

        public void Awake()
        {
           // worldSt = new WorldStates();
            //patients = ResourceQueue.create("Patient", "", worldSt, FindAllGameObjectsWithTag("Patient"));
            //resources.Add("patients", patients);

            //cubicles = ResourceQueue.create("Cubicle", "FreeCubicle", worldSt, FindAllGameObjectsWithTag("Cubicle"));
            //resources.Add("cubicles", cubicles);

            //offices = ResourceQueue.create("Office", "FreeOffice", worldSt, FindAllGameObjectsWithTag("Office"));
            //resources.Add("offices", offices);

            //toilets = ResourceQueue.create("Toilet", "FreeToilet", worldSt, FindAllGameObjectsWithTag("Toilet"));
            //resources.Add("toilets", toilets);

            //wees = ResourceQueue.create("Wee", "FreeWee", worldSt, FindAllGameObjectsWithTag("Wee"));
            //resources.Add("wees", wees);

            //poos = ResourceQueue.create("Poo", "FreePoo", worldSt, FindAllGameObjectsWithTag("Poo"));
            //resources.Add("poos", poos);

            Time.timeScale = 5;
        }

        

        public ResourceQueue GetQueue(string type)
        {
            //if (resources.TryGetValue(type, out ResourceQueue rq))
            //    return rq;
            //else
            ////return resources[type];
            //return null;
            Predicate<ResourceQueue> checker = new Predicate<ResourceQueue>((ResourceQueue queue) => { return queue.tag == type; });
            return Array.Find(resourceQueues, checker );
        }

        //private World()
        //{ }
        public GameObject[] FindAllGameObjectsWithTag(string tag)
        {
            return GameObject.FindGameObjectsWithTag(tag);
        }

        //public static World Instance
        //{
        //    get { return instance; }
        //}


        public bool HasState(string key)
        {
            return states.ContainsKey(key);
        }

        void AddState(string key, int value)
        {
            states.Add(key, new WorldState(key,value));
        }

        public void AddBeliefState(string key)
        {
            states.Add(key, new WorldState(key, 0));
        }

        public void ModifyState(string key, int value)
        {
            if (states.ContainsKey(key))
            {
                states[key].value += value; // modify the value of that state by the amount in value
                if (states[key].value <= 0) // if the state has no values left, remove it
                    RemoveState(key);
            }
            else
                states.Add(key, new WorldState(key, value)); // if state doesn't exist then add it
        }

        public void RemoveState(string key)
        {
            if (states.ContainsKey(key))
                states.Remove(key);
        }

        public void SetState(string key, int value)
        {
            if (states.ContainsKey(key))
                states[key].value = value;
            else
                states.Add(key, new WorldState(key, value));
        }

        public Dictionary<string, WorldState> Getstates()
        {
            return states;
        }
    }
}