using Maze;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Player
{
    public class PlayerView : View, IPlayer
    {
        public Vector3 startPosition;
        [Inject] public CellManager cellManager { get; set; }

        public void Init()
        {
            transform.localPosition = startPosition;
        }

        public Vector3 GetStartPosition()
        {
            return startPosition;
        }

        public CellView GetCurrencyCell()
        {
            var localPosition = transform.localPosition;
            return cellManager.GetCell((int) localPosition.x, (int) localPosition.z);
        }

        public Transform GetTranform()
        {
            return transform;
        }
    }
}