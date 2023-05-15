using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepondHandeler : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private Transform weaponParent;
    [SerializeField] private GameObject currentWeapon;
   void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Equip(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Equip(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Equip(2);
        }
    }
    void Equip(int weaponID) {
        if (currentWeapon!=null) {
            Destroy(currentWeapon);
        }
        GameObject newWepon = Instantiate(weapons[weaponID], weaponParent.position, weaponParent.rotation, weaponParent) as GameObject;
        newWepon.transform.localPosition = Vector3.zero;
        newWepon.transform.localEulerAngles = Vector3.zero;
        currentWeapon = newWepon;

    }
}
