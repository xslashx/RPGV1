using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveSystem;
// TO DO LIST!
// MSG SYSTEM - 50%
// FIGHT SYSTEM - 50%
// EQUIP SYSTEM 0%
// ARENA SYSTEM - 60%
// LVL SYSTEM 60% - MELHORAR PONTOS POR LVL, E AJUSTAR FORÇA DOS NPCS
// SISTEMA DE CRITICO DERIVADO DE AGILIDADE, SPEED TB SERÁ DERIVADO DE AGILIDADE, 10% da agilidade = speed
namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int choice = 1; ;
            Setup.msg("RPG v1 Versão ALPHA 0.02!", "\n", 1000);
            Setup.breakline();
            Setup.msg("Desenvolvido por SLX!", "\n", 1000);
            Console.Clear();
            Setup.sleep(1000);
            Setup.msg("[1] - Novo Jogo", "\n", 200);
            Setup.msg("[2] - Continuar", "\n", 200);
            Setup.msg("Digite sua opção:", "\n", 200);
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                choice = 0;
            }
            if (choice == 2)
            {
                Setup.Tutorial(0);
            }
            else if (choice == 1)
            {
                Console.Clear();
                Setup.Tutorial(1);
                Console.ReadKey();
            }
            Setup.msg("Algo deu errado!! O jogo será fechado", "\n", 200);
           }
    }
}
