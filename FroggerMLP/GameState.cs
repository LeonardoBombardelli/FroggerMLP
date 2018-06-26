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

    enum StreetStates
    {
        Normal,
        Safe,
        Cars
    }

    class GameState
    {

        public const int MAX_Y_PLAYER_CAN_GO = 400;
        private const int NUMBER_OF_TYPER_STREETS = 3;
        private const int NUMBER_MAX_SAME_STREET = 3;  

        /* Members */
        public MainChar mainChar { get; set; }
        public List<Street> streets { get; set; }

        private int scrollValue;
        private Random rnd;
        private bool isMovingStreets = false;
        private List<StreetStates> last3States;

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
            last3States = new List<StreetStates>();
            scrollValue = Game.CANVAS_HEIGHT;
            rnd = new Random();
            streets = new List<Street>();
            for (int i = 0; i < NUMBER_MAX_SAME_STREET; i++)
                streets.Add(GenerateInitialStreets());

            while (scrollValue + Street.SIZE_Y_STREET > 0)
            {
                streets.Add(GenerateStreet());
            }

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

       private Street GenerateStreet()
        {
            int typeOfStreet = rnd.Next(NUMBER_OF_TYPER_STREETS);
            StreetStates lastState = LastStates();
            last3States.RemoveAt(0); //Removes last occurence of state, so we can put a new one
            if (lastState == StreetStates.Normal)
                return GenerateRandomStreet();
            else if (lastState == StreetStates.Cars)
                return GenerateSafeStreet();
            else
                return GenerateCarStreet();
        }

        private Street GenerateInitialStreets()
        {
            last3States.Add(StreetStates.Safe);
            int scrollValueOld = scrollValue;
            scrollValue -= Street.SIZE_Y_STREET;
            return new Street(scrollValueOld);
        }

        private StreetStates LastStates()
        {
            StreetStates firstState = last3States[0];
            bool sameState = true;
            for (int i = 1; i < NUMBER_MAX_SAME_STREET; i++)
            {
                if (firstState != last3States[i]) sameState = false;
            }
            if (sameState) return firstState;
            else return StreetStates.Normal;
        }

        private Street GenerateRandomStreet()
        {
            int typeOfStreet = rnd.Next(NUMBER_OF_TYPER_STREETS);
            if (typeOfStreet == 0)
                return GenerateSafeStreet();
            else return GenerateCarStreet();
        }

        private Street GenerateSafeStreet()
        {
            last3States.Add(StreetStates.Safe);
            int scrollValueOld = scrollValue;
            scrollValue -= Street.SIZE_Y_STREET;
            return new Street(scrollValueOld);
        }

        private Street GenerateCarStreet()
        {
            last3States.Add(StreetStates.Cars);
            int scrollValueOld = scrollValue;
            scrollValue -= Street.SIZE_Y_STREET;
            int typeOfStreet = rnd.Next(NUMBER_OF_TYPER_STREETS);
            if (typeOfStreet == 0)
                return new Street(4, 12, scrollValueOld);
            else if (typeOfStreet == 1)
                return new Street(5, 8, scrollValueOld);
            else
                return new Street(4, 14, scrollValueOld);
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
                foreach(Car car in street.streetCarsGet())
                {
                    if (CheckCollision(mainChar, car))
                        ResetGame();
                }
            }

            isMovingStreets = true;

            foreach(Street street in streets)
            {
                street.StreetRefresh();
            }

            if (scrollValue < 0)
            {
                streets.Add(GenerateStreet());
            }

            isMovingStreets = false;
        }

        private bool CheckCollision(MainChar mainChar, Car car)
        {
            if (CheckCollisionPlane(mainChar.posXGet(), MainChar.SIZE_PLAYER_HORIZONTAL, car.posXGet(), Car.HITBOX_X_CAR)
                    && CheckCollisionPlane(mainChar.posYGet(), MainChar.SIZE_PLAYER_VERTICAL, car.posYGet(), Car.HITBOX_Y_CAR))
                return true;
            return false;

        }

        private bool CheckCollisionPlane(int x1, int size1, int x2, int size2)
        {
            if ((x1 > x2 && x1 < x2 + size2) || (x1 + size1 > x2 && x1 + size1 < x2 + size2))
                return true;
            return false;
        }

        private void ResetGame()
        {
            System.Threading.Thread.Sleep(1000);
            mainChar.posXSet(MainChar.INITIAL_POS_X);
            mainChar.posYSet(MainChar.INITIAL_POS_Y);
            InitializeStreets();
        }

        public bool CanLoadFrames()
        {
            return !isMovingStreets;
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
