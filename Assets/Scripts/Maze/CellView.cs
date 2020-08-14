using strange.extensions.mediation.impl;
using UnityEngine;

namespace Maze
{
    public class CellView : View
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public bool isPath { get; private set; }
        public bool moveTracking { get; private set; }
        public CellView previousCell;
        // [SerializeField] private Material groundMaterial;
        [SerializeField] private Material groundMaterial;
        [SerializeField] private Material doorMaterial;
        private Material wallMaterial;
        private MeshRenderer _meshRenderer;


        public void Init(int x, int y)
        {
            this.x = x;
            this.y = y;
            isPath = false;
            moveTracking = false;

            transform.localPosition = new Vector3(x, 0, y);
            _meshRenderer = GetComponent<MeshRenderer>();
            wallMaterial = _meshRenderer.material;
        }

        public void DoVisit()
        {
            isPath = true;
            transform.localPosition = new Vector3(x, -1, y);
            _meshRenderer.material = groundMaterial;
        }

        public void DoMove()
        {
            moveTracking = true;
        }

        public bool IsAbleToVisit()
        {
            return !isPath;
        }

        public bool IsAbleToMove()
        {
            return isPath && !moveTracking;
        }

        public void ResetPathFinding()
        {
            moveTracking = false;
        }

        public void ResetGenerateMaze()
        {
            isPath = false;
            transform.localPosition = new Vector3(x, 0, y);
            _meshRenderer.material = wallMaterial;
            gameObject.SetActive(false);
            GetComponent<BoxCollider>().enabled = true;
        }

        public void SetDoor()
        {
            GetComponent<BoxCollider>().enabled = false;
            _meshRenderer.material = doorMaterial;
        }
    }
}