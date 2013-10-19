using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public partial class Personagem
    {
        private string name;
        private int hp;
        private int maxhp;
        private int mp;
        private int maxmana;
        private int attack;
        private int lvl;
        private int experiencia;
        private int experienciar;
        private int speed;
        private double armor;

        public double Armor { get { return armor; } set { armor = value; } }
        public int Experienciar { get { return experienciar; } set { experienciar = value; } }
        public int Experiencia { get { return experiencia; } set { experiencia = value; } }
        public string Name { get { return name; } set { name = value; }}
        public int Maxhp { get { return maxhp; } set { maxhp = value; }}
        public int Maxmana { get { return maxmana; } set { maxmana = value; } }
        public int Hp { get { return hp; } set { hp = value; } }
        public int Mp { get { return mp; } set { mp = value; }}
        public int Attack { get { return attack; } set { attack = value; }}
        public int Lvl { get { return lvl; } set { lvl = value; }}
        public int Speed { get { return speed; } set { speed = value; } }


    }
}