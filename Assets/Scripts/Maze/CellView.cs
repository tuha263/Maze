using strange.extensions.mediation.impl;
using UnityEngine;

namespace Maze
{
    public class CellView : View
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int nextToPathCount { get; private set; }
        public bool isPath { get; private set; }
        public bool moveTracking { get; private set; }
        public CellView previousCell;
        // [SerializeField] private Material groundMaterial;
        [SerializeField] private Material groundMaterial;
        [SerializeField] private Material doorMaterial;
        private MeshRenderer _meshRenderer;


        public void Init(int x, int y)
        {
            this.x = x;
            this.y = y;
            isPath = false;
            moveTracking = false;
            nextToPathCount = 0;

            transform.localPosition = new Vector3(x, 0, y);
            _meshRenderer = GetComponent<MeshRenderer>();
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

        public void OnVisitNextTo()
        {
            nextToPathCount++;
        }

        public bool IsAbleToVisit()
        {
            return !isPath && nextToPathCount < 2;
        }

        public bool IsAbleToMove()
        {
            return isPath && !moveTracking;
        }

        public void ResetPathFinding()
        {
            moveTracking = false;
        }

        public void SetDoor()
        {
            GetComponent<BoxCollider>().enabled = false;
            _meshRenderer.material = doorMaterial;
        }
    }
}