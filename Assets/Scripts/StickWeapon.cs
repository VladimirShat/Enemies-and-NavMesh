using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickWeapon : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public float damage = 5f;
    public Material hitMaterial;

    private Material originalMaterial;

    private void Update()
    {
        if (Input.GetButtonDown("Fire"))
            transform.Rotate(new Vector3(50, 0, 0));

        if (Input.GetButtonUp("Fire"))
            transform.Rotate(new Vector3(-50, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            GameObject go = other.gameObject;
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            originalMaterial = mr.material;
            mr.material = hitMaterial;
            Enemy enemyHP = go.GetComponent<Enemy>();
            enemyHP.TakeDamage(damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            GameObject go = other.gameObject;
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            mr.material = originalMaterial;
        }
    }
}
