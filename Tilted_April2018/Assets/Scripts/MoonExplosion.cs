using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonExplosion : MonoBehaviour {
    public GameObject MoonWhole;
    public List<Rigidbody> MoonFragments;
    private Transform _parentPos;
    private AudioSource _audio;
	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
        _parentPos = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T)){
            ExplodeMoon();
        }
	}

    public void ExplodeMoon() {
        _audio.PlayOneShot(_audio.clip);
        MoonWhole.SetActive(false);
        foreach (Rigidbody t in MoonFragments) {
            t.gameObject.SetActive(true);
            t.AddExplosionForce(10f, _parentPos.position, 5f, 6.0f, ForceMode.Impulse);
            Destroy(t.gameObject, 5.0f);
        }
    }
}
