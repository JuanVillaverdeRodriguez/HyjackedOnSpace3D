using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(IDamageable))]
public class PlayerDeath : MonoBehaviour
{
    public IDamageable Damageable;

    private void Awake()
    {
        Damageable = GetComponent<IDamageable>();
    }
    private void OnEnable()
    {
        Damageable.OnDeath += Player_OnDeath;
    }

    private void Player_OnDeath(Vector3 Position)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
