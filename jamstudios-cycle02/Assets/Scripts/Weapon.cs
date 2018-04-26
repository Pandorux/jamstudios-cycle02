using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.name);

        if (c.tag == "Chicken")
        {
            Debug.Log("Chicken be hurt");
            c.GetComponent<ChickenController>().TakeDamage(PlayerController.instance.combat.attackDamage);
        }
    }

}
