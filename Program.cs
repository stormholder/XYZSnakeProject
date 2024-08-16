namespace XYZSnakeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var gameLogic = new SnakeGameLogic();
            var input = new ConsoleInput();
            var lastFrameTime = DateTime.Now;
            gameLogic.InitializeInput(input);
            gameLogic.GotoGameplay();
            while (true)
            {
                var frameStartTime = DateTime.Now;
                float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;
                input.Update();
                gameLogic.Update(deltaTime);
                lastFrameTime = frameStartTime;
            }
        }
    }
}
