using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour {

    private GameObject _gameController;
    private Items _items;

    public void Awake()
    {
        _gameController = GameObject.FindGameObjectWithTag(Tags.GameController);
        _items = _gameController.GetComponent<Items>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.Collectable))
        {
            // Get the type of the collected item
            CollectableType.Type type = other.GetComponent<CollectableType>().Collectable;
            switch(type)
            {
                case CollectableType.Type.Coin:
                    _items.CollectedCoins++;
                    break;
                case CollectableType.Type.Key:
                    _items.CollectedKeys++;
                    break;
                case CollectableType.Type.Hourglass:
                    _items.AddTime(15);
                    break;
            }
            Destroy(other.gameObject);
            print("collected");
        }

    }

}
