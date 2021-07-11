using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionRotation : MonoBehaviour
{
    public float angle;
    public Vector3 axisRotation;

    private Quaternion q;

    void Update()
    {
        q = Quaternion.AngleAxis(angle, axisRotation);
        transform.rotation = transform.rotation * q;
    }
}
