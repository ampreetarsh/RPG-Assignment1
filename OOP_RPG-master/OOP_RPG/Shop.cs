using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class Shop
    {
        List<Weapon> weapons { get; set; }
        List<Armor> armor { get; set; }
        List<Potion> potion { get; set; }

        public Shop()
        {
            this.weapons = new List<Weapon>();
            this.armor = new List<Armor>();
            this.potion = new List<Potion>();
        }
    }
}
