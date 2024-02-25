using Game.Mongodb;
using Game.Mongodb.Weapons;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.RightsManagement;
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
    /// Логика взаимодействия для WeaponPage.xaml
    /// </summary>
    public partial class WeaponPage : Page
    {
        
        public WeaponPage()
        {
            InitializeComponent();
            txtName.Text = App.character.Name;
            
        }
        
        // к основному PDamage добавляется 2 очка

        private void btnWand_Click(object sender, RoutedEventArgs e)
        {

            if(App.character.Weapon != null)
            {
                if (App.character.Weapon.Name == "Wand")
                    MessageBox.Show("Низя..");
                else
                {
                    App.character.PDamage -= App.character.Weapon.PDamage;
                    App.character.Weapon = null;

                    Wand wand = new Wand("Common");

                    App.character.Weapon = wand;
                    App.character.PDamage = App.character.PDamage + wand.PDamage;
                    CRUD.Put("Characters", "CharacterCollection", App.character.Name, App.character);
                }


            }
            else
            {
                Wand wand = new Wand("Common");
                App.character.Weapon = wand;
                App.character.PDamage = App.character.PDamage + wand.PDamage;
                CRUD.Put("Characters", "CharacterCollection", App.character.Name, App.character);
            }

        }

        private void btnDagger_Click(object sender, RoutedEventArgs e)
        {
            if(App.character.Weapon != null)
            {
                if (App.character.Weapon.Name == "Dagger")
                    MessageBox.Show("Низя..");
                else
                {
                    App.character.PDamage -= App.character.Weapon.PDamage;
                    App.character.Weapon = null;

                    Dagger dagger = new Dagger("Common");
                    App.character.Weapon = dagger;
                    App.character.PDamage = App.character.PDamage + dagger.PDamage;
                    CRUD.Put("Characters", "CharacterCollection", App.character.Name, App.character);
                }

            }
            else
            {
                Dagger dagger = new Dagger("Common");
                App.character.Weapon = dagger;
                App.character.PDamage = App.character.PDamage + dagger.PDamage;
                CRUD.Put("Characters", "CharacterCollection", App.character.Name, App.character);
            }
        }

        private void btnSword_Click(object sender, RoutedEventArgs e)
        {
            App.character.Weapon = null;
        }

        private void btnAxe_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NotBaseStatpointsPage());
        }

        private void btnMace_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NotBaseStatpointsPage());
        }

        private void btnTwoHandedWeapon_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NotBaseStatpointsPage());
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Characters");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var filter = new BsonDocument();
            var result = collection.Find(filter).ToList();

            var pers = result.FirstOrDefault(x => x.Name == name);
            App.character = pers;
            NavigationService.Navigate(new NotBaseStatpointsPage());
        }
    }
}
