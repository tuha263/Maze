using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class CellManager : MonoBehaviour
    {
        [SerializeField] private CellView cellPrefab;
        
        /// <summary>
        /// map<x, y, cellview>
        /// </summary>
        private readonly Dictionary<int, Dictionary<int, CellView>> _cellMap = new Dictionary<int, Dictionary<int, CellView>>();

        public CellView GetCell(int x, int y)
        {
            if (_cellMap.ContainsKey(x) && _cellMap[x].ContainsKey(y))
            {
                return _cellMap[x][y];
            }

            // add new row
            if (!_cellMap.ContainsKey(x))
            {
                _cellMap.Add(x, new Dictionary<int, CellView>());
            }

            // add new cell
            CellView cell = Instantiate(cellPrefab, transform);
            cell.Init(x, y);
            _cellMap[x].Add(y, cell);
            

            return _cellMap[x][y];
        }

        public void ResetPathFinding()
        {
            foreach (Dictionary<int,CellView> row in _cellMap.Values)
            {
                foreach (var cell in row.Values)
                {
                    cell.ResetPathFinding();
                }
            }
        }
    }
}