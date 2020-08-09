using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraManager : MonoBehaviour
    {
        public Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }
    }
}