//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace GOAP
//{
//    [System.Serializable]
//    public class WorldState
//    {
//        public string key;
//        public int value;
//    }

//    public class WorldStates
//    {
//        public Dictionary<string, int> states;

//        public WorldStates()
//        {
//            states = new Dictionary<string, int>();
//        }

//        public bool HasState(string key)
//        {
//            return states.ContainsKey(key);
//        }

//        void AddState(string key, int value)
//        {
//            states.Add(key, value);
//        }

//        public void AddBeliefState(string key)
//        {
//            states.Add(key, 0);
//        }

//        public void ModifyState(string key, int value)
//        {
//            if (states.ContainsKey(key))
//            {
//                states[key] += value; // modify the value of that state by the amount in value
//                if (states[key] <= 0) // if the state has no values left, remove it
//                    RemoveState(key);
//            }
//            else
//                states.Add(key, value); // if state doesn't exist then add it
//        }

//        public void RemoveState(string key)
//        {
//            if (states.ContainsKey(key))
//                states.Remove(key);
//        }

//        public void SetState(string key, int value)
//        {
//            if (states.ContainsKey(key))
//                states[key] = value;
//            else
//                states.Add(key, value);
//        }

//        public Dictionary<string, int> Getstates()
//        {
//            return states;
//        }
//    }
//}