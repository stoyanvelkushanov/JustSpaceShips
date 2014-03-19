using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class KeyboardController : IUserInterface
    {
        public event EventHandler onLeftPressed;

        public event EventHandler onRightPressed;

        public event EventHandler onFirePressed;

        public event EventHandler onRepairPressed;

        public event EventHandler onHelpPressed;

        public void ProccessInput()
        {
            if (Console.KeyAvailable)
            {
                var pressedKey = Console.ReadKey(true);

                while (Console.KeyAvailable) Console.ReadKey(true);

                if (pressedKey.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (this.onLeftPressed != null)
                    {
                        this.onLeftPressed(this, new EventArgs());
                    }
                }
                else if (pressedKey.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.onRightPressed != null)
                    {
                        this.onRightPressed(this, new EventArgs());
                    }
                }
                else if (pressedKey.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (this.onFirePressed != null)
                    {
                        this.onFirePressed(this, new EventArgs());
                    }
                }

                else if (pressedKey.Key.Equals(ConsoleKey.R))
                {
                    if (this.onRepairPressed != null)
                    {
                        this.onRepairPressed(this, new EventArgs());
                    }
                }

                else if (pressedKey.Key.Equals(ConsoleKey.H))
                {
                    if (this.onHelpPressed != null)
                    {
                        this.onHelpPressed(this, new EventArgs());
                    }
                }
            }
        }
    }
}
