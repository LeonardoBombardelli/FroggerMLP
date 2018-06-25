using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    class Car : MovingEntity
    {
        public const int HITBOX_X_CAR = 96;
        public const int HITBOX_Y_CAR = 48;

        public Car(TypeOfEntity typeOfEntity, int posX, int posY) : base(typeOfEntity, posX, posY)
        {
            this.typeOfEntity = TypeOfEntity.Car;
        }

        public override void MoveHorizontal(int valueToMove)
        {
            this.posX += valueToMove;
        }

        public override void MoveVertical(int valueToMove)
        {
            throw new NotImplementedException();
        }

        public bool GotOutOfScene()
        {
            return (posX >= Game.CANVAS_WIDTH);
        }
    }
}
