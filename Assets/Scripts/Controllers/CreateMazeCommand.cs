using Maze;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Controllers
{
    public class CreateMazeCommand : Command
    {
        [Inject] public int size { get; set; }
        [Inject] public Vector3 startPosition { get; set; }
        [Inject] public MazeGenerationAlgorithm mazeGenerationAlgorithm { get; set; }

        public override void Execute()
        {
            mazeGenerationAlgorithm.CreateMaze(size, (int) startPosition.x, (int) startPosition.z);
        }
    }
    
    public class CreateMazeSignal : Signal<int, Vector3>{}
}