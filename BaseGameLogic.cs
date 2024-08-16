using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZSnakeProject
{
    public abstract class BaseGameLogic : IArrowListener
    {
        public void InitializeInput(ConsoleInput input)
        {
            input.Subscribe(this);
        }

        public abstract void Update(float deltaTime);

        public abstract void OnArrowDown();

        public abstract void OnArrowLeft();

        public abstract void OnArrowRight();

        public abstract void OnArrowUp();
    }
}
