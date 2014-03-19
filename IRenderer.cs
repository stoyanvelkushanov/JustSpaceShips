using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public interface IRenderer
    {
        void RenderObject(GameObject obj,ConsoleColor color);
    }
}
