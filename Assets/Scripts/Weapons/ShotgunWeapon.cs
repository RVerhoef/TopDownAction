//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class ShotgunWeapon : MonoBehaviour
{
    [SerializeField]private GameObject _bullet;
    private int _ammoCounter = 6;
    private float _spread;

    void Awake()
    {

    }

    void Update()
    {
        _spread = transform.rotation.z;
        
        if (Input.GetMouseButtonDown(0) && _ammoCounter > 0)
        {
            Instantiate(_bullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
            Debug.Log(transform.rotation);
            //Instantiate(_bullet, transform.position, transform.rotation);
            //Instantiate(_bullet, transform.position, Quaternion.Euler(transform.rotation.z, transform.rotation.x, transform.rotation.y));
            Debug.Log(transform.rotation);
            _ammoCounter--;
        }
    }
}
