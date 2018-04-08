using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {
    //don't actyally touch this
    [SerializeField]
    private HealthManager _damageableObj;

    //hurt the player we have stored
    public void Explode() {
        if (_damageableObj != null) {
            _damageableObj.TakeDamage(999f);
            _damageableObj = null;
        }
    }

    //player enters
    void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "Player") {
            _damageableObj = c.gameObject.GetComponent<HealthManager>();
        }
    }
    //player exits
    void OnTriggerExit(Collider c) {
        if (c.gameObject.tag == "Player") {
            _damageableObj = null;
        }
    }
}
