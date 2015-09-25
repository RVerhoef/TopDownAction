//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PistolWeapon : MonoBehaviour, IShootable
{
    private int _ammo = 12;

    void Awake ()
    {
       
    }
	
	void Update ()
    {
        //If the left mouse button is pressed a single bullet is fired until the ammo is used up
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}

    public void Shoot()
    {
        if(_ammo > 0)
        { 
            Instantiate(Resources.Load("Prefabs/Weapons/Bullet"), transform.position, transform.rotation);
            _ammo--;
            Debug.Log(_ammo);
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
}
