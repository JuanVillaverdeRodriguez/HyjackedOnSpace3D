using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                //playerInventory.Heal(2);
                gameObject.SetActive(false);
            }
        }
    }
}
