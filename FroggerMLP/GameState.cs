using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerMLP
{
    class GameState
    {
        /* Constants */
        private const int INITIAL_POS_X = 100;
        private const int INITIAL_POS_Y = 100;



        /* Members */
        public MainChar mainChar { get; set; }



        public GameState()
        {
            this.mainChar = new MainChar(TypeOfEntity.MainChar, INITIAL_POS_X, INITIAL_POS_Y);
        }

    }
}
