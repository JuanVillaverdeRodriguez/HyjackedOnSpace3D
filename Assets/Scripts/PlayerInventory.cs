using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    //[SerializeField]
    //public PlayerHealth playerHealth;
    [SerializeField]
    public GunSelector gunSelector;
    [SerializeField]
    public PlayerHealth playerHealth;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI AmmoText;

/*
    private void Awake()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        AmmoText= GetComponent<TextMeshProUGUI>();
    }*/

    private void Update()
    {
        
        healthText.SetText(
            $"{playerHealth.CurrentHealth}"
        );

        AmmoText.SetText(
            $"{gunSelector.ActiveGun.AmmoConfig.CurrentClipAmmo} / "+
            $"{gunSelector.ActiveGun.AmmoConfig.CurrentAmmo}"
        );
    }
    /*
    public void Heal(int heal_num)
    {
        Debug.Log("Curado: " + heal_num);
        health += heal_num;
        if (health > healthMax)
        {
            health = healthMax;
        }
        healthText.text = health.ToString();
    }

    public void Damage(int damage_num)
    {
        Debug.Log("Curado: " + damage_num);
        health -= damage_num;
        healthText.text = health.ToString();
    }

    public void GetAmmo(int ammo_num)
    {
        Debug.Log("Ammo: " + ammo_num);
        ammoMagazine += ammo_num;
        if (ammoMagazine > ammoMagazineMax)
        {
            ammoMagazine = ammoMagazineMax;
        }
        magazineText.text = ammoMagazine.ToString();
        ammoText.text = pistolAmmo.ToString();
    }

    public void Reload()
    {
        Debug.Log("Reload");
        int reloadAmmo = pistolAmmoMax - pistolAmmo;
        if (reloadAmmo > ammoMagazine) 
        {
            pistolAmmo += ammoMagazine;
            ammoMagazine = 0;
        } else
        {
            pistolAmmo = pistolAmmoMax;
            ammoMagazine -= reloadAmmo;
        }
        magazineText.text = ammoMagazine.ToString();
        ammoText.text = pistolAmmo.ToString();
    }

    public void UseAmmo(int ammo_num)
    {
        Debug.Log("Ammo: " + ammo_num);
        pistolAmmo -= ammo_num;
        ammoText.text = pistolAmmo.ToString();
    }

    public void GetGrenades(int grenades_num)
    {
        Debug.Log("Grenades: " + grenades_num);
        grenadeAmmo += grenades_num;
        if (grenadeAmmo > grenadeAmmoMax)
        {
            grenadeAmmo = grenadeAmmoMax;
        }
        grenadeText.text = grenadeAmmo.ToString();
    }
    public void UseGrenades(int grenades_num)
    {
        Debug.Log("Grenades: " + grenades_num);
        grenadeAmmo -= grenades_num;
        grenadeText.text = grenadeAmmo.ToString();
    }
*/

}
