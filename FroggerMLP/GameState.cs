using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    class GameState
    {
        /* Constants */
        private const int INITIAL_POS_X = 100;
        private const int INITIAL_POS_Y = 100;

        private const int SPEED_PLAYER_HORIZONTAL = 6;
        private const int SPEED_PLAYER_VERTICAL = 5;
        private const int SPEED_LEFT = SPEED_PLAYER_HORIZONTAL * -1;
        private const int SPEED_RIGHT = SPEED_PLAYER_HORIZONTAL;
        private const int SPEED_UP = SPEED_PLAYER_VERTICAL * -1;
        private const int SPEED_DOWN = SPEED_PLAYER_VERTICAL;



        /* Members */
        public MainChar mainChar { get; set; }

        private bool goingDown = false;
        private bool goingUp = false;
        private bool goingLeft = false;
        private bool goingRight = false;

        public GameState()
        {
            this.mainChar = new MainChar(TypeOfEntity.MainChar, INITIAL_POS_X, INITIAL_POS_Y);
        }
        
        public void ClockTick()
        {
            if (goingDown)
            {
                mainChar.MoveVertical(SPEED_DOWN);
                goingDown = false;
            }

            if (goingUp)
            {
                mainChar.MoveVertical(SPEED_UP);
                goingUp = false;
            }

            if (goingLeft)
            {
                mainChar.MoveHorizontal(SPEED_LEFT);
                goingLeft = false;
            }

            if (goingRight)
            {
                mainChar.MoveHorizontal(SPEED_RIGHT);
                goingRight = false;
            }
        }

        public void GoDown()
        {
            goingDown = true;
        }

        public void GoUp()
        {
            goingUp = true;
        }

        public void GoLeft()
        {
            goingLeft = true;
        }

        public void GoRight()
        {
            goingRight = true;
        }
    }
}
