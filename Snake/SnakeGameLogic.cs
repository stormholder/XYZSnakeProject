using XYZSnakeProject.Shared;

namespace XYZSnakeProject.Snake;

public class SnakeGameLogic : BaseGameLogic
{
    private SnakeGameplayState _gameplayState = new();

    public void GotoGameplay()
    {
        _gameplayState.FieldHeight = screenHeight;
        _gameplayState.FieldWidth = screenWidth;
        ChangeState(_gameplayState);
        _gameplayState.Reset();
    }
    public override void Update(float deltaTime)
    {
        //_gameplayState.Update(deltaTime);
        if (currentState != _gameplayState)
        {
            GotoGameplay();
        }
    }

    public override void OnArrowDown()
    {
        if (currentState != _gameplayState) return;
        _gameplayState.SetDirection(SnakeDir.Down);
    }
    public override void OnArrowLeft()
    {
        if (currentState != _gameplayState) return;
        _gameplayState.SetDirection(SnakeDir.Left);
    }
    public override void OnArrowRight()
    {
        if (currentState != _gameplayState) return;
        _gameplayState.SetDirection(SnakeDir.Right);
    }
    public override void OnArrowUp()
    {
        if (currentState != _gameplayState) return;
        _gameplayState.SetDirection(SnakeDir.Up);
    }

    public override ConsoleColor[] CreatePalette()
    {
        return
            [
                ConsoleColor.Green,
                ConsoleColor.Red,
                ConsoleColor.White,
                ConsoleColor.Blue,
            ];
    }
}
