using UnityEngine;
using System.Collections;

/// <summary>
/// Stores which items can be collected in the level
/// </summary>
public class CollectableItems : MonoBehaviour {

    /// <summary>
    /// Number of Keys that are available in the level
    /// </summary>
    public int AvailableKeys = 0;
    /// <summary>
    /// Number of Keys that were collected by the player
    /// </summary>
    public int CollectedKeys = 0;
    /// <summary>
    /// Number of coins that are available in the level
    /// </summary>
    public int AvailableCoins = 0;
    /// <summary>
    /// Number of coins that were collected by the player
    /// </summary>
    public int CollectedCoins = 0;
    /// <summary>
    /// Number of Hourglasses available in the level
    /// </summary>
    public int AvailableHourglasses = 0;
    /// <summary>
    /// Number of Hourglasses collected by the player
    /// </summary>
    public int CollectedHourglasses = 0;

    /// <summary>
    /// Checks if all available keys were collected
    /// </summary>
    /// <returns>Returns true when all aviablable keys were collected</returns>
    public bool RequiredKeysCollected()
    {
        return CollectedKeys >= AvailableKeys;
    }

}
