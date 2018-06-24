using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    enum TypeOfEntity
    {
        MainChar,
        Car,
        Obstacle
    }

    class Entity
    {
        /* Members */
        private TypeOfEntity typeOfEntity { get; set; }
        private int posX { get; set; }
        p int posY { get; set; }

        /* Methods */
        //Constructor
        public Entity(TypeOfEntity typeOfEntity, int posX, int posY)
        {
            this.typeOfEntity = typeOfEntity;
            this.posX = posX;
            this.posY = posY;
        }
    }
}
