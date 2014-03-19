using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public abstract class GameObject : IRenderable,IObjectProducer,IUpdatable,ICollidable
    {
        public Coord topLeft;

        public Coord TopLeft
        {
            get { return new Coord(this.topLeft.Row, this.topLeft.Col); }
            protected set { this.topLeft = new Coord(value.Row, value.Col); }
        }

        public ConsoleColor color;
        protected char[,] body;

        public bool IsDestroyed { get; set; }

        public GameObject(Coord topLeft, char[,] body)
        {
            this.TopLeft = topLeft;

            this.IsDestroyed = false;
            this.body = GetObjectProfile(body);
        }

        public GameObject()
        {
        }
        private char[,] GetObjectProfile(char[,] body)
        {
            int rows = body.GetLength(0);
            int cols = body.GetLength(1);

            char[,] result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = body[row, col];
                }
            }

            return result;
        }

        public char[,] GetImage()
        {
            return this.GetObjectProfile(this.body);
        }

        public Coord GetTopLeft()
        {
            return this.TopLeft;
        }


        public List<Coord> GetCollisionProfile()
        {
            List<Coord> collisionProfile = new List<Coord>();

            int rows = this.body.GetLength(0);
            int cols = this.body.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    collisionProfile.Add(new Coord(row + this.topLeft.Row, col + this.topLeft.Col));
                }
            }

            return collisionProfile;
        }

        public virtual IEnumerable<GameObject> ProduceObjects()
        {
            return new List<GameObject>();
        }

        public virtual void UpdateState()
        {
        }

        public virtual void RespondToCollision()
        {
        }
    }
}
