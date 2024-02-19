using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Mongodb.Weapons
{
    public class Dagger: Weapon
    {

        public Dagger(string type) : base(type)
        {
            Name = "Dagger";
            Dexterity = 3;
            PDamage = 2;

            if (type == "Common")
            {
                Name = "Dagger";
                CrtChanse = 2;
                CrtDamage = 2;
            }

            if (type == "Enchanted")
            {
                Name = "Enchanted Wand";
                CrtChanse = 1.05;
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
