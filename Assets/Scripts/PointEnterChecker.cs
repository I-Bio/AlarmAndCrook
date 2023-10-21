using UnityEngine;

public class PointEnterChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CrookMover crookMover) == true)
        {
            crookMover.SetNextPoint();
        }
    }
}
