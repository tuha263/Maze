using System.Collections.Generic;
using System.ComponentModel;
using DG.Tweening;
using Maze;
using Player;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Controllers
{
    public class MovePlayerCommand : Command
    {
        [Inject] public CellView endCell { get; set; }
        [Inject] public IPlayer player { get; set; }
        [Inject] public PathFindingAlgorithm pathFindingAlgorithm { get; set; }
        [Inject] public CellManager cellManager { get; set; }

        private List<CellView> _path;

        public override void Execute()
        {
            cellManager.ResetPathFinding();
            
            _path = pathFindingAlgorithm.FindPath(player.GetCurrencyCell(), endCell);
            
            _path.ForEach(cell => Debug.Log($"{cell.x} -  {cell.y}"));
            if (_path.Count > 0)
            {
                _moveTween.Kill();
                DoMove(0);
            }
            
            Debug.Log("Moving Finish!");
        }


        private static Tween _moveTween;
        private void DoMove(int pathCellIndex)
        {
            if (pathCellIndex == _path.Count)
            {
                return;
            }
            CellView nextCell = _path[pathCellIndex];
            _moveTween = player.GetTranform().DOMove(new Vector3(nextCell.x, 0, nextCell.y), 0.2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                DoMove(pathCellIndex + 1);
            });
        }
    }
    
    public class MovePlayerSignal : Signal<CellView>{}
}