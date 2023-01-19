using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for the object pool.
public interface IPooledObject
{
    void OnObjectSpawn();
}
