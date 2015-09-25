//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class SMGWeapon : MonoBehaviour, IShootable
{
    private int _ammo = 30;
    private int _shotTimer;

    void Awake()
    {

    }

    void Update()
    {
        //If the left mouse button is pressed a stream of bullets is fired until the ammo is used up
        if (Input.GetMouseButton(0) && _shotTimer == 0)
        {
            Shoot();
        }

        if (_shotTimer > 0)
        {
            _shotTimer--;
        }
    }

    public void Shoot()
    {
        if(_ammo > 0)
        {
        Instantiate(Resources.Load("Prefabs/Weapons/Bullet"), transform.position, transform.rotation);
        _shotTimer += 5;
        _ammo--;
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
}
