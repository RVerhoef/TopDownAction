//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class ShotgunWeapon : MonoBehaviour
{
    [SerializeField]private GameObject _bullet;
    private int _ammoCounter = 6;
    private float _spreadLeft;
    private float _spreadRight;


    void Awake()
    {

    }

    void Update()
    {
        _spreadLeft = transform.eulerAngles.z + 10f;
        _spreadRight = transform.eulerAngles.z - 10f;

        if (Input.GetMouseButtonDown(0) && _ammoCounter > 0)
        {
            Instantiate(_bullet, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, _spreadLeft));
            Instantiate(_bullet, transform.position, transform.rotation);
            Instantiate(_bullet, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, _spreadRight));
            _ammoCounter--;
        }
    }
}
