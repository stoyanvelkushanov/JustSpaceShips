using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public interface ICollidable
    {
        void RespondToCollision();

        List<Coord> GetCollisionProfile();
    }
}
