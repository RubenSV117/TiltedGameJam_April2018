﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class JalepenoEntity : MonoBehaviour {
    [SerializeField]
    protected float _speed = 3.0f;
    [SerializeField]
    protected float _explosionDelay = 0.8f;

    public float explosionRadius = 2.0f;
    public NavMeshAgent NMAgent;
    public Explosive explosion;
    protected GameObject _playerObject;
    private Vector3 _dir;
    private bool _mobile = true;

    private AudioSource _audio;
    // Use this for initialization
    void Start() {
        _audio = GetComponent<AudioSource>();
        explosion.GetComponent<SphereCollider>().radius = explosionRadius;
        _playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if (_mobile) {
            ChasePlayer();
        }
    }

    /// <summary>
    /// Chase the Player
    /// if the player is within 85% of the explosion radius, explode
    /// else chase
    /// </summary>
    public void ChasePlayer() {
        if (Vector3.Distance(_playerObject.transform.position, transform.position) <= explosionRadius * 0.85f) {
            _mobile = false;
            StartCoroutine(Explode());
        }
        else {
            _dir = (_playerObject.transform.position - transform.position).normalized;
            NMAgent.Move(_dir * _speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// name on tin
    /// </summary>
    /// <returns></returns>
    public IEnumerator Explode() {
        _audio.PlayOneShot(_audio.clip);
        yield return new WaitForSeconds(_explosionDelay);
        explosion.Explode();
        yield return new WaitForSeconds(0.1f);
        //delete self here
    }

}
