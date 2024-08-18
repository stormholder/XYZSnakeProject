using System.Reflection.Emit;
using XYZSnakeProject.Shared;

namespace XYZSnakeProject.Snake;

public class SnakeGameplayState : BaseGameState
{
    const char squareSymbol = '■';
    const char circleSymbol = '0';
    const SnakeDir DefaultDirection = SnakeDir.Up;
    const int Tick = 4;
    private List<Cell> _body = new();
    private SnakeDir _currentDir = DefaultDirection;
    private float _timeToMove = 0f;

    private Cell _apple = new();
    private Random _random = new();

    public int FieldWidth { get; set; }
    public int FieldHeight { get; set; }
    public bool GameOver { get; private set; }
    public bool HasWon { get; private set; }
    public int Level { get; set; }

    private void GenerateApple()
    {
        Cell cell;
        cell.X = _random.Next(FieldWidth);
        cell.Y = _random.Next(FieldHeight);

        if (_body[0].Equals(cell))
        {
            if (cell.Y > FieldHeight / 2)
                cell.Y--;
            else
                cell.Y++;
        }

        _apple = cell;
    }

    public void SetDirection(SnakeDir dir) { _currentDir = dir; }

    public Cell ShiftTo(Cell from, SnakeDir dir)
    {
        return dir switch
        {
            SnakeDir.Up => new(from.X, from.Y - 1),
            SnakeDir.Down => new(from.X, from.Y + 1),
            SnakeDir.Left => new(from.X - 1, from.Y),
            SnakeDir.Right => new(from.X + 1, from.Y),
            _ => from,
        };
    }

    public override void Reset()
    {
        _body.Clear();
        var middleY = FieldHeight / 2;
        var middleX = FieldWidth / 2;
        GameOver = false;
        HasWon = false;
        _currentDir = DefaultDirection;
        _body.Add(new(middleX + 3, middleY));
        _apple = new(middleX - 3, middleY);
        _timeToMove = 0f;
    }

    public override void Update(float deltaTime)
    {
        _timeToMove -= deltaTime;
        if (_timeToMove > 0f || GameOver)
            return;
        _timeToMove = 1 / (Tick + Level);
        var head = _body[0];
        var nextCell = ShiftTo(head, _currentDir);

        if (nextCell.Equals(_apple))
        {
            _body.Insert(0, _apple);
            HasWon = _body.Count >= Level + 3;
            GenerateApple();
            return;
        }

        if (nextCell.X < 0 || nextCell.Y < 0 || nextCell.X >= FieldWidth || nextCell.Y >= FieldHeight)
        {
            GameOver = true;
            return;
        }

        _body.RemoveAt(_body.Count - 1);
        _body.Insert(0, nextCell);
    }

    public override void Draw(ConsoleRenderer renderer)
    {
        renderer.DrawString($"Level: {Level}", 3, 1, ConsoleColor.White);
        renderer.DrawString($"Score: {_body.Count - 1}", 3, 2, ConsoleColor.White);
        foreach (var cell in _body)
        {
            renderer.SetPixel(cell.X, cell.Y, squareSymbol, 3);
        }
        renderer.SetPixel(_apple.X, _apple.Y, circleSymbol, 1);
    }

    public override bool IsDone()
    {
        return GameOver || HasWon;
    }
}
