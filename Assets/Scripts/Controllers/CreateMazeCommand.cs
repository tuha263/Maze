using Maze;
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

        public override void Execute()
        {
            mazeGenerationAlgorithm.CreateMaze(size);
            cameraManager.Setup(size);
        }
    }
    
    public class CreateMazeSignal : Signal<int>{}
}