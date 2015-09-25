//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class ShotgunWeapon : MonoBehaviour, IShootable
{
    private int _ammo = 6;
    private float _spreadLeft;
    private float _spreadRight;


    void Awake()
    {

    }

    void Update()
    {
        _spreadLeft = transform.eulerAngles.z + 10f;
        _spreadRight = transform.eulerAngles.z - 10f;

        //If the left mouse button is pressed a cone of bullets is fired until the ammo is used up
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if(_ammo > 0)
        { 
        Instantiate(Resources.Load("Prefabs/Weapons/Bullet"), transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, _spreadLeft));
        Instantiate(Resources.Load("Prefabs/Weapons/Bullet"), transform.position, transform.rotation);
        Instantiate(Resources.Load("Prefabs/Weapons/Bullet"), transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, _spreadRight));
        _ammo--;
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
}
