﻿namespace XYZSnakeProject.Shared;

public abstract class BaseGameLogic : IArrowListener
{
    protected BaseGameState? currentState { get; private set; }
    protected float time { get; private set; }
    protected int screenWidth { get; private set; }
    protected int screenHeight { get; private set; }

    public abstract ConsoleColor[] CreatePalette();

    public void InitializeInput(ConsoleInput input)
    {
        input.Subscribe(this);
    }

    protected void ChangeState(BaseGameState? state)
    {
        currentState?.Reset();
        currentState = state;
    }

    public void DrawNewState(float deltaTime, ConsoleRenderer renderer)
    {
        time += deltaTime;
        screenWidth = renderer.width;
        screenHeight = renderer.height;

        currentState?.Update(deltaTime);
        currentState?.Draw(renderer);

        Update(deltaTime);
    }

    public abstract void Update(float deltaTime);

    public abstract void OnArrowDown();

    public abstract void OnArrowLeft();

    public abstract void OnArrowRight();

    public abstract void OnArrowUp();
}
