﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    class Street
    {
        private const int SIZE_Y_STREET = 64;
        private const int SIZE_X_STREET = Game.CANVAS_WIDTH;

        private List<Car> streetCars;
        private int maxNumOfCars;
        private int carSpeed;
        public int yPos { get; set; }
        private int yPositionCars;

        public Street(int maxNumOfCars, int carSpeed, int yPos)
        {
            this.carSpeed = carSpeed;
            this.maxNumOfCars = maxNumOfCars;
            this.streetCars = new List<Car>();
            this.yPos = yPos;
            this.yPositionCars = yPos + ((SIZE_Y_STREET - Car.HITBOX_Y_CAR) / 2);
            InitializeStreet();
        }

        private void InitializeStreet()
        {
            int spaceBetweenCars = Game.CANVAS_WIDTH / maxNumOfCars;
            for(int i = 0; i < maxNumOfCars; i++)
            {
                streetCars.Add(new Car(TypeOfEntity.Car, spaceBetweenCars * i, yPositionCars));
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
                this.streetCars.Add(new Car(TypeOfEntity.Car, -1 * Car.HITBOX_X_CAR, yPositionCars));
            }
        }

        public List<Car> streetCarsGet()
        {
            return streetCars;
        }
    }
}
