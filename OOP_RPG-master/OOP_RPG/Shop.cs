using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class Shop
    {
        List<Weapon> Weapons { get; set; }
        List<Armor> Armors { get; set; }
        List<Potion> Potions { get; set; }
        public Hero Hero { get; set; }
        public Game Game { get; set; }
        public Shop(Hero hero, Game game)
        {
            this.Weapons = new List<Weapon>();
            this.Armors = new List<Armor>();
            this.Potions = new List<Potion>();
            this.Hero = hero;
            this.Game = game;
            this.Weapons.Add(new Weapon("Axe", 12, 3, 4));
            this.Weapons.Add(new Weapon("LongsWord", 20, 5, 7));
            this.Weapons.Add(new Weapon("Sword", 10, 2, 3));

            this.Armors.Add(new Armor("Wooden Armor", 10, 2, 3));
            this.Armors.Add(new Armor("Metal Armor", 20, 5, 7));

            this.Potions.Add(new Potion(5, "Healing Potion", 2, 3));
        }

        public void Main()
        {
            this.Game.Main();
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to my shop! What would you like to do?");
            Console.WriteLine("1.Buy Item");
            Console.WriteLine("2.Sell Item");
            Console.WriteLine("Return to Game Menu");
            var input = Console.ReadLine();
            if (input == "1")
            {
                this.ShowInventory();
            }
            else if (input == "2")
            {
                this.BuyFromUser();
            }
            else
            {
                this.Main();
            }
        }

        public void ShowInventory()
        {

            Console.WriteLine("Please Select a kind of weapon you want to buy");
            Console.WriteLine("1. Weapons");
            Console.WriteLine("2. Armors");
            Console.WriteLine("3. Potions");
            var input = Console.ReadLine();
            if (input == "1")
            {

                foreach (var i in this.Weapons)
                {

                    Console.WriteLine(this.Weapons.IndexOf(i) + " : Name " + i.Name + " ,Original Price " + i.OriginalValue);
                }
                var itemNumber = Console.ReadLine();
                if (itemNumber == "0" || itemNumber == "1" || itemNumber == "2")
                {
                    this.Sell(Convert.ToInt32(itemNumber), "Weapon");
                    foreach (var i in this.Hero.WeaponsBag)
                    {
                        Console.WriteLine(i.Name);
                        Console.ReadLine();
                    }
                }
                else
                {
                    this.Menu();
                }
            }
            else if (input == "2")
            {
                foreach (var i in this.Armors)
                {
                    Console.WriteLine("item Number " + this.Armors.IndexOf(i) + " Name " + i.Name + ", Original Price " + i.OriginalValue);
                }
                var itemNumber = Console.ReadLine();
                if (itemNumber == "0" || itemNumber == "1" || itemNumber == "2")
                {
                    this.Sell(Convert.ToInt32(itemNumber), "Armor");
                }
                else
                {
                    this.Menu();
                }
            }
            else if (input == "3")
            {
                foreach (var i in this.Potions)
                {
                    Console.WriteLine("item Number " + this.Potions.IndexOf(i) + " Name " + i.Name + ", Original Price " + i.OriginalValue);
                }
                var itemNumber = Console.ReadLine();
                if (itemNumber == "0" || itemNumber == "1" || itemNumber == "2")
                {
                    this.Sell(Convert.ToInt32(itemNumber), "Potion");
                    Console.WriteLine(this.Hero.PotionBag);
                }
                else
                {
                    this.Menu();
                }
            }
            else if ((input == "r") || (input == "return"))
            {
                this.Menu();
            }
        }

        public void Sell(int itemNumber, string nameOfkind)
        {
            if (nameOfkind == "Weapon")
            {
                if (this.Hero.Gold != 0)
                {
                    this.Hero.WeaponsBag.Add(this.Weapons[itemNumber]);
                    this.Hero.Gold -= this.Weapons[itemNumber].OriginalValue;
                    this.Menu();
                }
                else
                {
                    Console.WriteLine("Oops You don't have enough gold to buy weapon ");
                    Console.ReadLine();
                    this.Menu();
                }
            }
            else if (nameOfkind == "Armor")
            {
                if (this.Hero.Gold != 0)
                {
                    this.Hero.ArmorsBag.Add(this.Armors[itemNumber]);
                    this.Hero.Gold -= this.Armors[itemNumber].OriginalValue;
                    this.Menu();
                }
                else
                {
                    Console.WriteLine("OOps! you don't have enough gold to buy armor");
                    Console.ReadLine();
                    this.Menu();
                }
            }
            else if (nameOfkind == "Potion")
            {
                if (this.Hero.Gold != 0)
                {
                    this.Hero.PotionBag.Add(this.Potions[itemNumber]);
                    this.Hero.Gold -= this.Potions[itemNumber].OriginalValue;
                    this.Menu();
                }
                else
                {
                    Console.WriteLine("OOps you don't have enough gold to buy potion");
                    Console.ReadLine();
                    this.Menu();
                }
            }
        }

        public void BuyFromUser()
        {
            Console.WriteLine("Please Select a kind of weapon you want to buy from user's list");
            Console.WriteLine("1. Weapons");
            Console.WriteLine("2. Armors");
            Console.WriteLine("3. Potions");
            var input = Console.ReadLine();
            if (input == "1")
            {
                if (this.Hero.WeaponsBag.Count != 0)
                {
                    foreach (var i in this.Hero.WeaponsBag)
                    {

                        Console.WriteLine(this.Hero.WeaponsBag.IndexOf(i) + " Name " + i.Name + " ,Resell Price " + i.ResellValue);
                    }
                    var itemNumber = Console.ReadLine();
                    if (itemNumber == "0" || itemNumber == "1" || itemNumber == "2")
                    {
                        this.SellFromUser(Convert.ToInt32(itemNumber), "Weapon");
                        Console.ReadLine();
                        this.Menu();

                    }
                    else
                    {
                        this.Menu();
                    }
                }
                else {
                    Console.WriteLine("OOps! the User has no weapons to sell!.Press r or return to return back to menu.");
                    Console.ReadLine();
                    this.Menu();
                }
            }
            else if (input == "2")
            {
                if (this.Hero.ArmorsBag.Count != 0)
                {
                    foreach (var i in this.Hero.ArmorsBag)
                    {

                        Console.WriteLine(this.Hero.ArmorsBag.IndexOf(i) + " Name " + i.Name + " ,Resell Price " + i.ResellValue);
                    }
                    var itemNumber = Console.ReadLine();
                    if (itemNumber == "0" || itemNumber == "1" || itemNumber == "2")
                    {
                        this.SellFromUser(Convert.ToInt32(itemNumber), "Armor");

                    }
                    else
                    {
                        this.Menu();
                    }
                }
                else {
                    Console.WriteLine("OOps! the User has no Armors to sell!.Press r or return to return back to menu.");
                    Console.ReadLine();
                    this.Menu();
                }
                
            }

            else if (input == "3")
            {
                if (this.Hero.PotionBag.Count != 0)
                {
                    foreach (var i in this.Hero.PotionBag)
                    {

                        Console.WriteLine(this.Hero.PotionBag.IndexOf(i) + " Name " + i.Name + " ,Resell Price " + i.ResellValue);
                    }
                    var itemNumber = Console.ReadLine();
                    if (itemNumber == "0" || itemNumber == "1" || itemNumber == "2")
                    {
                        this.SellFromUser(Convert.ToInt32(itemNumber), "Potion");

                    }
                    else
                    {
                        this.Menu();
                    }
                }
                else {
                    Console.WriteLine("OOps! the User has no Potions to sell!.Press r or return to return back to menu.");
                    Console.ReadLine();
                    this.Menu();
                }               
            }
            else if (input == "r" || input == "return")
            {
                this.Menu();
            }
        }

        public void SellFromUser(int itemNumber, string nameOfWeapon)
        {
            if (nameOfWeapon == "Weapon")
            {
                this.Hero.WeaponsBag.Remove(this.Weapons[itemNumber]);
                this.Hero.Gold += this.Weapons[itemNumber].ResellValue;
            }
            else if (nameOfWeapon == "Armor")
            {
                this.Hero.ArmorsBag.Remove(this.Armors[itemNumber]);
                this.Hero.Gold += this.Armors[itemNumber].ResellValue;
                this.Menu();
            }
            else if (nameOfWeapon == "Potion")
            {
                this.Hero.PotionBag.Remove(this.Potions[itemNumber]);
                this.Hero.Gold += this.Potions[itemNumber].ResellValue;
                this.Menu();
            }
        }
    }
}

