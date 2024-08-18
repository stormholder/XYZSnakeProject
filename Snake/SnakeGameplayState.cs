using XYZSnakeProject.Shared;

namespace XYZSnakeProject.Snake;

public class SnakeGameplayState : BaseGameState
{
    const char squareSymbol = '■';
    const SnakeDir DefaultDirection = SnakeDir.Up;
    const int Tick = 5;
    private List<Cell> _body = new();
    private SnakeDir _currentDir = DefaultDirection;
    private float _timeToMove = 0f;
    public int FieldWidth { get; set; }
    public int FieldHeight { get; set; }

    public void SetDirection(SnakeDir dir) { _currentDir = dir; }

    public Cell ShiftTo(Cell from, SnakeDir dir)
    {
        return dir switch
        {
            SnakeDir.Up => new(from.X, (from.Y - 1) >= 0 ? from.Y - 1 : FieldHeight - 1),
            SnakeDir.Down => new(from.X, (from.Y + 1) < FieldHeight ? from.Y + 1 : 0),
            SnakeDir.Left => new((from.X - 1) >= 0 ? from.X - 1 : FieldWidth - 1, from.Y),
            SnakeDir.Right => new((from.X + 1) < FieldWidth ? from.X + 1 : 0, from.Y),
            _ => from,
        };
    }

    public override void Reset()
    {
        _body.Clear();
        var middleY = FieldHeight / 2;
        var middleX = FieldWidth / 2;
        _currentDir = DefaultDirection;
        _body.Add(new(middleX + 3, middleY));
        _timeToMove = 0f;
    }

    public override void Update(float deltaTime)
    {
        _timeToMove -= deltaTime;
        if (_timeToMove > 0f)
            return;
        _timeToMove = 1 / Tick;
        var head = _body[0];
        var nextCell = ShiftTo(head, _currentDir);
        _body.RemoveAt(_body.Count - 1);
        _body.Insert(0, nextCell);
    }

    public override void Draw(ConsoleRenderer renderer)
    {
        foreach (var cell in _body)
        {
            renderer.SetPixel(cell.X, cell.Y, squareSymbol, 3);
        }
    }
}
