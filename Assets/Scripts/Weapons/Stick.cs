using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public float damage = 5f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire"))
            transform.Rotate(new Vector3(50, 0, 0));

        if (Input.GetButtonUp("Fire"))
            transform.Rotate(new Vector3(-50, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destructible desObj = other.transform.GetComponent<Destructible>();
        if (desObj != null)
        {
            desObj.TakeDamage(damage);
        }
    }
}
