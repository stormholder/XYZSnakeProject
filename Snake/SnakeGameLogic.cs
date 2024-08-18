using XYZSnakeProject.Shared;

namespace XYZSnakeProject.Snake;

public class SnakeGameLogic : BaseGameLogic
{
    private SnakeGameplayState _gameplayState = new();
    private bool newGamePending = false;
    private int currLevel = 0;
    private ShowTextState showTextState = new(2f);

    private void GotoGameOver()
    {
        currLevel = 0;
        newGamePending = true;
        showTextState.text = $"Game Over!";
        ChangeState(showTextState);
    }
    private void GotoNextLevel()
    {
        currLevel++;
        newGamePending = false;
        showTextState.text = $"Level {currLevel}";
        ChangeState(showTextState);
    }

    public void GotoGameplay()
    {
        _gameplayState.Level = currLevel;
        _gameplayState.FieldHeight = screenHeight;
        _gameplayState.FieldWidth = screenWidth;
        ChangeState(_gameplayState);
        _gameplayState.Reset();
    }
    public override void Update(float deltaTime)
    {
        if (currentState != null && !currentState.IsDone())
            return;
        if (currentState == null || currentState == _gameplayState && !_gameplayState.GameOver)
        {
            GotoNextLevel();
        }
        else if (currentState == _gameplayState && !_gameplayState.GameOver)
        {
            GotoGameOver();
        }
        else if (currentState != _gameplayState && newGamePending)
        {
            GotoNextLevel();
        }
        else if (currentState != _gameplayState && !newGamePending)
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
