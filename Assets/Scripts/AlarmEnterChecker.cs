using System;
using UnityEngine;

public class AlarmEnterChecker : MonoBehaviour
{
    public event Action Enter; 
    public event Action Exit; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CrookMover crookMover) == true)
        {
            Enter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CrookMover crookMover) == true)
        {
            Exit?.Invoke();
        }
    }
}
