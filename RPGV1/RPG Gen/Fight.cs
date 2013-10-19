using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    public class Fight
    {
        public double armorratio;
        public int attackratio;
        public Personagem o1;
        public Personagem o2;
        public Personagem winner;
        private int fighting;
        private int dano;

        public void Init()
        {
            armorratio = 0.3;
            attackratio = 2;
            Setup.breakline();
            Setup.msg(o1.Name + " vs " + o2.Name,"\n",0);
            Setup.breakline();
            this.fighting = 1;
            this.Menu();
        }
        public void Menu()
        {
            while (fighting == 1)
            {
                Setup.msg(o1.Name + " HP:" + o1.Hp + "/" + o1.Maxhp, "\n", 200);
                Setup.msg("Vs.", "\n", 200);
                Setup.msg(o2.Name + " HP:" + o2.Hp + "/" + o2.Maxhp, "\n", 200);
                Setup.breakline();
                Setup.msg("Qual será sua ação?!", "\n", 200);
                Setup.msg("A - ATACAR", "\n", 200);
                string action = Console.ReadLine();
                if (action == "A" || action == "a")
                {
                    Setup.breakline();
                    Attack();

                }

                Setup.breakline();
            }
            endfight();
                
        }
        public void Attack()
        {
            if (o1.Speed >= o2.Speed)
            {
                int rnd = Setup.randomnumber(o1.Attack, o1.Attack + attackratio);
                dano = rnd;
                dano = dano - (Convert.ToInt32(o2.Armor * armorratio));
                if (dano < 0) dano = 0;
                Setup.msg("Você deu o dano de: " + dano, "\n", 1000);
                o2.Hp -= dano;
                if (o2.Hp <= 0)
                {
                    o2.Hp = 0;
                    fighting = 0;
                    winner = o1;
                    o1.Heal();
                }
                else
                {
                    rnd = Setup.randomnumber(o2.Attack, o2.Attack + attackratio);
                    dano = rnd;
                    dano = dano - (Convert.ToInt32(o1.Armor * armorratio));
                    if (dano < 0) dano = 0;
                    Setup.msg("Você recebeu dano de: " + dano, "\n", 1000);
                    o1.Hp -= dano;
                    if (o1.Hp <= 0)
                    {
                        o1.Hp = 0;
                        fighting = 0;
                        winner = o2;
                    }
                }
            }
            else
            {
                int rnd = Setup.randomnumber(o2.Attack, o2.Attack + attackratio);
                dano = rnd;
                dano = dano - (Convert.ToInt32(o1.Armor * armorratio));
                if (dano < 0) dano = 0;
                Setup.msg("Você recebeu o dano de: " + dano, "\n", 1000);
                o1.Hp -= dano;
                if (o1.Hp <= 0)
                {
                    o1.Hp = 0;
                    fighting = 0;
                    winner = o2;
                }
                else
                {
                    rnd = Setup.randomnumber(o1.Attack, o1.Attack + attackratio);
                    dano = rnd;
                    dano = dano - (Convert.ToInt32(o2.Armor * armorratio));
                    if (dano < 0) dano = 0;
                    Setup.msg("Você deu dano de: " + dano, "\n", 1000);
                    o2.Hp -= dano;
                    if (o2.Hp <= 0)
                    {
                        o2.Hp = 0;
                        fighting = 0;
                        winner = o1;
                    }
                }
            }
        }

        public void endfight()
        {
            if (winner == o2)
            {
                Setup.msg("Você perdeu", "", 200); Setup.msg(" .", "", 200); Setup.msg(" .", "", 1200); Setup.msg(" .", "\n", 200);
                Setup.msg(":(", "", 1500);               
            }
            else if (winner == o1)
            {
                int exp = o2.Lvl * 5;
                o1.Experiencia = o1.Experiencia + exp;
                Setup.msg("Você ganhou", "", 200); Setup.msg(" !", "", 200); Setup.msg(" !", "", 1200); Setup.msg(" !", "\n", 200);
                Setup.msg("Experiencia: " + o1.Experiencia + "/" + o1.Experienciar, "\n", 200);
                o1.lvlup();
  
            }
        }
    }
}
