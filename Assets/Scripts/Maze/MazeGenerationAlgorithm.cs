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


        public void CreateMaze(int size, int startX = 0, int startY = 0)
        {
            Debug.Log("Run Maze Generation Algorithm!!");
            _mazeSize = size * 2 - 1;
            Visit(cellManager.GetCell(startX, startY));
            BorderTheMaze();
        }

        private void BorderTheMaze()
        {
            for (int index = -1; index < _mazeSize; index++)
            {
                cellManager.GetCell(-1, index);
                cellManager.GetCell(_mazeSize, index);
                cellManager.GetCell(index, -1);
                cellManager.GetCell(index, _mazeSize);
            }

            // entrance
            OpenDoor(-1, -1);
            OpenDoor(-1, 0);
            OpenDoor(0, -1);
            // exit
            OpenDoor(_mazeSize, _mazeSize);
            OpenDoor(_mazeSize, _mazeSize - 1);
            OpenDoor(_mazeSize - 1, _mazeSize);
            cellManager.GetCell(_mazeSize - 1, _mazeSize - 1).DoVisit();
        }

        public void OpenDoor(int x, int y)
        {
            CellView cell = cellManager.GetCell(x, y);
            cell.DoVisit();
            // create wall
            for (int i = 0; i < _mazeSize; i++)
            {
                for (int j = 0; j < _mazeSize; j++)
                {
                    cellManager.GetCell(i, j);
                }
            }

            cell.SetDoor();
        }

        /// <summary>
        /// do visit cell
        /// </summary>
        /// <param name="cell"></param>
        private void Visit(CellView cell)
        {
            cell.DoVisit();

            // get around cell list
            List<CellView> aroundCellList = new List<CellView>();
            AddVisitAbleCell(aroundCellList, cell.x - 2, cell.y);
            AddVisitAbleCell(aroundCellList, cell.x + 2, cell.y);
            AddVisitAbleCell(aroundCellList, cell.x, cell.y - 2);
            AddVisitAbleCell(aroundCellList, cell.x, cell.y + 2);

            // do visit
            while (aroundCellList.Count > 0)
            {
                int randomIndex = Mathf.Min(aroundCellList.Count - 1, Random.Range(0, aroundCellList.Count));
                CellView randomCell = aroundCellList[randomIndex];
                if (randomCell.IsAbleToVisit())
                {
                    CellView wall = cellManager.GetCell((randomCell.x + cell.x) / 2, (randomCell.y + cell.y) / 2);
                    wall.DoVisit();
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
    }
}