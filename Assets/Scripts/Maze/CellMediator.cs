using Controllers;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Maze
{
    public class CellMediator : Mediator
    {
        [Inject] public CellView view { get; set; }
        [Inject] public MovePlayerSignal movePlayerSignal { get; set; }
        [Inject] public CellManager cellManager { get; set; }

        private void OnMouseDown()
        {
            if (view.isPath)
            {
                movePlayerSignal.Dispatch(cellManager.GetCell(view.x, view.y));
            }
        }
    }
}