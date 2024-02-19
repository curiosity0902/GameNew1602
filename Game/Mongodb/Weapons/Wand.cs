using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Mongodb.Weapons
{
    public class Wand : Weapon
    {


        public Wand(string type) : base(type)
        {
            Name = "Wand";
            Intelegence = 3;
            Manna = 3;
            PDamage = 1;

            if (type == "Common")
            {
                Name = "Wand";
                CrtChanse = 1;
                CrtDamage = 1;
            }

            if (type == "Enchanted")
            {
                Name = "Enchanted Wand";
                CrtChanse = 1.5;
                CrtDamage = 4;
            }
            if (type == "Rare")
            {
                Name = "Rare Wand";
                Intelegence += 2;
                Manna += 2;
                PDamage += 2;
                Strenght += 2;
                CrtChanse = 1;
                CrtDamage = 1;
            }

        }
    }
}
