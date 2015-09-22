//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PistolWeapon : MonoBehaviour
{
    [SerializeField]private GameObject _bullet;
    private int _ammoCounter = 12;

    void Awake ()
    {
       
    }
	
	void Update ()
    {
        if(Input.GetMouseButtonDown(0) && _ammoCounter > 0)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
            _ammoCounter--;
        }
	}
}
