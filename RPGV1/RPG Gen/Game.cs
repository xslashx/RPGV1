using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    partial class Game
    {
        private static Personagem player;
        public static void newgame()
        {
            player = Setup.player;
            int ngame = 1;
            int menu = 0;
            while(ngame == 1)
            {
                Console.Clear();
                Setup.msg("-------------------------- MENU -------------------------- ", "\n", 200);
                Setup.msg("[1] - Arena                  [2] - Options", "\n", 200);
                Setup.msg("[3] - Shop                   [4] - Stats", "\n", 200);
                Setup.msg("[5] - Save", "\n", 200);
                Setup.breakline();
                Setup.msg("Digite sua opção: ", "", 200);
                try { menu = Convert.ToInt32(Console.ReadLine()); }
                catch { Setup.msg("Digite um número!", "\n", 200); }

                if (menu == 1)
                {
                    arena();
                }
                else if (menu == 2)
                {
                    Setup.msg("NOT YET! :D", "\n", 200);
                }
                else if (menu == 4)
                {
                    stats();
                }
                else if (menu == 5)
                {
                    Setup.Save(player);
                }
                else
                {
                    Setup.msg("Sua opção é invalida!", "\n", 200);
                }
                Console.ReadKey();

            }
            //foreach (Personagem arenanpc in Npcs.npcsarena)
            //{
            //    if (i == choice)
            //    {
            //        Setup.msg(arenanpc.Name + "WHAAT", "\n", 200);
            //    }
            //    i++;
            //}
            Console.ReadLine();
        }


        public static void arena()
        {
            Setup.sleep(600);
            Console.Clear();
            Setup.msg("Arena Master: Bem vindo a arena!", "\n", 600);
            Setup.msg("Arena Master: Aqui é um lugar onde você poderá encontrar diversos", "\n", 300);
            Setup.msg("adversários para treinar!", "\n", 600);
            Setup.breakline();
            Setup.breakline();
            Npcs.randonizenpcs(1);
            int i = 1;
            foreach (Personagem arenanpc in Npcs.npcsarena)
            {
                Setup.msg(i + " - " + arenanpc.Name + " LVL[" + arenanpc.Lvl + "]", "\n", 200);
                i++;
            }
            Setup.msg("0 - Voltar ao menu", "\n", 200);
            Setup.msg("Digite o numero do seu oponente!", "\n", 200);
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 0)
            {
                return;
            }
            Setup.msg("Você escolheu: " + choice, "\n", 200);
            Personagem pchoice = Npcs.npcsarena[choice - 1];
            Setup.msg(pchoice.Name, "\n", 200);
            Fight fight = new Fight();
            fight.o1 = player;
            fight.o2 = pchoice;
            fight.Init();
        }
        public static void stats()
        {
            Setup.sleep(600);
            Console.Clear();
            Setup.breakline();
            Setup.msg(player.Name + " Stats", "\n", 200);
            Setup.msg("Level: " + player.Lvl, "\n", 200);
            Setup.msg("Experiencia: " + player.Experiencia + " / " + player.Experienciar, "\n", 200);
            Setup.msg("-----------------------------------------------------", "\n", 200);
            Setup.msg("HP: " + player.Hp + " / " + player.Maxhp + "                            MP: " + player.Mp + " / " + player.Maxmana, "\n", 200);
            Setup.msg("Attack: " + player.Attack + "                              Armor: " + player.Armor, "\n", 200);
            Setup.msg("Speed: " + player.Speed, "\n", 200);
            Setup.msg("-----------------------------------------------------", "\n", 200);
            Setup.breakline();
            Setup.msg("Digite alguma tecla para voltar ao menu", "\n", 200);
    
        }
    }
}
