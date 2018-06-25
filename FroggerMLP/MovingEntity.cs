using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    abstract class MovingEntity : Entity
    {
        public MovingEntity(TypeOfEntity typeOfEntity, int posX, int posY) : base(typeOfEntity, posX, posY)
        { }

        public abstract void MoveHorizontal(int valueToMove);

        public abstract void MoveVertical(int valueToMove);
    }
}
