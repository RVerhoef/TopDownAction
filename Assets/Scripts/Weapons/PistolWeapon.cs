//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PistolWeapon : MonoBehaviour
{
    [SerializeField]private GameObject _bullet;

	void Awake ()
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
