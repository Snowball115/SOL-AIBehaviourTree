using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ********************
// Class that provides info about which agent is carrying a flag for other agents to use
// ********************
public static class PlayerCache
{
    public static GameObject BlueFlagCarrier;
    public static GameObject RedFlagCarrier;

    private static AI[] agents = GetAllAgents();
    private static AgentData data;

    // Cache all agents that are in the scene
    public static AI[] GetAllAgents()
    {
        return GameObject.FindObjectsOfType<AI>();
    }
    
    // Set blue or red flag carrier corresponding to the flag the agent carries
    public static void SetFlagCarriers(GameObject flag)
    {
        for (int i = 0; i < agents.Length; i++)
        {
            if (flag.name == Names.BlueFlag)
            {
                BlueFlagCarrier = agents[i].gameObject;
            }
            else if (flag.name == Names.RedFlag)
            {
                RedFlagCarrier = agents[i].gameObject;
            }
        }
    }

    // Determine if carrier is friendly or not
    public static GameObject GetEnemyFlagCarrier(AI agent)
    {
        string friendlyFlag = agent._agentData.FriendlyFlagName;
        string friendlyTeam = agent._agentData.FriendlyTeamTag;

        for (int i = 0; i < agents.Length; i++)
        {
            // Team != Same team AND Flag carried = FriendlyFlag ==>> Enemy
            if (agents[i]._agentData.FriendlyTeamTag != friendlyTeam && agents[i]._agentInventory.HasItem(friendlyFlag))
            {
                return agents[i].gameObject;
            }
        }

        return null;
    } 

    public static void DebugAgents()
    {
        for (int i = 0; i < agents.Length; i++)
        {
            Debug.Log(agents[i].ToString());
        }
    }

    public static void DebugFlagCarriers()
    {
        if (BlueFlagCarrier != null) Debug.LogFormat("BLUE: {0}", BlueFlagCarrier.name);
        if (RedFlagCarrier != null) Debug.LogFormat("RED: {0}", RedFlagCarrier.name);
    }
}
