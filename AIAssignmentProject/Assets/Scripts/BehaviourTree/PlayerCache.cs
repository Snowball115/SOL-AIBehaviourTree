using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Little hack to determine which agent is carrying a flag
public static class PlayerCache
{
    public static GameObject BlueFlagCarrier;
    public static GameObject RedFlagCarrier;

    private static AI[] agents = GetAllAgents();
    private static AgentData data;

    public static AI[] GetAllAgents()
    {
        return GameObject.FindObjectsOfType<AI>();
    }

    public static void SetFlagCarriers()
    {
        for (int i = 0; i < agents.Length; i++)
        {
            if (data.)
        }
    }
}
