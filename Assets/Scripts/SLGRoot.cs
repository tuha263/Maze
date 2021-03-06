﻿using Maze;
using Player;
using strange.extensions.context.impl;

public class SLGRoot : ContextView
{
    public CellManager cellManager;
    public PlayerView playerView;
    public CameraManager cameraManager;

    private void Awake()
    {
        context = new SLGContext(this);
    }
}