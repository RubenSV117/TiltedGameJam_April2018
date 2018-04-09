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

    [SerializeField]
    private bool _keyInteractable;

    [SerializeField]
    private KeyCode _interactKey;

    private bool _invoked;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !_keyInteractable)
            OnEnter.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
         
        print("reee");
        if (other.CompareTag("Player") && _keyInteractable && Input.GetKey(_interactKey) && !_invoked)
        {
            _invoked = true;
            OnEnter.Invoke();

        }
    }
}
