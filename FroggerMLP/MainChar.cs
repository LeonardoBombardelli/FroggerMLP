using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    class MainChar : MovingEntity
    {
        public MainChar(TypeOfEntity typeOfEntity, int posX, int posY) : base(typeOfEntity, posX, posY)
        {
            this.typeOfEntity = TypeOfEntity.MainChar;
        }
    }
}
