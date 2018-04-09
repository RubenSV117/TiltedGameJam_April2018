using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Changes level phases on Enter event
/// 
/// Ruben Sanchez
/// 
/// </summary>

public class PhaseChanger : MonoBehaviour
{
    public UnityEvent OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            OnEnter.Invoke();
    }
}
