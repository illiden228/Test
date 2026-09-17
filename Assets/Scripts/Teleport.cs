using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform _teleportPoint;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Teleporter teleporter))
        {
            other.transform.position = _teleportPoint.position;
        }
    }
}
