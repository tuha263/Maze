using Maze;
using UnityEngine;

namespace Player
{
    public interface IPlayer
    {
        CellView GetCurrencyCell();
        Transform GetTranform();
    }
}