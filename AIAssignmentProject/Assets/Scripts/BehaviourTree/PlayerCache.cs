using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Little hack to determine which agent is carrying a flag
public static class PlayerCache
{
    private static GameObject blueFlagCarrier;
    private static GameObject redFlagCarrier;

    // Look if agent is in blue or red team
    public static GameObject GetEnemyFlagCarrier(GameObject baseComparison)
    {
        if (baseComparison != null)
        {
            switch (baseComparison.name)
            {
                case Names.RedBase:
                    return GetBlueFlagCarrier();
                case Names.BlueBase:
                    return GetRedFlagCarrier();
            }
        }

        return null;
    }

    public static void SetBlueFlagCarrier(GameObject carrier)
    {
        if (carrier != null)
            blueFlagCarrier = carrier;
        else blueFlagCarrier = null;
    }

    public static void SetRedFlagCarrier(GameObject carrier)
    {
        if (carrier != null)
            redFlagCarrier = carrier;
        else redFlagCarrier = null;
    }

    public static GameObject GetBlueFlagCarrier()
    {
        return blueFlagCarrier;
    }

    public static GameObject GetRedFlagCarrier()
    {
        return redFlagCarrier;
    }
}
