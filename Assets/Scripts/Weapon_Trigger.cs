using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Trigger : MonoBehaviour
{
    public string hitTag;
    public Material hitMaterial;
    private Material originalMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject go = other.gameObject;
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            originalMaterial = mr.material;
            mr.material = hitMaterial;
            EnemyHP enemyHP = go.GetComponent<EnemyHP>();
            enemyHP.hp -= 0.1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject go = other.gameObject;
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            mr.material = originalMaterial;
        }
    }
}
