using System;
using System.Collections.Generic;
using System.Text;

namespace NewIntroToFunctions
{
    class PossessedSteelArmor : Enemy
    {
        public PossessedSteelArmor()
        {
            name = "PossessedSteelArmor";
            health = 10;
            DodgeChance = 10;
            HitChance = 10;
            weakness = "fire and ice";
        }
    }
}

