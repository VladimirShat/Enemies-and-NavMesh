using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardsTrigger : MonoBehaviour
{
    public List<GameObject> guards;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach(GameObject g in guards)
                g.GetComponent<Guard>().enabled = true;
        }
    }
}
