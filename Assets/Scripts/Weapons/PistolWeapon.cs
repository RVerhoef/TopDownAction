//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PistolWeapon : MonoBehaviour
{
    public GameObject _bullet;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(_bullet, transform.position, transform.rotation);
        }
	}
}
