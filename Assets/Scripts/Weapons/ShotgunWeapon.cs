using UnityEngine;
using System.Collections;

public class ShotgunWeapon : MonoBehaviour
{
    public GameObject _bullet;

    void Start()
    {

    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_bullet, transform.position, Quaternion.Euler(0, 0, transform.rotation.z + 15));
            Instantiate(_bullet, transform.position, transform.rotation);
            Instantiate(_bullet, transform.position, Quaternion.Euler(0, 0, transform.rotation.z - 15));
        }
    }
}
