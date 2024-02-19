﻿using Microsoft.SqlServer.Server;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//weapons(3 types - common, enchanted(+2 bonus prop), rare(+4 bonus prop)):
//	1.Wand / Staff(common properties)
//        - very Low p/ damage
//		- ManaUp
//		- IntUp
//		- * MagicCrit (5% crt. chanse, 300% crit. damage)
//	2.Dagger(common properties)
//        - low p.damage
//        - normal dex up
//		- dual avalible*
//		- СС + 60% / CD + 70%
//	3. Sword (common properties)
//		-normal p.damage
//        - low dex / str up
//        - shield avalible *
//        -СС + 35 % / CD + 150 %
//    4.Axe(common properties)
//        - high p.damage
//        - high str up
//		- shield awalible
//		- СС + 20% / CD + 170%
//	5. Mace/Hammer
//		- high p.damage
//		- normal str/ HP up
//		- shield awalible
//		- СС + 10% / CD + 250%
//	6. TwoHanded Weapon (common properties)
//		-...
//		-shield not avalible
//		- all common parameters x1.7	without cc & cd

namespace Game.Mongodb
{
    public class Weapon
    {
        public string Name { get; set; }    
        public string Type { get; set; }
        public double PDamage { get; set; }
        public int Vitality { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Intelegence { get; set; }
        public int Manna { get; set; }
        public double Armor { get; set; }
        public double MDamage { get; set; }
        public double MDefence { get; set; }
        public double CrtChanse { get; set; }
        public double CrtDamage { get; set; }
        public int Level { get; set; }
        public int Point { get; set; }
        public int Expirience { get; set; }

        public Weapon(string type) 
        { 
            Type = type;
        }
    }

}
