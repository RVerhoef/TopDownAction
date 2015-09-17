//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public interface IShootable<T,U>
{
    void Shoot(T damage, U ammo);
}
