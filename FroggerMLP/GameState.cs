using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    enum Directions
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    class GameState
    {

        public const int MAX_Y_PLAYER_CAN_GO = 400;

        /* Members */
        public MainChar mainChar { get; set; }
        public List<Street> streets { get; set; }

        private bool goingDown = false;
        private bool goingUp = false;
        private bool goingLeft = false;
        private bool goingRight = false;

        public GameState()
        {
            this.mainChar = new MainChar(TypeOfEntity.MainChar, MainChar.INITIAL_POS_X, MainChar.INITIAL_POS_Y);
            InitializeStreets();
        }

        private void InitializeStreets()
        {
            streets = new List<Street>();
            streets.Add(new Street(4, 6, 50));
            streets.Add(new Street(5, 4, 150));
            streets.Add(new Street(4, 7, 250));
            streets.Add(new Street(350));


        }

        private void ScrollStreets()
        {
            for (int i = 0; i < streets.Count(); i++)
            {
                streets[i].ScrollDown();
                if (streets[i].yPos > Game.CANVAS_HEIGHT + Street.SIZE_Y_STREET)
                {
                    streets.Remove(streets[i]);
                    //Console.WriteLine("Now only has " + streets.Count() + " streets");
                }
            }
        }

        public void ClockTick()
        {
            if (goingDown)
                mainChar.MoveVertical(MainChar.SPEED_DOWN);
            if (goingUp && mainChar.posYGet() > MAX_Y_PLAYER_CAN_GO)
                mainChar.MoveVertical(MainChar.SPEED_UP);
            else if (goingUp && mainChar.posYGet() == MAX_Y_PLAYER_CAN_GO)
                ScrollStreets();
            if (goingLeft)
                mainChar.MoveHorizontal(MainChar.SPEED_LEFT);
            if (goingRight)
                mainChar.MoveHorizontal(MainChar.SPEED_RIGHT);

            foreach(Street street in streets)
            {
                street.StreetRefresh();
            }
        }

        public Directions ReturnPlayerDirection()
        {
            if (goingLeft)
            {
                return Directions.Left;
            }
            else if (goingRight)
            {
                return Directions.Right;
            }
            else if (goingUp)
            {
                return Directions.Up;
            }
            else if (goingDown)
            {
                return Directions.Down;
            }
            return Directions.None;
        }

        //------------------------------------------------------------------------//

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
