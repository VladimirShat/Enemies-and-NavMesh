using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionRotation : MonoBehaviour
{
    public float angle;
    float angle1;
    public Vector3 v;
    Quaternion q;
    public GameObject go;

    void Update()
    {
        q = Quaternion.AngleAxis(angle, v);
        go.transform.rotation = go.transform.rotation * q;
    }
}
