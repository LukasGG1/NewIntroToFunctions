using System;
using System.Collections.Generic;
using System.Text;

namespace NewIntroToFunctions
{
    class Enemy
    {
        Random random = new Random();
        public string name = " ";
        public float health = 10;
        public float damage = 5;
        public float DodgeChance = 10;
        public float HitChance = 10;
        public string weakness = "None";

        public Enemy()
        {

        }
    }
}
