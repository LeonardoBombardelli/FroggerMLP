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

    abstract class Entity
    {
        /* Members */
        public TypeOfEntity typeOfEntity;
        public int posX;
        public int posY;

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
