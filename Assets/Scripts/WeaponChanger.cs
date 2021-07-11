using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    public GameObject[] weapons;

    private GameObject currentWeapon;

    void Start()
    {
        foreach (var weapon in weapons)
        {
            weapon.SetActive(false);
        }

        weapons[0].SetActive(true);
        currentWeapon = weapons[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(weapons[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(weapons[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeapon(weapons[2]);
        }
    }

    private void ChangeWeapon(GameObject needWeapon)
    {
        currentWeapon.SetActive(false);
        needWeapon.SetActive(true);
        currentWeapon = needWeapon;
    }
}
