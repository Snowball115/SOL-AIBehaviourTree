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
    public static GameObject GetFlagCarrier(GameObject baseComparison)
    {
        switch (baseComparison.name)
        {
            case Names.RedBase:
                return GetBlueFlagCarrier();
            case Names.BlueBase:
                return GetRedFlagCarrier();
        }

        return null;
    }

    public static void SetBlueFlagCarrier(GameObject carrier)
    {
        blueFlagCarrier = carrier;
    }

    public static void SetRedFlagCarrier(GameObject carrier)
    {
        redFlagCarrier = carrier;
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
