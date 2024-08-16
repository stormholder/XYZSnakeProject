namespace XYZSnakeProject
{
    public class SnakeGameLogic : BaseGameLogic
    {
        private SnakeGameplayState _gameplayState = new();

        public void GotoGameplay() { _gameplayState.Reset(); }
        public override void Update(float deltaTime) { _gameplayState.Update(deltaTime); }

        public override void OnArrowDown() { _gameplayState.SetDirection(SnakeDir.Down); }
        public override void OnArrowLeft() { _gameplayState.SetDirection(SnakeDir.Left); }
        public override void OnArrowRight() { _gameplayState.SetDirection(SnakeDir.Right); }
        public override void OnArrowUp() { _gameplayState.SetDirection(SnakeDir.Up); }
    }
}
