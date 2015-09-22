//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PlayerWeaponWielding : MonoBehaviour
{
    private GameObject _currentWeapon;
    private GameObject _currentWeaponOverworld;
    public GameObject[] _weapons;

    void Awake ()
    {
        //Finds all the weapons on the player and puts them in the weapon array
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.tag == "RangedWeapon" || child.tag == "MeleeWeapon")
            {
                System.Array.Resize(ref _weapons, _weapons.Length + 1);
                _weapons[i] = (child.gameObject);
                i++;
            }
        }
    }
	
	void Update ()
    {
        //Player gets his fists out if he holds no other weapon
        if (_currentWeapon == null)
        {
            for (int i = 0; i < _weapons.Length; i++)
                if (_weapons[i].name == "Fist")
                {
                    _weapons[i].SetActive(true);
                    _currentWeapon = _weapons[i];
                }
        }

        //If the player already has a weapon, he can drop it and gain his fists back
        if (Input.GetKeyDown("g") && _currentWeapon != null && _currentWeapon.name != "Fist")
        {
            _currentWeapon.SetActive(false);
            _currentWeapon = null;
            _currentWeaponOverworld.transform.position = gameObject.transform.position;
            _currentWeaponOverworld.SetActive(true);
            _currentWeaponOverworld = null;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //If the player is standing on a weapon and presses the spacebar, he picks it up
        if (other.tag == "RangedWeapon" && Input.GetKeyDown("space") && _currentWeapon.name == "Fist" || other.tag == "MeleeWeapon" && Input.GetKeyDown("space") && _currentWeapon.name == "Fist")
        {
            _currentWeapon.SetActive(false);
            for (int i = 0; i < _weapons.Length; i++)
                if (_weapons[i].name == other.name)
                {
                    _weapons[i].SetActive(true);
                    _currentWeapon = _weapons[i];
                }
            _currentWeaponOverworld = other.gameObject;
            other.gameObject.SetActive(false);
        }
    }
}
