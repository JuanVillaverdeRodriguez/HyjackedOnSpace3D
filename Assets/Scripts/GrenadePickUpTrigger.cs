using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePickUpTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.GetGrenades(2);
                gameObject.SetActive(false);
            }
        }
    }
}