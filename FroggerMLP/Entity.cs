﻿using System;
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
        protected int posX;
        protected int posY;

        /* Methods */
        //Constructor
        public Entity(TypeOfEntity typeOfEntity, int posX, int posY)
        {
            this.typeOfEntity = typeOfEntity;
            this.posX = posX;
            this.posY = posY;
        }

        public void posXSet(int value)
        {
            this.posX = value;
        }

        public void posYSet(int value)
        {
            this.posY = value;
        }

        public int posYGet()
        {
            return this.posY;
        }

        public int posXGet()
        {
            return this.posX;
        }
    }
}
