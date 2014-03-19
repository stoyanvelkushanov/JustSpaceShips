using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class ConsoleRenderer : IRenderer
    {
       public int worldRows;
       public int worldCols;

       public static int Rows;

        public ConsoleRenderer(int worldRows, int worldCols)
        {
            this.worldCols = worldCols;
            this.worldRows = worldRows;
            Rows= worldRows;
        }

        public void RenderObject(GameObject obj, ConsoleColor color)
        {
            Console.SetCursorPosition(0, 0);
            char[,] objImage = obj.GetImage();

            int rows = objImage.GetLength(0);
            int cols = objImage.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (obj.GetTopLeft().Col + col >= this.worldCols || obj.GetTopLeft().Col < 0 
                        || obj.GetTopLeft().Row + row >= this.worldRows || obj.GetTopLeft().Row < 0 )
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = color;
                        Console.SetCursorPosition((obj.GetTopLeft().Col + col), (obj.GetTopLeft().Row + row));
                        Console.Write(objImage[row, col]);
                        Console.ResetColor();
                    }
                    
                }
                Console.WriteLine();
            }

        }

        public void RenderStringOnPosition(int row, int col, string str, ConsoleColor color)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }
    }
}
