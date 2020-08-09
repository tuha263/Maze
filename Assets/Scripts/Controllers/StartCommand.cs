using Player;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Controllers
{
    public class StartCommand : Command
    {
        [Inject] public CreateMazeSignal createMazeSignal { get; set; }
        [Inject] public IPlayer player { get; set; }

        public override void Execute()
        {
            Debug.Log("Start Game!!");
            // generate maze
            createMazeSignal.Dispatch(20, player.GetStartPosition());   
        }
    }

    public class StartSignal : Signal
    {
    }
}