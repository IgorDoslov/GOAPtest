using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GOAP
{
    public class SubGoal
    {
        public Dictionary<string, int> subGoals;
        public bool remove;

        public SubGoal(string s, int i, bool r)
        {
            subGoals = new Dictionary<string, int>();
            subGoals.Add(s, i);
            remove = r;
        }
    }
    [System.Serializable]
    public class Goal
    {
        public string goal;
        public int value;
        public bool shouldRemove;
        public int priority;
    }

    public class Agent : MonoBehaviour
    {
        public List<Action> actions = new List<Action>();
        public Dictionary<SubGoal, int> goalsDic = new Dictionary<SubGoal, int>();
        public Inventory inventory = new Inventory();
        public Dictionary<string, WorldState> beliefs = new Dictionary<string, WorldState>();
        public float distanceToTargetThreshold = 2f;
        public Goal[] myGoals;
        Planner planner;
        Queue<Action> actionQueue;
        public Action currentAction;
        SubGoal currentGoal;


        // Start is called before the first frame update
        public virtual void Start()
        {
            Action[] acts = this.GetComponents<Action>();
            foreach (Action a in acts)
                actions.Add(a);
            for (int i = 0; i < myGoals.Length; i++)
            {
                Goal g = myGoals[i];
                SubGoal sg = new SubGoal(g.goal, g.value, g.shouldRemove);
                goalsDic.Add(sg, g.priority);
            }
        }

        bool invoked = false;
        void CompleteAction()
        {
            currentAction.running = false;
            currentAction.ExitAction();
            invoked = false;
        }

        // Update is called once per frame
        public virtual void LateUpdate()
        {
            if (currentAction != null && currentAction.running)
            {
                float distToTarget = Vector3.Distance(currentAction.vec3Destination, transform.position);
                if (distToTarget < distanceToTargetThreshold)
                {
                    if (!invoked)
                    {
                        Invoke("CompleteAction", currentAction.duration);
                        invoked = true;
                    }
                }
                return;
            }

            if (planner == null || actionQueue == null)
            {
                planner = new Planner();

                var sortedGoals = from entry in goalsDic orderby entry.Value descending select entry;

                foreach (KeyValuePair<SubGoal, int> sg in sortedGoals)
                {
                    actionQueue = planner.Plan(actions, sg.Key.subGoals, beliefs); // trying to create a plan for the most important goal
                    if (actionQueue != null)
                    {
                        currentGoal = sg.Key;
                        break;
                    }
                }
            }
            if (actionQueue != null && actionQueue.Count == 0)
            {
                if (currentGoal.remove)
                {
                    goalsDic.Remove(currentGoal);
                }
                planner = null;
            }
            // sets our action and gets the target
            if (actionQueue != null && actionQueue.Count > 0)
            {
                currentAction = actionQueue.Dequeue(); // remove the action from the queue and make it the current action
                if (currentAction.EnterAction())
                {
                    if (currentAction.gameObjTarget == null && currentAction.targetTag != "") // Doesnt have a target but has a target tag
                        currentAction.gameObjTarget = GameObject.FindWithTag(currentAction.targetTag); // Set the target to what is tagged

                    if (currentAction.gameObjTarget != null) // if I have a target
                    {
                        currentAction.running = true;

                        currentAction.vec3Destination = currentAction.gameObjTarget.transform.position;
                        Transform dest = currentAction.gameObjTarget.transform.Find("Destination");
                        if (dest != null)
                        {
                            currentAction.vec3Destination = dest.position;
                        }

                        currentAction.navAgent.SetDestination(currentAction.vec3Destination);
                    }
                }
                else
                {
                    actionQueue = null; // go get a new plan
                }
            }

        }

        public void StopAction()
        {
            currentAction.running = false;
            currentAction = null;
            actionQueue = null;
        }
    }
}