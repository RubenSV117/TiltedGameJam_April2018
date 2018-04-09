using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class JalepenoEntity : MonoBehaviour {
    [SerializeField]
    protected float _speed = 3.0f;
    [SerializeField]
    protected float _explosionDelay = 0.8f;
    [SerializeField]
    float respawnTimer;

    [HideInInspector] public GameObject spawner;
    public float explosionRadius = 2.0f;
    public NavMeshAgent NMAgent;
    public Explosive explosion;
    protected GameObject _playerObject;
    private Vector3 _dir;
    private bool _mobile = true;

<<<<<<< HEAD
    Coroutine coExplode;
    Coroutine coWaitToRespawn;

    private State jalState;

    public State JalState
    {
        get
        {
            return jalState;
        }
        set
        {
            gameObject.GetComponent<MeshRenderer>().enabled = value == State.Alive ? true : false;
            jalState = value;
        }
    }

    public enum State
    {
        Alive,
        Dead
    };

=======
    private AudioSource _audio;
>>>>>>> master
    // Use this for initialization
    void Start() {
        _audio = GetComponent<AudioSource>();
        explosion.GetComponent<SphereCollider>().radius = explosionRadius;
        _playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if(JalState == State.Alive)
        {
            if (_mobile)
            {
                ChasePlayer();
            }
        }
    }

    /// <summary>
    /// Chase the Player
    /// if the player is within 85% of the explosion radius, explode
    /// else chase
    /// </summary>
    public void ChasePlayer() {
        if (Vector3.Distance(_playerObject.transform.position, transform.position) <= explosionRadius * 0.85f && _playerObject.activeSelf) {
            _mobile = false;
            coExplode = StartCoroutine(Explode());
        }
        else {
            if(_playerObject.activeSelf)
            {
                _dir = (_playerObject.transform.position - transform.position).normalized;
                NMAgent.Move(_dir * _speed * Time.deltaTime);
            }
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
        Die();
    }

    IEnumerator WaitToRespawn()
    {
        yield return new WaitForSeconds(respawnTimer);
        spawner.GetComponent<CircleSpawner>().AddToRespawnList(gameObject);
        StopCoroutine(coWaitToRespawn);
    }

    void Die()
    {
        StopCoroutine(coExplode);
        coWaitToRespawn = StartCoroutine(WaitToRespawn());
        JalState = State.Dead;
    }
}
