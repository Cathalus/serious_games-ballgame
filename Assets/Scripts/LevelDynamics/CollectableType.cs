using UnityEngine;
using System.Collections;

public class CollectableType : MonoBehaviour {
    /// <summary>
    /// Type of the collectable
    /// </summary>
    public enum Type { Coin, Key, Hourglass };
    
    public Type Collectable = Type.Coin;

}
