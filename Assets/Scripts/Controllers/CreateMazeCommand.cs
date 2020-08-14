using DG.Tweening;
using Maze;
using Player;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Controllers
{
    public class CreateMazeCommand : Command
    {
        [Inject] public int size { get; set; }
        [Inject] public MazeGenerationAlgorithm mazeGenerationAlgorithm { get; set; }
        [Inject] public CameraManager cameraManager { get; set; }
        [Inject] public CellManager cellManager { get; set; }
        [Inject] public IPlayer player { get; set; }

        public override void Execute()
        {
            cellManager.ResetGenerateMaze();
            MovePlayerCommand.MoveTween.Kill();
            player.Reset();
            mazeGenerationAlgorithm.CreateMaze(size);
            cameraManager.Setup(size);
        }
    }
    
    public class CreateMazeSignal : Signal<int>{}
}