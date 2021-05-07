using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GOAP
{
    [System.Serializable]
    public class ResourceQueue
    {
        public List<GameObject> gameObjectsWithTag;
        public string tag;
        public string modState;

        public static ResourceQueue create(string a_tag, string a_modState, Dictionary<string, WorldState> a_worldStates, GameObject[] gameObjectsInQueue)
        {
            ResourceQueue newResourceQueue = new ResourceQueue();
            newResourceQueue.tag = a_tag;
            newResourceQueue.modState = a_modState;
            //if (tag != "")
           // {
                //GameObject[] resources = World.Instance.FindAllGameObjectsWithTag(tag);
                foreach (GameObject r in gameObjectsInQueue)
                {
                    newResourceQueue.gameObjectsWithTag.Add(r);
                }

                if (newResourceQueue.modState != "")
                {
                if (a_worldStates.TryGetValue(newResourceQueue.modState, out WorldState value))
                    value.ModifyState(newResourceQueue.gameObjectsWithTag.Count);
                   // a_worldStates[newResourceQueue.modState].ModifyState(newResourceQueue.queue.Count);
                }
            //}
            return newResourceQueue;
        }

        public void AddResource(GameObject a_resource)
        {
            gameObjectsWithTag.Add(a_resource);
        }

        public void RemoveResource(GameObject a_resource)
        {
            // create a new queue and copy over values from the old queue, but leave out a_resource so we can remove it
            gameObjectsWithTag = new List<GameObject>(gameObjectsWithTag.Where(p => p != a_resource));
        }

        public GameObject RemoveResource()
        {
            if (gameObjectsWithTag.Count == 0) return null;
            GameObject gObj = gameObjectsWithTag[0];
            gameObjectsWithTag.RemoveAt(0);
            return gObj;
        }
    }
}
