using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour
{
    private Dictionary<string, object> blackboardData;

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        Debug.Log("[BLACKBOARD] Initialization");
        blackboardData = new Dictionary<string, object>();

        // Add predefined key value pairs here
        AddData("test", 123);
        GetData("test");
        ModifyData("test", 564);
        GetData("test");
    }

    public void AddData(string key, object value)
    {
        if (!ContainsKey(key)) blackboardData.Add(key, value);
        else Debug.Log("[BLACKBOARD] Can't add Key that already exists! Consider using ModifyData() instead.");
    }

    public void RemoveData(string key)
    {
        if (ContainsKey(key)) blackboardData.Remove(key);
        else Debug.Log("[BLACKBOARD] No key to remove!");
    }

    // Modify an existing value of key
    public void ModifyData(string key, object newValue)
    {
        blackboardData[key] = newValue;
    }

    // Gives value from key back
    public object GetData(string key)
    {
        object tmp = null;

        if (blackboardData.TryGetValue(key, out tmp))
        {
            //Debug.Log(tmp);
            return tmp;
        }

        Debug.Log("[BLACKBOARD] Data not found");
        return tmp;
    }

    // Check if key in dictionary already exists
    private bool ContainsKey(string key)
    {
        object tmp = null;
        return blackboardData.TryGetValue(key, out tmp);
    }
}