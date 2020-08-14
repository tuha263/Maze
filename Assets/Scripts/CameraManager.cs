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
        size = size * 2 + 1;
        _camera.orthographicSize = 11 * (1f * size / 21);
        float camPos = 1f * size / 2;
        _camera.transform.localPosition = new Vector3(camPos,10,camPos - 1.5f);
    }
}