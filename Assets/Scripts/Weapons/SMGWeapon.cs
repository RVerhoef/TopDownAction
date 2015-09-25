//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class SMGWeapon : MonoBehaviour
{
    [SerializeField]private GameObject _bullet;
    private int _ammoCounter = 30;
    private int _shotTimer;

    void Awake()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0) && _shotTimer == 0 && _ammoCounter > 0)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
            _shotTimer += 5;
            _ammoCounter--;
        }
        if (_shotTimer > 0)
        {
            _shotTimer--;
        }
    }
}
