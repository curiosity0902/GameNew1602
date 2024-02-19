﻿using Game.Mongodb;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Game.Pages
{
    /// <summary>
    /// Логика взаимодействия для NotBaseStatpointsPage.xaml
    /// </summary>
    public partial class NotBaseStatpointsPage : Page
    {
        public NotBaseStatpointsPage()
        {
            InitializeComponent();
                if (App.character.Weapon != null &&  App.character.ClassName == "Warrior" || App.character.ClassName == "Warrior" && App.character.Weapon == null)
                {
                    txtName.Text = App.character.Name;
                    StrengthTb.Text = Convert.ToString((App.character.Strenght).ToString("0.####"));
                    DexterityTb.Text = Convert.ToString(App.character.Dexterity);
                    IntelegenceTb.Text = Convert.ToString(App.character.Intelegence);
                    VitalityTb.Text = Convert.ToString(App.character.Vitality);

                    PointsTb.Text = Convert.ToString(App.character.Point);
                    LevelTb.Text = Convert.ToString(App.character.Level);

                    HealthTB.Text = Convert.ToString(App.character.Vitality * 2 + (App.character.Strenght));
                    //HealthTB.Text = Convert.ToString(App.character.Heath);
                    MannaTB.Text = Convert.ToString(App.character.Intelegence);


                    //PDamageTb.Text = Convert.ToString(App.character.Strenght);
                    PDamageTb.Text = Convert.ToString(App.character.PDamage);

                    ArmorTb.Text = Convert.ToString(App.character.Dexterity);
                    MDamageTb.Text = Convert.ToString((App.character.Intelegence * 0.2).ToString("0"));
                    MDefenceTb.Text = Convert.ToString(App.character.Intelegence * 0.5);
                    CRTChanseTb.Text = Convert.ToString(App.character.Dexterity * 0.2);
                    CRTDamageTb.Text = Convert.ToString(App.character.Dexterity);
                    exptxt.Text = Convert.ToString(App.character.Expirience);
                ObnovBD();

                }
                else if (App.character.Weapon != null && App.character.ClassName == "Rogue" || App.character.ClassName == "Rogue" && App.character.Weapon == null)
                {
                    txtName.Text = App.character.Name;
                    StrengthTb.Text = Convert.ToString(App.character.Strenght);
                    DexterityTb.Text = Convert.ToString(App.character.Dexterity);
                    IntelegenceTb.Text = Convert.ToString(App.character.Intelegence);
                    VitalityTb.Text = Convert.ToString(App.character.Vitality);

                    PointsTb.Text = Convert.ToString(App.character.Point);
                    LevelTb.Text = Convert.ToString(App.character.Level);

                    HealthTB.Text = Convert.ToString(App.character.Vitality * 1.5 + (App.character.Strenght * 0.5));
                    MannaTB.Text = Convert.ToString(App.character.Intelegence * 1.2);

                   PDamageTb.Text = Convert.ToString(App.character.PDamage);
                  //PDamageTb.Text = Convert.ToString(App.character.Strenght * 0.5 + App.character.Dexterity * 0.5);

                ArmorTb.Text = Convert.ToString(App.character.Dexterity * 1.5);
                    MDamageTb.Text = Convert.ToString(App.character.Intelegence * 0.2);
                    MDefenceTb.Text = Convert.ToString(App.character.Intelegence * 0.5);
                    CRTChanseTb.Text = Convert.ToString(App.character.Dexterity * 0.2);
                    CRTDamageTb.Text = Convert.ToString(App.character.Dexterity);
                    exptxt.Text = Convert.ToString(App.character.Expirience);
                ObnovBD();

            }
                else if (App.character.Weapon != null && App.character.ClassName == "Wizard" || App.character.ClassName == "Wizard" && App.character.Weapon == null)
                {
                    txtName.Text = App.character.Name;
                    StrengthTb.Text = Convert.ToString(App.character.Strenght);
                    DexterityTb.Text = Convert.ToString(App.character.Dexterity);
                    IntelegenceTb.Text = Convert.ToString(App.character.Intelegence);
                    VitalityTb.Text = Convert.ToString(App.character.Vitality);

                    PointsTb.Text = Convert.ToString(App.character.Point);
                    LevelTb.Text = Convert.ToString(App.character.Level);

                    HealthTB.Text = Convert.ToString(App.character.Vitality * 1.4 + (App.character.Strenght * 0.2));
                    MannaTB.Text = Convert.ToString(App.character.Intelegence * 1.5);

                    //PDamageTb.Text = Convert.ToString(App.character.Strenght * 0.5);
                    PDamageTb.Text = Convert.ToString(App.character.PDamage);

                    ArmorTb.Text = Convert.ToString(App.character.Dexterity);
                    MDamageTb.Text = Convert.ToString(App.character.Intelegence);
                    MDefenceTb.Text = Convert.ToString(App.character.Intelegence);
                    CRTChanseTb.Text = Convert.ToString(App.character.Dexterity * 0.2);
                    CRTDamageTb.Text = Convert.ToString(App.character.Dexterity);
                    exptxt.Text = Convert.ToString(App.character.Expirience);
                ObnovBD();

            }
        }
            

        private void btnCreate_Click(object sender, RoutedEventArgs e) //КНОПКА СОХРАНЕНИЯ
        {
            if (txtName.Text != "")
            {
                var client = new MongoClient("mongodb://localhost");
                var database = client.GetDatabase("Characters");
                var collection = database.GetCollection<Character>("CharacterCollection");

                var filterName = Builders<Character>.Filter.Eq("Name", App.character.Name);
                var filtersStrenght = Builders<Character>.Filter.Eq("Strenght", App.character.Strenght);
                var filtersIntelegence = Builders<Character>.Filter.Eq("Intelegence", App.character.Intelegence);
                var filtersDexterity = Builders<Character>.Filter.Eq("Dexterity", App.character.Dexterity);
                var filtersVitality = Builders<Character>.Filter.Eq("Vitality", App.character.Vitality);
                var filtersHealth = Builders<Character>.Filter.Eq("Heath", App.character.Heath);
                var filtersManna = Builders<Character>.Filter.Eq("Manna", App.character.Manna);
                var filtersPDamage = Builders<Character>.Filter.Eq("PDamage", App.character.PDamage);
                var filtersArmor = Builders<Character>.Filter.Eq("Armor", App.character.Armor);
                var filtersMDamage = Builders<Character>.Filter.Eq("MDamage", App.character.MDamage);
                var filtersMDefense = Builders<Character>.Filter.Eq("MDefence", App.character.MDefence);
                var filtersCRTChanse = Builders<Character>.Filter.Eq("CrtChanse", App.character.CrtChanse);
                var filtersCRTDamage = Builders<Character>.Filter.Eq("CrtDamage", App.character.CrtDamage);
                var filtersPoint = Builders<Character>.Filter.Eq("Point", App.character.Point);
                var filtersLevel = Builders<Character>.Filter.Eq("Level", App.character.Level);

                // параметр обновления
                var update = Builders<Character>.Update.Set("Name", txtName.Text);
                var updateStrenght = Builders<Character>.Update.Set("Strenght", Convert.ToInt32(StrengthTb.Text));
                var updateIntelegence = Builders<Character>.Update.Set("Intelegence", Convert.ToInt32(IntelegenceTb.Text));
                var updateDexterity = Builders<Character>.Update.Set("Dexterity", Convert.ToInt32(DexterityTb.Text));
                var updateVitality = Builders<Character>.Update.Set("Vitality", Convert.ToInt32(VitalityTb.Text));
                var updateHealth = Builders<Character>.Update.Set("Heath", Convert.ToDouble(HealthTB.Text));
                var updateManna = Builders<Character>.Update.Set("Manna", Convert.ToDouble(MannaTB.Text));

                var updatePDamage = Builders<Character>.Update.Set("PDamage", Convert.ToDouble(PDamageTb.Text));

                var updateArmor = Builders<Character>.Update.Set("Armor", Convert.ToDouble(ArmorTb.Text));
                var updateMDamage = Builders<Character>.Update.Set("MDamage", Convert.ToDouble(MDamageTb.Text));
                var updateMDefense = Builders<Character>.Update.Set("MDefence", Convert.ToDouble(MDefenceTb.Text));
                var updateCRTChanse = Builders<Character>.Update.Set("CrtChanse", Convert.ToDouble(CRTChanseTb.Text));
                var updateCRTDamage = Builders<Character>.Update.Set("CrtDamage", Convert.ToDouble(CRTDamageTb.Text));
                var updatePoint = Builders<Character>.Update.Set("Point", Convert.ToInt32(PointsTb.Text));
                var updateLevel = Builders<Character>.Update.Set("Level", Convert.ToInt32(LevelTb.Text));

                collection.UpdateOneAsync(filterName, update);
                collection.UpdateOneAsync(filtersStrenght, updateStrenght);
                collection.UpdateOneAsync(filtersIntelegence, updateIntelegence);
                collection.UpdateOneAsync(filtersDexterity, updateDexterity);
                collection.UpdateOneAsync(filtersVitality, updateVitality);

                collection.UpdateOneAsync(filtersHealth, updateHealth);
                collection.UpdateOneAsync(filtersManna, updateManna);

                collection.UpdateOneAsync(filtersPDamage, updatePDamage);

                collection.UpdateOneAsync(filtersArmor, updateArmor);
                collection.UpdateOneAsync(filtersMDamage, updateMDamage);
                collection.UpdateOneAsync(filtersMDefense, updateMDefense);
                collection.UpdateOneAsync(filtersCRTChanse, updateCRTChanse);
                collection.UpdateOneAsync(filtersCRTDamage, updateCRTDamage);
                collection.UpdateOneAsync(filtersPoint, updatePoint);
                collection.UpdateOneAsync(filtersLevel, updateLevel);

                Refresh();
        
                MessageBox.Show("ok");

            }
            else
                MessageBox.Show("!!!");
        }


        public void Refresh()
        {
            App.character.Name = txtName.Text;

            App.character.Strenght = Convert.ToInt32(StrengthTb.Text);
            App.character.Intelegence = Convert.ToInt32(IntelegenceTb.Text);
            App.character.Dexterity = Convert.ToInt32(DexterityTb.Text);
            App.character.Vitality = Convert.ToInt32(VitalityTb.Text);

            App.character.Heath = Convert.ToDouble(HealthTB.Text);
            App.character.Manna = Convert.ToDouble(MannaTB.Text);

            App.character.PDamage = Convert.ToDouble(PDamageTb.Text);

            App.character.Armor = Convert.ToDouble(ArmorTb.Text);
            App.character.MDamage = Convert.ToDouble(MDamageTb.Text); 
            App.character.MDefence = Convert.ToDouble(MDefenceTb.Text);
            App.character.CrtChanse = Convert.ToDouble(CRTChanseTb.Text);
            App.character.CrtDamage = Convert.ToDouble(CRTDamageTb.Text);
            App.character.Point = Convert.ToInt32(PointsTb.Text);
            App.character.Level = Convert.ToInt32(LevelTb.Text);
            App.character.Expirience = Convert.ToInt32(exptxt.Text);
            NavigationService.Navigate(new NotBaseStatpointsPage());
        }

        public void ObnovBD()
        {
            if (txtName.Text != "")
            {
                var client = new MongoClient("mongodb://localhost");
                var database = client.GetDatabase("Characters");
                var collection = database.GetCollection<Character>("CharacterCollection");

                var filterName = Builders<Character>.Filter.Eq("Name", App.character.Name);
                var filtersStrenght = Builders<Character>.Filter.Eq("Strenght", App.character.Strenght);
                var filtersIntelegence = Builders<Character>.Filter.Eq("Intelegence", App.character.Intelegence);
                var filtersDexterity = Builders<Character>.Filter.Eq("Dexterity", App.character.Dexterity);
                var filtersVitality = Builders<Character>.Filter.Eq("Vitality", App.character.Vitality);
                var filtersHealth = Builders<Character>.Filter.Eq("Heath", App.character.Heath);
                var filtersManna = Builders<Character>.Filter.Eq("Manna", App.character.Manna);
                var filtersPDamage = Builders<Character>.Filter.Eq("PDamage", App.character.PDamage);
                var filtersArmor = Builders<Character>.Filter.Eq("Armor", App.character.Armor);
                var filtersMDamage = Builders<Character>.Filter.Eq("MDamage", App.character.MDamage);
                var filtersMDefense = Builders<Character>.Filter.Eq("MDefence", App.character.MDefence);
                var filtersCRTChanse = Builders<Character>.Filter.Eq("CrtChanse", App.character.CrtChanse);
                var filtersCRTDamage = Builders<Character>.Filter.Eq("CrtDamage", App.character.CrtDamage);
                var filtersPoint = Builders<Character>.Filter.Eq("Point", App.character.Point);
                var filtersLevel = Builders<Character>.Filter.Eq("Level", App.character.Level);

                // параметр обновления
                var update = Builders<Character>.Update.Set("Name", txtName.Text);
                var updateStrenght = Builders<Character>.Update.Set("Strenght", Convert.ToInt32(StrengthTb.Text));
                var updateIntelegence = Builders<Character>.Update.Set("Intelegence", Convert.ToInt32(IntelegenceTb.Text));
                var updateDexterity = Builders<Character>.Update.Set("Dexterity", Convert.ToInt32(DexterityTb.Text));
                var updateVitality = Builders<Character>.Update.Set("Vitality", Convert.ToInt32(VitalityTb.Text));
                var updateHealth = Builders<Character>.Update.Set("Heath", Convert.ToDouble(HealthTB.Text));
                var updateManna = Builders<Character>.Update.Set("Manna", Convert.ToDouble(MannaTB.Text));

                var updatePDamage = Builders<Character>.Update.Set("PDamage", Convert.ToDouble(PDamageTb.Text));

                var updateArmor = Builders<Character>.Update.Set("Armor", Convert.ToDouble(ArmorTb.Text));
                var updateMDamage = Builders<Character>.Update.Set("MDamage", Convert.ToDouble(MDamageTb.Text));
                var updateMDefense = Builders<Character>.Update.Set("MDefence", Convert.ToDouble(MDefenceTb.Text));
                var updateCRTChanse = Builders<Character>.Update.Set("CrtChanse", Convert.ToDouble(CRTChanseTb.Text));
                var updateCRTDamage = Builders<Character>.Update.Set("CrtDamage", Convert.ToDouble(CRTDamageTb.Text));
                var updatePoint = Builders<Character>.Update.Set("Point", Convert.ToInt32(PointsTb.Text));
                var updateLevel = Builders<Character>.Update.Set("Level", Convert.ToInt32(LevelTb.Text));

                var filtersExpirience = Builders<Character>.Filter.Eq("Expirience", App.character.Expirience); //фИЛЬР ПОИСКА
                var updateExpirience = Builders<Character>.Update.Set("Expirience", Convert.ToInt32(exptxt.Text));

                collection.UpdateOneAsync(filtersExpirience, updateExpirience);

                collection.UpdateOneAsync(filterName, update);
                collection.UpdateOneAsync(filtersStrenght, updateStrenght);
                collection.UpdateOneAsync(filtersIntelegence, updateIntelegence);
                collection.UpdateOneAsync(filtersDexterity, updateDexterity);
                collection.UpdateOneAsync(filtersVitality, updateVitality);

                collection.UpdateOneAsync(filtersHealth, updateHealth);
                collection.UpdateOneAsync(filtersManna, updateManna);

                collection.UpdateOneAsync(filtersPDamage, updatePDamage);

                collection.UpdateOneAsync(filtersArmor, updateArmor);
                collection.UpdateOneAsync(filtersMDamage, updateMDamage);
                collection.UpdateOneAsync(filtersMDefense, updateMDefense);
                collection.UpdateOneAsync(filtersCRTChanse, updateCRTChanse);
                collection.UpdateOneAsync(filtersCRTDamage, updateCRTDamage);
                collection.UpdateOneAsync(filtersPoint, updatePoint);
                collection.UpdateOneAsync(filtersLevel, updateLevel);
            }
        }
        private void PlusStrenghbtn_Click(object sender, RoutedEventArgs e)
        {
            //int maxStrenght = Convert.ToInt32(App.character.MaxStrength);

            int point = Convert.ToInt32(App.character.Point);
            int minStrenght = Convert.ToInt32(App.character.Strenght);
            int pdm = Convert.ToInt32(App.character.PDamage);
            int maxStrenght = Convert.ToInt32(App.character.MaxStrength);
            if (minStrenght < maxStrenght && point >= 1 && App.character.Weapon == null)
            {
                StrengthTb.Text = Convert.ToString(App.character.Strenght + 1);
                PointsTb.Text = Convert.ToString(App.character.Point - 1);
                PDamageTb.Text = Convert.ToString(double.Parse(StrengthTb.Text));
                minStrenght += 1;
                point -= 1;
                ObnovBD();
                Refresh();
            }
            else if (minStrenght < maxStrenght && point >= 1 && App.character.Weapon != null)
            {
                StrengthTb.Text = Convert.ToString(App.character.Strenght + 1);
                PointsTb.Text = Convert.ToString(App.character.Point - 1);
                PDamageTb.Text = Convert.ToString(App.character.PDamage + 1);
                minStrenght += 1;
                point -= 1;

                ObnovBD();
                Refresh();
            }
            else
            {
                MessageBox.Show("Stop");
            }
        }

        private void MinusStrenghbtn_Click(object sender, RoutedEventArgs e)
        {
            int point = Convert.ToInt32(App.character.Point);
            int strenght = Convert.ToInt32(App.character.Strenght);

            if (strenght >= 1)
            {
                StrengthTb.Text = Convert.ToString(App.character.Strenght - 1);
                PointsTb.Text = Convert.ToString(App.character.Point + 1);
                strenght -= 1;
                point += 1;

                ObnovBD();
                Refresh();
            }
            else
                MessageBox.Show("НЕ МОЖЕТ БЫТЬ 0");
        }

        private void PlusDexteritybtn_Click(object sender, RoutedEventArgs e)
        {
            int point = Convert.ToInt32(App.character.Point);
            int minDexterity = Convert.ToInt32(App.character.Dexterity);
            int maxDexterity = Convert.ToInt32(App.character.MaxDexterity);
            if (minDexterity < maxDexterity && point >= 1)
            {
                DexterityTb.Text = Convert.ToString(App.character.Dexterity + 1);
                PointsTb.Text = Convert.ToString(App.character.Point - 1);
                minDexterity += 1;
                point -= 1;

                ObnovBD();
                Refresh();
            }
            else
            {
                MessageBox.Show("Stop");
            }           
        }

        private void MinusDexteritybtn_Click(object sender, RoutedEventArgs e)
        {

            int point = Convert.ToInt32(App.character.Point);
            int dexterity = Convert.ToInt32(App.character.Dexterity);

            if (dexterity >= 1)
            {
                DexterityTb.Text = Convert.ToString(App.character.Dexterity - 1);
                PointsTb.Text = Convert.ToString(App.character.Point + 1);
                dexterity -= 1;
                point += 1;

                ObnovBD();
                Refresh();
            }
            else
                MessageBox.Show("НЕ МОЖЕТ БЫТЬ 0");
        }

        private void PlusIntelegencebtn_Click(object sender, RoutedEventArgs e)
        {
            int point = Convert.ToInt32(App.character.Point);
            int minIntelegence = Convert.ToInt32(App.character.Intelegence);
            int maxIntelegence = Convert.ToInt32(App.character.MaxIntelegence);
            if (minIntelegence < maxIntelegence && point >= 1)
            {
                IntelegenceTb.Text = Convert.ToString(App.character.Intelegence + 1);
                PointsTb.Text = Convert.ToString(App.character.Point - 1);
                minIntelegence += 1;
                point -= 1;

                ObnovBD();
                Refresh();
            }
            else
            {
                MessageBox.Show("Stop");
            }
        }

        private void MinusIntelegencebtn_Click(object sender, RoutedEventArgs e)
        {
            int point = Convert.ToInt32(App.character.Point);
            int intelegence = Convert.ToInt32(App.character.Intelegence);

            if (intelegence >= 1)
            {
                IntelegenceTb.Text = Convert.ToString(App.character.Intelegence - 1);
                PointsTb.Text = Convert.ToString(App.character.Point + 1);
                intelegence -= 1;
                point += 1;

                ObnovBD();
                Refresh();
            }
            else
                MessageBox.Show("НЕ МОЖЕТ БЫТЬ 0");
        }

        private void PlusVitalitybtn_Click(object sender, RoutedEventArgs e)
        {
            int point = Convert.ToInt32(App.character.Point);
            int minVitality = Convert.ToInt32(App.character.Vitality);
            int maxVitality = Convert.ToInt32(App.character.MaxVitality);
            if (minVitality < maxVitality && point >= 1)
            {
                VitalityTb.Text = Convert.ToString(App.character.Vitality + 1);
                PointsTb.Text = Convert.ToString(App.character.Point - 1);
                minVitality += 1;
                point -= 1;

                ObnovBD();
                Refresh();
            }
            else
            {
                MessageBox.Show("Stop");
            }
        }

        private void MinusVitalitybtn_Click(object sender, RoutedEventArgs e)
        {
            int point = Convert.ToInt32(App.character.Point);
            int vitality = Convert.ToInt32(App.character.Vitality);

            if (vitality >= 1)
            {
                VitalityTb.Text = Convert.ToString(App.character.Vitality - 1);
                PointsTb.Text = Convert.ToString(App.character.Point + 1);
                vitality -= 1;
                point += 1;

                ObnovBD();
                Refresh();
            }
            else
                MessageBox.Show("НЕ МОЖЕТ БЫТЬ 0");
        }

        private void Levelbtn_Click(object sender, RoutedEventArgs e)
        {
            int expupp = Convert.ToInt32(App.character.Expirience);
            int lever = Convert.ToInt32(App.character.Level);
            int point = Convert.ToInt32(App.character.Point);

            if (expupp - lever  * 1000 >= 0) 
            {
                if (lever < 10)
                {
                    expupp = expupp + 1000 * (lever + 1);
                    lever++;
                    point += 5;

                    exptxt.Text = Convert.ToString(expupp);
                    LevelTb.Text = Convert.ToString(App.character.Level + 1);
                    PointsTb.Text = Convert.ToString(App.character.Point + 5);

                    ObnovBD();
                    Refresh();
                    MessageBox.Show("Уровень обновлен!");

                }
                else
                    MessageBox.Show("Максимальный уровень!");

            }
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Characters());
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            string name  = txtName.Text;
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Characters");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var filter = new BsonDocument();
            var result = collection.Find(filter).ToList();

            var pers = result.FirstOrDefault(x => x.Name == name);
            App.character = pers;

            NavigationService.Navigate(new WeaponPage());

           
        }
    }
}
