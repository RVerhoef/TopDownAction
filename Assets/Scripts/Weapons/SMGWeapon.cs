//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class SMGWeapon : MonoBehaviour, IShootable
{
    private int _shotTimer;
    private Transform _muzzle;

    void Start()
    {
        _muzzle = transform.FindChild("Muzzle");
    }

    void Update()
    {
        //If the left mouse button is pressed a stream of bullets is fired until the ammo is used up, after which the weapon will make a "click" sound
        if (Input.GetMouseButton(0) && _shotTimer == 0)
        {
            Shoot();
        }
        //The SMG has a rapid rate of fire, the exact speed of which is determinend by a timer
        if (_shotTimer > 0)
        {
            _shotTimer--;
        }
    }

    public void Shoot()
    {
        if (transform.parent.GetComponent<PlayerWeaponWielding>().currentAmmo > 0)
        {
        Instantiate(Resources.Load("Prefabs/Weapons/Bullet"), _muzzle.position, transform.rotation);
        _shotTimer += 5;
            transform.parent.GetComponent<PlayerWeaponWielding>().currentAmmo--;
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
}
