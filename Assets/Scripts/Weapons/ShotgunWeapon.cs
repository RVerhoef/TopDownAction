//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class ShotgunWeapon : MonoBehaviour, IShootable
{
    private int _ammo = 6;
    private float _spreadLeft;
    private float _spreadRight;
    private Transform _muzzle;


    void Awake()
    {
        _muzzle = transform.FindChild("Muzzle");
    }

    void Update()
    {
        //The shotgun fires in a cone, the exact width of which is determined by the spread
        _spreadLeft = transform.eulerAngles.z + 10f;
        _spreadRight = transform.eulerAngles.z - 10f;

        //If the left mouse button is pressed a cone of bullets is fired until the ammo is used up, after which the weapon will make a "click" sound
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if(_ammo > 0)
        { 
        Instantiate(Resources.Load("Prefabs/Weapons/Bullet"), _muzzle.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, _spreadLeft));
        Instantiate(Resources.Load("Prefabs/Weapons/Bullet"), _muzzle.position, transform.rotation);
        Instantiate(Resources.Load("Prefabs/Weapons/Bullet"), _muzzle.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, _spreadRight));
        _ammo--;
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
}
