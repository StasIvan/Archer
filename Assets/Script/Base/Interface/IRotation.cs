using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotation 
{
    void LookAtDirection(Transform thisTransform, Vector3 direction);
}
