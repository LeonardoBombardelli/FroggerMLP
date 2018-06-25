using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    class GameState
    {

        /* Members */
        public MainChar mainChar { get; set; }

        private bool goingDown = false;
        private bool goingUp = false;
        private bool goingLeft = false;
        private bool goingRight = false;

        public GameState()
        {
            this.mainChar = new MainChar(TypeOfEntity.MainChar, MainChar.INITIAL_POS_X, MainChar.INITIAL_POS_Y);
        }
        
        public void ClockTick()
        {
            if (goingDown)
            {
                mainChar.MoveVertical(MainChar.SPEED_DOWN);
            }

            if (goingUp)
            {
                mainChar.MoveVertical(MainChar.SPEED_UP);
            }

            if (goingLeft)
            {
                mainChar.MoveHorizontal(MainChar.SPEED_LEFT);
            }

            if (goingRight)
            {
                mainChar.MoveHorizontal(MainChar.SPEED_RIGHT);
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

        public void StopGoDown()
        {
            goingDown = false;
        }

        public void StopGoUp()
        {
            goingUp = false;
        }

        public void StopGoLeft()
        {
            goingLeft = false;
        }

        public void StopGoRight()
        {
            goingRight = false;
        }
    }
}
