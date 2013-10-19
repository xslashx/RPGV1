using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Npcs
    {
        public static Personagem[] npcs;
        public static Personagem anciao;

        public static List<Personagem> npcsarena = new List<Personagem> { };
        public static Random r = new Random();
        public static void crianpcs()
        {
            anciao = new Personagem();
            anciao.Maxhp = 30;
            anciao.Hp = 30;
            anciao.Name = "Ancião";
            anciao.Mp = 0;
            anciao.Speed = 2;
            anciao.Armor = 0.5;
            anciao.Attack = 2;
            anciao.Lvl = 1;
            //randonizenpcs(1);
        }


        public static void randonizenpcs(int plvl)
        {
           List<string> npcname = new List<string> { "Demolidor", "Killer", "Badumtsi", "Pterodatilo", "Tigredentedesabre", 
                                                                "Tiranossaurorex", "SLX", "Hordor"                                                                                                                                                        
                                                               };
            npcsarena.Clear();
            npcs = new Personagem[4];
            int i = 0;

            foreach(Personagem persona in npcs)
            {
                //seta nome
                int rnd = r.Next(npcname.Count-1);
                npcs[i] = new Personagem();
                npcs[i].Name = npcname[rnd];
                npcname.RemoveAt(rnd);

                //seta lvl
                rnd = r.Next(plvl-2, plvl + 3);
                if (rnd < 1) { rnd = 1; } 
                npcs[i].Lvl = rnd;
                if (npcs[i].Name == "SLX")
                {
                    npcs[i].Lvl = 99;
                }
                //seta stats
                npcs[i].Attack = 5;
                npcs[i].Maxhp = 30;
                npcs[i].Armor = 0.5;
                npcs[i].Hp = npcs[i].Maxhp;
                npcs[i].Speed = 1;
                for (int z = 2; z <= npcs[i].Lvl; z++)
                {
                    npcs[i].Attack = npcs[i].Attack+1;
                    npcs[i].Maxhp = npcs[i].Maxhp+2;
                    npcs[i].Armor = npcs[i].Armor+0.2;
                    npcs[i].Speed = npcs[i].Speed + 1;
                }
                npcs[i].Hp = npcs[i].Maxhp;
                //adiciona o npc na lista
                npcsarena.Add(npcs[i]);
                i++;
            }

        }

    }
}
