using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public interface IUserInterface
    {
        event EventHandler onLeftPressed;

        event EventHandler onRightPressed;

        event EventHandler onFirePressed;

        event EventHandler onRepairPressed;

        event EventHandler onHelpPressed;

        void ProccessInput();
    }
}
