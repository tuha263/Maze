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
        _camera.fieldOfView = 100 * (1f *( size + 2) / 22);
        float camPos = 1f * (size - 1) / 2;
        _camera.transform.localPosition = new Vector3(camPos,10,camPos);
    }
}