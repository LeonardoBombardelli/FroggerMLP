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
        }

        public void StreetRefresh()
        {
            foreach(Car car in this.streetCars)
            {
                car.MoveHorizontal(carSpeed);
            }
        }


    }
}
