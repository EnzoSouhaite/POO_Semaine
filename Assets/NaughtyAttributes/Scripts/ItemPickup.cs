using NaughtyAttributes;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Appuyez sur E pour ramasser " + itemName);
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.SetCurrentItem(this);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ClearCurrentItem();
            }
        }
    }

    public void Pickup()
    {
        Debug.Log("Vous avez ramassé : " + itemName);
        Destroy(gameObject);
    }
}

