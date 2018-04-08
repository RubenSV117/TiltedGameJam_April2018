using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {
    //don't actyally touch this
    [SerializeField]
    private IDamageable _damageableObj;

    public void Explode() {
        if(_damageableObj != null) {
            Debug.Log(_damageableObj);
            _damageableObj.TakeDamage(999f);
        }
    }

    void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "Player") {
            _damageableObj = c.gameObject.GetComponent<IDamageable>();
        }
    }
}
