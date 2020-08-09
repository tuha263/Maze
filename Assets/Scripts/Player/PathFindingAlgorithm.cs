using System.Collections.Generic;
using System.Linq.Expressions;
using Maze;

namespace Player
{
    /// <summary>
    /// Breadth-first search
    /// </summary>
    public class PathFindingAlgorithm
    {
        [Inject] public MazeGenerationAlgorithm mazeGenerationAlgorithm { get; set; }
        [Inject] public CellManager cellManager { get; set; }

        private bool _reachToEndCell;
        private CellView _endCell;
        private CellView _startCell;

        public List<CellView> FindPath(CellView startCell, CellView endCell)
        {
            _reachToEndCell = false;
            _endCell = endCell;
            _startCell = startCell;
            // Finding path
            DoMove(startCell);
            
            return TrackingPath(endCell);
        }

        private List<CellView> TrackingPath(CellView currentCell)
        {
            if (currentCell == _startCell)
            {
                return new List<CellView>();
            }
            List<CellView> trackingPath = TrackingPath(currentCell.previousCell);
            trackingPath.Add(currentCell);
            return trackingPath;
        }

        private void DoMove(CellView currentCell)
        {
            currentCell.DoMove();
            if (currentCell == _endCell)
            {
                _reachToEndCell = true;
                return;
            }
            
            List<CellView> moveAbleCellList = new List<CellView>();
            AddMoveAbleCell(moveAbleCellList, currentCell.x - 1, currentCell.y);
            AddMoveAbleCell(moveAbleCellList, currentCell.x + 1, currentCell.y);
            AddMoveAbleCell(moveAbleCellList, currentCell.x, currentCell.y - 1);
            AddMoveAbleCell(moveAbleCellList, currentCell.x, currentCell.y + 1);
            
            // set previous cell to current cell
            moveAbleCellList.ForEach(cell => cell.previousCell = currentCell);
            
            // do move to all move-able cells
            moveAbleCellList.ForEach(DoMove);
        }

        private void AddMoveAbleCell(List<CellView> moveAbleCellList, int x, int y)
        {
            if (x >= 0 && x < mazeGenerationAlgorithm._mazeSize && y >= 0 && y < mazeGenerationAlgorithm._mazeSize && cellManager.GetCell(x, y).IsAbleToMove())
            {
                moveAbleCellList.Add(cellManager.GetCell(x, y));
            }
        }
    }
}