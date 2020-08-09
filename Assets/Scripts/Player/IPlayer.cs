using Maze;
using UnityEngine;

namespace Player
{
    public interface IPlayer
    {
        Vector3 GetStartPosition();
        CellView GetCurrencyCell();
        Transform GetTranform();
    }
}