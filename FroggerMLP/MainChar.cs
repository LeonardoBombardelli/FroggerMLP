using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    class MainChar : MovingEntity
    {
        /* Constants */
        public const int SIZE_PLAYER_HORIZONTAL = 31;
        public const int SIZE_PLAYER_VERTICAL = 31;

        public const int INITIAL_POS_X = Game.CANVAS_WIDTH / 2;
        public const int INITIAL_POS_Y = Game.CANVAS_HEIGHT - MainChar.SIZE_PLAYER_VERTICAL;

        public const int SPEED_PLAYER_HORIZONTAL = 4;
        public const int SPEED_PLAYER_VERTICAL = 3;
        public const int SPEED_LEFT = SPEED_PLAYER_HORIZONTAL * -1;
        public const int SPEED_RIGHT = SPEED_PLAYER_HORIZONTAL;
        public const int SPEED_UP = SPEED_PLAYER_VERTICAL * -1;
        public const int SPEED_DOWN = SPEED_PLAYER_VERTICAL;


        public MainChar(TypeOfEntity typeOfEntity, int posX, int posY) : base(typeOfEntity, posX, posY)
        {
            this.typeOfEntity = TypeOfEntity.MainChar;
        }

        public override void MoveHorizontal(int valueToMove)
        {
            this.posX += valueToMove;
            if (this.posX < 0)
                this.posX = 0;
            if (this.posX > Game.CANVAS_WIDTH - SIZE_PLAYER_HORIZONTAL)
                this.posX = Game.CANVAS_WIDTH - SIZE_PLAYER_HORIZONTAL;
        }

        public override void MoveVertical(int valueToMove)
        {
            this.posY += valueToMove;
            if (this.posY < 0)
                this.posY = 0;
            if (this.posY > Game.CANVAS_HEIGHT - SIZE_PLAYER_VERTICAL)
                this.posY = Game.CANVAS_HEIGHT - SIZE_PLAYER_VERTICAL;
        }
    }
}
