using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    public void Setup(int size)
    {
        _camera.fieldOfView = size * 2;
    }
}