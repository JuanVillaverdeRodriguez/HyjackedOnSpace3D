using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    private float health;
    private int pistolAmmo;
    private int ammoMagazine;
    private int grenadeAmmo;
    private float healthMax;
    private int pistolAmmoMax;
    private int grenadeAmmoMax;
    private int ammoMagazineMax;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI grenadeText;
    public TextMeshProUGUI ammoMaxText;
    public TextMeshProUGUI grenadeMaxText;
    public TextMeshProUGUI magazineText;
    

    private void Start()
    {
        healthMax = 100;
        pistolAmmoMax = 50;
        ammoMagazineMax = 500;
        grenadeAmmoMax = 10;
        health = 99;
        pistolAmmo = 49;
        grenadeAmmo = 9;
        ammoMagazine = 499;
        healthText.text = health.ToString();
        ammoText.text = pistolAmmo.ToString();
        grenadeText.text = grenadeAmmo.ToString();
        ammoMaxText.text = pistolAmmoMax.ToString();
        grenadeMaxText.text = grenadeAmmoMax.ToString();
        magazineText.text = ammoMagazine.ToString();
    }

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


}
