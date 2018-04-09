using System.Collections;
using Cinemachine;
using UnityEngine;

/// <summary>
///
/// Ruben Sanchez
/// 
/// </summary>

public class EndSequence : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _explosionParticles;

    [SerializeField]
    private GameObject _blackoutPanel;

    [SerializeField]
    private GameObject[] _objectsToDisable;

    [SerializeField]
    private float _explosionWait = 1;

    [SerializeField]
    private CinemachineVirtualCamera _vCam;

    [SerializeField] private GameObject _moon;

    private void Awake()
    {
        _blackoutPanel.SetActive(false);
    }

    public void EndGame()
    {
        StartCoroutine(DestroyMoon());
;    }

    private IEnumerator DestroyMoon()
    {
        foreach (var obj in _objectsToDisable)
        {
            obj.SetActive(false);
        }

        _moon.SetActive(true);

        for (int i = 0; i < 100; i++)
        {
            _vCam.m_Lens.FieldOfView += .5f;
            yield return new WaitForSeconds(.01f);
        }

        foreach (var explosion in _explosionParticles)
        {
            explosion.SetActive(true);
            yield return new WaitForSeconds(_explosionWait);
        }
        _moon.SetActive(false);
        _blackoutPanel.SetActive(true);
    }
}
