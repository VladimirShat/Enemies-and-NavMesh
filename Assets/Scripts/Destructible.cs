using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float health = 100f;
    public GameObject destructionPrefab;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Destruction();
        }
    }

    void Destruction()
    {
        if(destructionPrefab != null)
        {
            Instantiate(destructionPrefab, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
