using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMonitor : MonoBehaviour
{
    public string state;
    public float stateStrength;
    public float stateDecayRate;
    public WorldStates beliefs;
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

        if (!stateFound && beliefs.HasState(state))
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
                beliefs.RemoveState(state);
                World.Instance.GetQueue(queueName).AddResource(p);
                World.Instance.GetWorld().ModifyState(worldState, 1);
            }
        }
    }
}
