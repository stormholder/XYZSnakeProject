using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZSnakeProject
{
    public class SnakeGameplayState : BaseGameState
    {
        const SnakeDir DefaultDirection = SnakeDir.Up;
        const int Tick = 5;
        private List<Cell> _body = new();
        private SnakeDir _currentDir = DefaultDirection;
        private float _timeToMove = 0f;

        public void SetDirection(SnakeDir dir) { _currentDir = dir; }

        public Cell ShiftTo(Cell from, SnakeDir dir) {
            return dir switch
            {
                SnakeDir.Up => new(from.X, from.Y + 1),
                SnakeDir.Down => new(from.X, from.Y - 1),
                SnakeDir.Left => new(from.X - 1, from.Y),
                SnakeDir.Right => new(from.X + 1, from.Y),
                _ => from,
            };
        }

        public override void Reset()
        {
            _body.Clear();
            _currentDir = DefaultDirection;
            _body.Add(new(0, 0));
            _timeToMove = 0f;
        }

        public override void Update(float deltaTime)
        {
            _timeToMove -= deltaTime;
            if ( _timeToMove > 0f ) 
                return;
            _timeToMove = 1 / Tick;
            var head = _body[0];
            var nextCell = ShiftTo(head, _currentDir);
            _body.RemoveAt(_body.Count - 1);
            _body.Insert(0, nextCell);

            Console.WriteLine($"{_body[0].X}, {_body[0].Y}");
        }
    }
}
