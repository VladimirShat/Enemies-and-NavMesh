using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHP : MonoBehaviour
{
    public Image bar;
    public float hp;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        hp = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = hp;
        if (bar.fillAmount == 0 && !isDead)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Guard>().enabled = false;
            transform.Rotate(new Vector3(90, 0, 0));
            isDead = true;
        }
    }
}
