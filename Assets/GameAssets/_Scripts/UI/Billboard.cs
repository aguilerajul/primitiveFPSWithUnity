using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        this.transform.rotation = _mainCamera.transform.rotation;
    }
}
