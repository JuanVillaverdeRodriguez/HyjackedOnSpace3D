using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantDeath : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    [SerializeField]
    public GameObject pasarela;
    [SerializeField]
    public Transform respawnPoint;
   
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            //Player.transform.position = respawnPoint.position;
            //other.transform.position = respawnPoint.position;
        }else{
            Destroy(other.gameObject);
            //pasarela.transform.eulerAngles = new Vector3(0f, -90f, 0f);
        }
    }
}
