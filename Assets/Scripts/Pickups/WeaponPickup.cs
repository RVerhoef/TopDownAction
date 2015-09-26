using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour
{
    public int _ammo;

	void Awake ()
    {
	    if(transform.name == "Pistol")
        {
            _ammo = 12;
        }
        else if(transform.name == "Shotgun")
        {
            _ammo = 6;
        }
        else if(transform.name == "SMG")
        {
            _ammo = 30;
        }
    }
}
