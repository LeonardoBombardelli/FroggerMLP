using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    class MainChar : MovingEntity
    {
        public MainChar(TypeOfEntity typeOfEntity, int posX, int posY) : base(typeOfEntity, posX, posY)
        {
            this.typeOfEntity = TypeOfEntity.MainChar;
        }

        public override void MoveHorizontal(int valueToMove)
        {
            this.posX += valueToMove;
        }

        public override void MoveVertical(int valueToMove)
        {
            this.posY += valueToMove;
        }
    }
}
