﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZSnakeProject
{
    public abstract class BaseGameState
    {
        public abstract void Update(float deltaTime);
        public abstract void Reset();
    }
}
