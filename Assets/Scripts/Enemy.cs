using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Image healthBar;
    public float health = 100f;
    private bool isDead = false;

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / 100f;

        if (health <= 0f && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Guard>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        transform.Rotate(new Vector3(90, 0, 0));
        isDead = true;
    }
}
