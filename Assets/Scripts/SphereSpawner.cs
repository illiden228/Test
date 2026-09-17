using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _sphereObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject.Instantiate(_sphereObject, transform.position, transform.rotation);
        }
    }
}
