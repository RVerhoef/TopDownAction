﻿//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PistolWeapon : MonoBehaviour, IShootable
{
    private Transform _muzzle;

    void Awake ()
    {
        _muzzle = transform.FindChild("Muzzle");
    }
	
	void Update ()
    {
        //If the left mouse button is pressed a single bullet is fired until the ammo is used up, after which the weapon will make a "click" sound
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}

    public void Shoot()
    {
        if(transform.parent.GetComponent<PlayerWeaponWielding>().currentAmmo > 0)
        { 
            Instantiate(Resources.Load("Prefabs/Weapons/Bullet"), _muzzle.position, transform.rotation);
            transform.parent.GetComponent<PlayerWeaponWielding>().currentAmmo--;
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
}
