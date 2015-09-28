//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PlayerWeaponWielding : MonoBehaviour
{
    private GameObject _currentWeapon;
    private GameObject _currentWeaponOverworld;
    public GameObject[] weapons;
    public int currentAmmo;

    void Awake ()
    {
        //Finds all the weapons on the player and puts them in the weapon array
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.tag == "RangedWeapon" || child.tag == "MeleeWeapon")
            {
                System.Array.Resize(ref weapons, weapons.Length + 1);
                weapons[i] = (child.gameObject);
                i++;
            }
        }
    }
	
	void Update ()
    {
        //Player gets his fists out if he holds no other weapon
        if (_currentWeapon == null)
        {
            for (int i = 0; i < weapons.Length; i++)
                if (weapons[i].name == "Fist")
                {
                    weapons[i].SetActive(true);
                    _currentWeapon = weapons[i];
                }
        }
        //If the player already has a weapon, he can drop it and gain his fists back
        if (Input.GetKeyDown("g") && _currentWeapon != null && _currentWeapon.name != "Fist")
        {
            _currentWeapon.SetActive(false);
            _currentWeapon = null;
            _currentWeaponOverworld.transform.position = gameObject.transform.position;
            _currentWeaponOverworld.SetActive(true);
            _currentWeaponOverworld.GetComponent<WeaponPickup>()._ammo = currentAmmo;
            _currentWeaponOverworld = null;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //If the player is standing on a weapon and presses the spacebar, he picks it up
        if (other.tag == "RangedWeapon" && Input.GetKeyDown("space") && _currentWeapon.name == "Fist" || other.tag == "MeleeWeapon" && Input.GetKeyDown("space") && _currentWeapon.name == "Fist")
        {
            _currentWeapon.SetActive(false);
            for (int i = 0; i < weapons.Length; i++)
                if (weapons[i].name == other.name)
                {
                    weapons[i].SetActive(true);
                    _currentWeapon = weapons[i];
                }
            _currentWeaponOverworld = other.gameObject;
            currentAmmo = other.GetComponent<WeaponPickup>()._ammo;
            other.gameObject.SetActive(false);
        }
    }
}
