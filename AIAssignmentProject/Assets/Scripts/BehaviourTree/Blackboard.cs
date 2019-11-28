using System.Collections.Generic;
using UnityEngine;

public static class Blackboard
{
    private static Dictionary<string, object> blackboardData = new Dictionary<string, object>();

    public static void DebugDict()
    {
        foreach (KeyValuePair<string, object> entry in blackboardData)
        {
            Debug.Log(string.Format("{0} {1}", entry.Key, entry.Value));
        }
    }

    public static void AddData(string key, object value)
    {
        if (!ContainsKey(key)) blackboardData.Add(key, value);
        else Debug.Log("[BLACKBOARD] Can't add Key that already exists! Consider using ModifyData() instead.");
    }

    public static void RemoveData(string key)
    {
        if (ContainsKey(key)) blackboardData.Remove(key);
        else Debug.Log("[BLACKBOARD] No key to remove!");
    }

    // Modify an existing value of key
    public static void ModifyData(string key, object newValue)
    {
        blackboardData[key] = newValue;
    }

    // Get value from key
    public static object GetData(string key)
    {
        object tmp = null;

        if (blackboardData.TryGetValue(key, out tmp))
        {
            return tmp;
        }

        Debug.Log("[BLACKBOARD] Data not found");
        return tmp;
    }

    // Check if key in dictionary already exists
    private static bool ContainsKey(string key)
    {
        object tmp = null;
        return blackboardData.TryGetValue(key, out tmp);
    }
}