using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class JalepenoEntity : MonoBehaviour {
    [SerializeField]
    protected float _speed = 3.0f;
    [SerializeField]
    protected float _explosionDelay = 2.0f;

    public NavMeshAgent NMAgent;
    public Explosive explosion;
    protected GameObject _playerObject;
    private Vector3 _dir;
	// Use this for initialization
	void Start () {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            StartCoroutine(Explode());
        }
	}

    public void ChasePlayer() {
        _dir = (transform.position - _playerObject.transform.position).normalized;
        NMAgent.Move(_dir * _speed * Time.deltaTime);
    }

    public IEnumerator Explode() {
        yield return new WaitForSeconds(_explosionDelay);
        explosion.gameObject.SetActive(true);
    }

}
