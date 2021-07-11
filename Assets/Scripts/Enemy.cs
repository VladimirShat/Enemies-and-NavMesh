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
    public Material hitMaterial;

    private Material originalMaterial;
    private MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        originalMaterial = mr.sharedMaterial;
    }

    public void TakeDamage(float amount)
    {
        if (!isDead)
        {
            health -= amount;
            healthBar.fillAmount = health / 100f;

            mr.sharedMaterial = hitMaterial;
            StartCoroutine(HitCoroutine());

            if (health <= 0f)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Guard>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        transform.Rotate(new Vector3(90, 0, 0));
        isDead = true;
    }

    private IEnumerator HitCoroutine()
    {
        yield return new WaitForSeconds(1);

        if(mr.sharedMaterial == hitMaterial)
        {
            mr.sharedMaterial = originalMaterial;
        }
    }
}
