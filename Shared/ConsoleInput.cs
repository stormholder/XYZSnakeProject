namespace XYZSnakeProject.Shared;

public class ConsoleInput
{
    private HashSet<IArrowListener> _arrowListeners = new();

    public void Subscribe(IArrowListener listener) { _arrowListeners.Add(listener); }
    public void Update()
    {
        while (Console.KeyAvailable)
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowUp();
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowDown();
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowLeft();
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowRight();
                    break;
            }
        }
    }
}
