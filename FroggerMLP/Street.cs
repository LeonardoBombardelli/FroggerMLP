using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    class Street
    {
        private List<Car> streetCars;
        private int maxNumOfCars;
        private int carSpeed;
        private int yPos;

        public Street(int maxNumOfCars, int carSpeed, int yPos)
        {
            this.carSpeed = carSpeed;
            this.maxNumOfCars = maxNumOfCars;
            this.streetCars = new List<Car>();
            this.yPos = yPos;
            InitializeStreet();
        }

        private void InitializeStreet()
        {
            int spaceBetweenCars = Game.CANVAS_WIDTH / maxNumOfCars;
            for(int i = 0; i < maxNumOfCars; i++)
            {
                streetCars.Add(new Car(TypeOfEntity.Car, spaceBetweenCars * i, yPos));
            }
        }

        public void StreetRefresh()
        {
            for(int i = 0; i < streetCars.Count(); i++)
            {
                streetCars[i].MoveHorizontal(carSpeed);
                if(streetCars[i].GotOutOfScene())
                {
                    streetCars.RemoveAt(i);
                }
            }
            if (this.streetCars.Count() < maxNumOfCars)
            {
                this.streetCars.Add(new Car(TypeOfEntity.Car, Car.HITBOX_X_CAR, yPos));
            }
        }

        public List<Car> streetCarsGet()
        {
            return streetCars;
        }
    }
}
