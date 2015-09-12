using UnityEngine;
using System.Collections;

public interface ISwingable<T>
{
    void Swing(T damage);
}
