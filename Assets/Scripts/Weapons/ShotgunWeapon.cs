using UnityEngine;
using System.Collections;

public class ShotgunWeapon : MonoBehaviour
{
    [SerializeField]private GameObject _bullet;
    public Transform parent;

    void Awake()
    {
        parent = transform.parent;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_bullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, parent.transform.rotation.z + 15));
            Instantiate(_bullet, transform.position, transform.rotation);
            Instantiate(_bullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, parent.transform.rotation.z - 15));
        }
    }
}
