using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        public int Gold { get; set; }
        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero() {
            this.ArmorsBag = new List<Armor>();
            this.WeaponsBag = new List<Weapon>();
            this.PotionBag = new List<Potion>();
            this.Strength = 10;
            this.Defense = 10;
            this.OriginalHP = 30;
            this.CurrentHP = 30;
            this.Gold = 0;
            this.Speed = 20;
        }
        
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public int Speed { get; set; } 
      
        public List<Armor> ArmorsBag { get; set;}
        public List <Weapon> WeaponsBag { get; set; }
        public List <Potion> PotionBag { get; set; }

        //These are the Methods of our Class.
        public void ShowStats() {
            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
            Console.WriteLine("Gold: " + this.Gold);
        }

        public void ShowInventory()
        {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");
            foreach (var w in this.WeaponsBag)
            {
                Console.WriteLine(w.Name + " of " + w.Strength + " Strength");
            }
            Console.WriteLine("Armor: ");
            foreach (var a in this.ArmorsBag)
            {
                Console.WriteLine(a.Name + " of " + a.Defense + " Defense");
            }
        }
        public void Equip() {
            Console.WriteLine("Please select an item which you want to equip");
            Console.WriteLine("1.Weapons");
            Console.WriteLine("2.Armor");
            Console.WriteLine("3. Regain Hp");
            var input = Console.ReadLine();
            if (input == "1")
            {
                if (this.WeaponsBag.Count != 0)
                {
                    foreach (var i in this.WeaponsBag)
                    {
                        Console.WriteLine(this.WeaponsBag.IndexOf(i) + " : " + i.Name + " ," + " Strength " + i.Strength);
                    }
                    var option = Console.ReadLine();
                    if (option == "0" || option == "1" || option == "2")
                    {
                        this.EquipWeapon(Convert.ToInt32(option));
                    }
                }
                else
                {
                    Console.WriteLine("Sorry! There are no weapons to equip!!");
                }
            }

            else if (input == "2")
            {
                if (this.ArmorsBag.Count != 0)
                {
                    foreach (var i in this.ArmorsBag)
                    {
                        Console.WriteLine(this.ArmorsBag.IndexOf(i) + " : " + i.Name + " ," + " Strength " + i.Defense);
                    }
                    var option = Console.ReadLine();
                    if (option == "0" || option == "1" || option == "2")
                    {
                        this.EquipArmor(Convert.ToInt32(option));
                    }
                }
                else
                {
                    Console.WriteLine("Sorry! There are no Armors to equip!!");
                }
            }

            else if (input == "3") {
                if (this.PotionBag.Count != 0)
                {
                    foreach (var i in this.PotionBag)
                    {
                        this.CurrentHP += i.HP;
                        Console.WriteLine(i.HP);
                        this.PotionBag.RemoveAt(0);
                    }
                }
                else {
                    Console.WriteLine("OOps You don't have any Hp!!");
                }
            }
        }
        
        
        public void EquipWeapon(int itemIndex) {
            if(WeaponsBag.Any()) {
                if (this.EquippedWeapon == null)
                {
                    this.EquippedWeapon = this.WeaponsBag[itemIndex];
                    this.Strength += this.EquippedWeapon.Strength;
                    this.WeaponsBag.RemoveAt(itemIndex);
                }
                else {
                    this.Strength -= this.EquippedWeapon.Strength;
                    this.WeaponsBag.Add(this.EquippedWeapon);
                    this.EquippedWeapon = this.WeaponsBag[itemIndex];
                    this.Strength += this.EquippedWeapon.Strength;
                    this.WeaponsBag.RemoveAt(itemIndex);
                }       
            }
        }
        
        public void EquipArmor(int itemIndex) {
            if(ArmorsBag.Any()) {
                if (this.EquippedArmor == null)
                {
                    this.EquippedArmor = this.ArmorsBag[itemIndex];
                    this.Defense += this.EquippedArmor.Defense;
                    this.ArmorsBag.RemoveAt(itemIndex);
                }
                else {
                    this.Defense -= this.EquippedArmor.Defense;
                    this.ArmorsBag.Add(this.EquippedArmor);
                    this.EquippedArmor = this.ArmorsBag[itemIndex];
                    this.Defense += this.EquippedArmor.Defense;
                    this.ArmorsBag.RemoveAt(itemIndex);
                }
                
            }
        }
        

    }
}