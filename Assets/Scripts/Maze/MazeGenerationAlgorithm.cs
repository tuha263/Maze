using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    /// <summary>
    /// source: https://en.wikipedia.org/wiki/Maze_generation_algorithm
    /// --Randomized depth-first search---
    /// </summary>
    public class MazeGenerationAlgorithm
    {
        public int _mazeSize { get; private set; }

        [Inject] public CellManager cellManager { get; set; }

        /// <summary>
        /// do visit cell
        /// </summary>
        /// <param name="cell"></param>
        private void Visit(CellView cell)
        {
            cell.DoVisit();

            // get around cell list
            List<CellView> aroundCellList = new List<CellView>();
            AddVisitAbleCell(aroundCellList, cell.x - 1, cell.y);
            AddVisitAbleCell(aroundCellList, cell.x + 1, cell.y);
            AddVisitAbleCell(aroundCellList, cell.x, cell.y - 1);
            AddVisitAbleCell(aroundCellList, cell.x, cell.y + 1);
            aroundCellList.ForEach(aroundCell => aroundCell.OnVisitNextTo());

            // do visit
            while (aroundCellList.Count > 0)
            {
                int randomIndex = Mathf.Min(aroundCellList.Count - 1, Random.Range(0, aroundCellList.Count));
                CellView randomCell = aroundCellList[randomIndex];
                if (randomCell.IsAbleToVisit())
                {
                    Visit(randomCell);
                }

                aroundCellList.RemoveAt(randomIndex);
            }
        }

        private void AddVisitAbleCell(List<CellView> aroundCell, int x, int y)
        {
            if (x >= 0 && x < _mazeSize && y >= 0 && y < _mazeSize && cellManager.GetCell(x, y).IsAbleToVisit())
            {
                aroundCell.Add(cellManager.GetCell(x, y));
            }
        }

        public void CreateMaze(int size, int startX = 0, int startY = 1)
        {
            Debug.Log("Run Maze Generation Algorithm!!");
            _mazeSize = size;
            Visit(cellManager.GetCell(startX, startY));
        }
    }
}