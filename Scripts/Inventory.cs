using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int hasHat;
    public int seedCount;

    public bool PickupItem(gameObject)
    {
        switch(obj.tag)
        {
            case "Currency":
                seedCount++;
                return true;
            default:
                Debug.LogWarning($"WARNING: No handler implemented for tag {obj.tag}.");
                return false;
        }
    }
}
