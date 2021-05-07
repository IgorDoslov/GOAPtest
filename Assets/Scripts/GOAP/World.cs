using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GOAP
{
    public class ResourceQueue
    {
        public Queue<GameObject> queue = new Queue<GameObject>();
        public string tag;
        public string modState;

        public ResourceQueue(string a_tag, string a_modState, WorldStates a_worldStates)
        {
            tag = a_tag;
            modState = a_modState;
            if (tag != "")
            {
                GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);
                foreach (GameObject r in resources)
                {
                    queue.Enqueue(r);
                }

                if (modState != "")
                {
                    a_worldStates.ModifyState(modState, queue.Count);
                }
            }
        }

        public void AddResource(GameObject a_resource)
        {
            queue.Enqueue(a_resource);
        }

        public void RemoveResource(GameObject a_resource)
        {
            // create a new queue and copy over values from the old queue, but leave out a_resource so we can remove it
            queue = new Queue<GameObject>(queue.Where(p => p != a_resource));
        }

        public GameObject RemoveResource()
        {
            if (queue.Count == 0) return null;
            return queue.Dequeue();
        }
    }

    public sealed class World
    {
        private static readonly World instance = new World();
        private static WorldStates worldSt;
        private static ResourceQueue patients;
        private static ResourceQueue cubicles;
        private static ResourceQueue offices;
        private static ResourceQueue toilets;
        private static ResourceQueue wees;
        private static ResourceQueue poos;
        private static Dictionary<string, ResourceQueue> resources = new Dictionary<string, ResourceQueue>();

        static World()
        {
            worldSt = new WorldStates();
            patients = new ResourceQueue("", "", worldSt);
            resources.Add("patients", patients);

            cubicles = new ResourceQueue("Cubicle", "FreeCubicle", worldSt);
            resources.Add("cubicles", cubicles);

            offices = new ResourceQueue("Office", "FreeOffice", worldSt);
            resources.Add("offices", offices);

            toilets = new ResourceQueue("Toilet", "FreeToilet", worldSt);
            resources.Add("toilets", toilets);

            wees = new ResourceQueue("Wee", "FreeWee", worldSt);
            resources.Add("wees", wees);

            poos = new ResourceQueue("Poo", "FreePoo", worldSt);
            resources.Add("poos", poos);

            Time.timeScale = 5;
        }

        public ResourceQueue GetQueue(string type)
        {
            return resources[type];
        }

        private World()
        { }


        public static World Instance
        {
            get { return instance; }
        }

        public WorldStates GetWorld()
        {
            return worldSt;
        }

    }
}