using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveSystem;

namespace ConsoleApplication1
{
    class Setup
    {
        static public Personagem player;
        static public string savelocal;
        public static void setup()
        {
            //CRIA NPCS    
            Npcs.crianpcs();
            savelocal = "C:\\Windows\\Temp\\RpgV1Save.txt";
            //Cria o Novo Jogador
            player = new Personagem();
            player.Hp = 30;
            player.Maxhp = 30;
            player.Armor = 0.5;
            player.Mp = 10;
            player.Maxmana = 10;
            player.Attack = 5;
            player.Lvl = 1;
            player.Experiencia = 0;
            player.Experienciar = 10;
            player.Speed = 100;
        }

        static Personagem Player { get { return player; } set { player = value; } }

         public static void Tutorial(int newgame)
        {
            if (newgame == 1)
            {
                setup();
                msg("Ancião: Bem vindo jovem guerreiro", "", 500); msg(".", "", 500); msg(".", "", 500); msg(".", "\n", 200);             
                msg("Ancião: Err, qual seria o seu nome mesmo?","\n", 100);
                player.Name = Console.ReadLine();
                msg("Ancião: Ahh como pude me esquecer, ", "", 300); msg(player.Name, "", 300); msg("!", "", 500); msg("!", "", 500); msg("!", "\n", 500); 
                msg("Ancião: Bem, esse é um mundo bastante perigoso!", "\n", 700); 
                msg("Ancião: Então vamos fazer uma pequena demonstração de batalha!", "\n", 1000);
                Fight fight = new Fight();
                fight.o1 = player;
                fight.o2 = Npcs.anciao;
                fight.Init();
                msg("Ancião: Ohhh, você me venceu!", "\n", 700);
                msg("Ancião: Talvez você tenha chances na arena...", "\n", 3000);
                msg("Digite alguma tecla para prosseguir", "\n", 200);
                Console.ReadLine();
                Console.Clear();
                Setup.sleep(500);
                Save(player);
                Game.newgame();
            }
            else if (newgame == 0)
            {
                setup();
                Load(player);
                Game.newgame();
            }
        }

        public static void msg(string msg, string type, int time)
        {
            if (type == "\n") Console.WriteLine(msg);
            else Console.Write(msg);
            //time = 0;

            sleep(time);
        }

        public static void breakline()
        {
            Console.WriteLine("");
        }

        public static int randomnumber(int a, int b)
        {
           // Random rand = new Random((int)DateTime.Now.Ticks);
            Random rand = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rnd = rand.Next(a, b);
            return rnd;
        }
        public static void sleep(int time)
        {
            //time = 0;
            System.Threading.Thread.Sleep(time);
        }

        public static void Save(Personagem pl)
        {
            SaveLoad save = new SaveLoad();
            save.OpenSave(savelocal);
            save.Save(pl.Lvl.ToString());
            save.Save(pl.Name.ToString());
            save.Save(pl.Maxhp.ToString());
            save.Save(pl.Attack.ToString());
            save.Save(pl.Armor.ToString());
            save.Save(pl.Experiencia.ToString());
            save.Save(pl.Experienciar.ToString());
            save.Save(pl.Speed.ToString());
            save.CloseSave();
        }

        public static void Load(Personagem pl)
        {
            SaveLoad save = new SaveLoad();
            msg("Carregando...", "\n", 400);
            try
            {
                save.OpenLoad(savelocal);
                pl.Lvl = Convert.ToInt32(save.Load());
                pl.Name = save.Load();
                pl.Maxhp = Convert.ToInt32(save.Load());
                pl.Attack = Convert.ToInt32(save.Load());
                pl.Armor = Convert.ToDouble(save.Load());
                pl.Experiencia = Convert.ToInt32(save.Load());
                pl.Experienciar = Convert.ToInt32(save.Load());
                pl.Speed = Convert.ToInt32(save.Load());
                save.CloseLoad();
            }
            catch
            {
                msg("Problema ao carregar personagem, tente criar um novo :D", "\n", 800);
            }
            msg("Carregado com sucesso!", "\n", 400);
            Console.ReadKey();
        }

    }

    public partial class Personagem
    {
        public void lvlup()
        {
            if (experiencia >= experienciar)
            {
                lvl++;
                attack++;
                armor = armor + 0.2;
                maxhp = maxhp + 2;
                maxmana = maxmana + 2;
                speed = speed ++;
                int restexp = experiencia - experienciar;
                if (restexp > 0)
                {
                    experiencia = restexp;
                    experienciar = lvl * 10;

                }
                else
                {
                    experienciar = lvl * 10;
                    experiencia = 0;
                }
                Setup.msg("Você passou de level!", "\n", 800);
                Setup.msg("Você está no level: " + lvl, "\n", 800);
                Setup.msg("Experiencia: " + experiencia + "/" + experienciar, "\n", 800);
                this.Heal();
                Setup.breakline();
                lvlup();
            }
        }

        public void Heal()
        {
            this.hp = this.maxhp;
        }
    }

}
