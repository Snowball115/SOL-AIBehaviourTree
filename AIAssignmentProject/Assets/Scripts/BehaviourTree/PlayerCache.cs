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

    public static void DebugAgents()
    {
        for (int i = 0; i < agents.Length; i++)
        {
            Debug.Log(agents[i].ToString());
        }
    }

    public static void DebugFlagCarriers()
    {
        //Debug.LogFormat("RED: {0}", RedFlagCarrier.name);
        //Debug.LogFormat("BLUE: {0}", BlueFlagCarrier.name);
    }

    public static void SetFlagCarriers(GameObject flag)
    {
        for (int i = 0; i < agents.Length; i++)
        {
            if (flag.name == Names.BlueFlag)
            {
                BlueFlagCarrier = agents[i].gameObject;
            }
            if (flag.name == Names.RedBase)
            {
                RedFlagCarrier = agents[i].gameObject;
            }
        }
    }
}
