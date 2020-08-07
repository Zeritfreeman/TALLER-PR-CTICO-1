using Prototype.Classes;
using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string[] affinities = { "Fire", "Wind", "Water", "Earth", "Dark", "Light" };

            Skill skill1 = new Skill("Flame", affinities[0], "AttackSkill", 7.5f);
            Skill skill2 = new Skill("GasExplotion", affinities[1], "AttackSkill", 5f);
            Skill skill3 = new Skill("WaterGun", affinities[2], "AttackSkill", 7.5f);
            Skill skill4 = new Skill("Earthquake", affinities[3], "AttackSkill", 10f);
            Skill skill5 = new Skill("ShadowRealm", affinities[4], "AttackSkill", 8.5f);
            Skill skill6 = new Skill("SunSalutation", affinities[5], "AttackSkill", 5f);
            Skill skill7 = new Skill("AtkUp", affinities[0], "SupportSkill", 0f);
            Skill skill8 = new Skill("DefUp", affinities[2], "SupportSkill", 0f);
            Skill skill9 = new Skill("SpdDwn", affinities[3], "SupportSkill", 0f);

            Skill[] skillsPack1 = { skill1, skill2, skill3 };
            Skill[] skillsPack2 = { skill4, skill5, skill6 };
            Skill[] skillsPack3 = { skill7, skill8, skill9 };

            Critter critter1 = new Critter("Char", 75f, 25f, 50f, affinities[0], skillsPack1, 60f);
            Critter critter2 = new Critter("Squr", 50f, 75f, 35f, affinities[2], skillsPack2, 75f);
            Critter critter3 = new Critter("Ivie", 100f, 50f, 25f, affinities[3], skillsPack3, 100f);

            Critter[] crittersPack1 = { critter1, critter2 };
            Critter[] crittersPack2 = { critter3 };

            Player player1 = new Player("Red", crittersPack1);
            Player player2 = new Player("Blue", crittersPack2);
        }

        void Fight(Player playerOne, Player playerTwo)
        {

        }
    }
}
