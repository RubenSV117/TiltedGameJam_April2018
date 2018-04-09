using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransitionManager : MonoBehaviour {

    public UnityEvent OnEnter;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        OnEnter.Invoke();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
