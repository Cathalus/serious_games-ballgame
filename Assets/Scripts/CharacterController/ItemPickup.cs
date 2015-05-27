using UnityEngine;
using System.Collections;

/// <summary>
/// Handles picking up items
/// </summary>
public class ItemPickup : MonoBehaviour {

    /// <summary>
    /// Key sound effect
    /// </summary>
    [SerializeField]
    private AudioClip SFX_Key;
    /// <summary>
    /// Hourglass sound effect
    /// </summary>
    [SerializeField]
    private AudioClip SFX_Hourglass;
    /// <summary>
    /// Coin sound effect
    /// </summary>
    [SerializeField]
    private AudioClip SFX_Coin;
    /// <summary>
    /// Reference to the GameController
    /// </summary>
    private GameObject _gameController;
    /// <summary>
    /// Reference to the Items script
    /// </summary>
    private CollectableItems _items;
    /// <summary>
    /// Reference to the Level Controller
    /// </summary>
    private LevelController _levelController;

    public void Awake()
    {
        _gameController = GameObject.FindGameObjectWithTag(Tags.GameController);
        _items = _gameController.GetComponent<CollectableItems>();
        _levelController = _gameController.GetComponent<LevelController>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Checks if the object that was hit is collectable and reacts accordingly
        // Destroys the collectable object
        if(other.CompareTag(Tags.Collectable))
        {
            // Get the type of the collected item
            CollectableType.Type type = other.GetComponent<CollectableType>().Collectable;
            switch(type)
            {
                case CollectableType.Type.Coin:
                    _items.CollectedCoins++;
                    AudioSource.PlayClipAtPoint(SFX_Coin, other.transform.position);
                    break;
                case CollectableType.Type.Key:
                    _items.CollectedKeys++;
                    AudioSource.PlayClipAtPoint(SFX_Key, other.transform.position);
                    break;
                case CollectableType.Type.Hourglass:
                    _levelController.AddTime(15);
                    _items.CollectedHourglasses++;
                    AudioSource.PlayClipAtPoint(SFX_Hourglass, other.transform.position);
                    break;
            }
            Destroy(other.gameObject);
        }

    }

}
