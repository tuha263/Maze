using Controllers;
using Maze;
using Player;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UI;
using UnityEngine;

public class SLGContext : MVCSContext
{
    public SLGContext(MonoBehaviour view) : base(view)
    {
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>();
    }

    public override IContext Start()
    {
        base.Start();
        StartSignal startSignal = injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
        return this;
    }

    protected override void mapBindings()
    {
        SLGRoot slgRoot = (contextView as GameObject)?.GetComponent<SLGRoot>();

        // command binding
        commandBinder.Bind<StartSignal>().To<StartCommand>().Once();
        commandBinder.Bind<CreateMazeSignal>().To<CreateMazeCommand>().Pooled();
        commandBinder.Bind<MovePlayerSignal>().To<MovePlayerCommand>();
        
        // injection binding
        injectionBinder.Bind<MazeGenerationAlgorithm>().ToSingleton();
        injectionBinder.Bind<PathFindingAlgorithm>().ToSingleton();
        injectionBinder.Bind<CellManager>().ToValue(slgRoot.cellManager);
        injectionBinder.Bind<IPlayer>().ToValue(slgRoot.playerView);
        injectionBinder.Bind<CameraManager>().ToValue(slgRoot.cameraManager);
        
        // mediation binding
        mediationBinder.Bind<CellView>().To<CellMediator>();
        mediationBinder.Bind<PlayerView>().To<PlayerMediator>();
        mediationBinder.Bind<MainUIView>().To<MainUIMediator>();
    }
}