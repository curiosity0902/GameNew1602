﻿using Game.Mongodb;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [BsonIgnoreExtraElements]
    public class Character
    {

        public Weapon Weapon { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public int MaxVitality { get; set; }
        public int MaxDexterity { get; set; }
        public int MaxStrength { get; set; }
        public int MaxIntelegence { get; set; }
        public int Vitality { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }   
        public int Intelegence { get; set; }
        public double PDamage { get; set; }
        public double Armor { get; set; }
        public double MDamage { get; set; }
        public double MDefence { get; set; }
        public double CrtChanse { get; set; }
        public double CrtDamage { get; set; }
        public int Level { get; set; }
        public int Point { get; set; }
        public int Expirience { get; set; }


        public double Heath { get; set; }
        public double Manna { get; set; }
        public Character(string name, string classname, int strenght, int maxStrenght, int dexterity, int maxDexterity, 
            int intelegence, int maxIntelegence, int vitality, int maxVitality, double health, double manna, 
            double pdamage, double armor, double mdamage, double mdefence, double crtchanse, double crtmdamage, int point, int level, int expirience)
        {
            Name = name;
            ClassName = classname;
            Strenght = strenght;
            MaxStrength = maxStrenght;
            Dexterity = dexterity;
            MaxDexterity = maxDexterity;
            Intelegence = intelegence;
            MaxIntelegence = maxIntelegence;
            Vitality = vitality;
            MaxVitality = maxVitality;
            Heath = health ;
            Manna = manna;
            PDamage = pdamage;
            Armor = armor;
            MDamage = mdamage;
            MDefence = mdefence;
            CrtChanse = crtchanse;
            CrtDamage = crtmdamage;
            Point = point;
            Level = level;
            Expirience = expirience;
        }
        
    }
}
