using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_NET
{
    public class Boss
    {
        public readonly string BossType;
        public int Lvl { get; set; } = 0;

        public Boss(int Lvl, string BossType)
        {
            this.BossType = BossType;
            this.Lvl = Lvl;
        }
        public Boss(string BossType) => this.BossType = BossType;   

        public delegate void Upgrade(string mes);
        public event Upgrade? upgradeMes;

        public void LevelUp(int lvl)
        {
            Lvl += lvl;
            upgradeMes?.Invoke($"Уровень {this.BossType} увеличен на: {lvl}. Текущий уровень: {this.Lvl}");
        }
        public void LevelDown(int lvl)
        {
            if (Lvl >= lvl)
            {
                Lvl -= lvl;
                upgradeMes?.Invoke($"Уровень {this.BossType} уменьшен на: {lvl}. Текущий уровень: {this.Lvl}");
            }
            else
            {
                Lvl = 0;
                upgradeMes($"Слишком большое понижение уровня для {this.BossType}. Текущий уровень: {this.Lvl}"); ;
            }
        }
        public void ElectricShock(int voltage)
        {
            if (voltage > Lvl)
            {
                Console.Write(this.BossType);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Убит.");
                Console.ResetColor();
            }
            else
            {
                Console.Write(this.BossType);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Выжил.");
                Console.ResetColor();
            }
        }
    }
}
