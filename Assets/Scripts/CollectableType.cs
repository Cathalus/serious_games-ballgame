using UnityEngine;
using System.Collections;

public class CollectableType : MonoBehaviour {

    public enum Type { Coin, Key, Hourglass };
    
    public Type Collectable = Type.Coin;

}
