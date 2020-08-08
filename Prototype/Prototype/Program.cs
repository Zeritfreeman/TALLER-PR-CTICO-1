using Prototype.Classes;
using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Critter critter4 = new Critter("Birdo", 50f, 50f, 40f, affinities[1], skillsPack2, 100f);

            Critter[] crittersPack1 = { critter1, critter2, critter3 };
            Critter[] crittersPack2 = { critter3, critter2, critter1 };
            Critter[] crittersPack3 = { critter1, critter2, critter4 };

            Player player1 = new Player("Red", crittersPack1);
            Player player2 = new Player("Blue", crittersPack2);
            Player player3 = new Player("Yellow", crittersPack3);

            //Prueba de Inplementacion

            Skill skillWrong = new Skill("Prueba", affinities[0], "AttackSkill", 0f);

            Skill skillWrong2 = new Skill("Prueba2", affinities[1], "SupportSkill", 5f);

            Fight(player1, player2, 2, 0, 2);

            Fight(player1, player2, 2, 0, 1);
            Fight(player1, player2, 2, 0, 1);
            Fight(player1, player2, 2, 0, 1);
            Fight(player1, player2, 2, 0, 1);

            Fight(player2, player1, 2, 2, 0);

            Fight(player1, player3, 0, 2, 2);

            Description(player1);
            Description(player2);
            Description(player3);

            Description(critter1);
            Description(critter2);
            Description(critter3);
            Description(critter4);

            Description(skill1);
            Description(skill2);
            Description(skill3);
            Description(skill4);
            Description(skill5);
            Description(skill6);
            Description(skill7);
            Description(skill8);
            Description(skill9);
        }

        static void Fight(Player playerOne, Player playerTwo, int critterOneInx, int critterTwoInx, int skillUseInx)
        {
            playerOne.Critters[critterOneInx].CompareSkills(playerOne.Critters[critterOneInx].Skills[skillUseInx], playerTwo.Critters[critterTwoInx]);
            float damageValue = playerOne.Critters[critterOneInx].Attack(playerOne.Critters[critterOneInx].Skills[skillUseInx], playerTwo.Critters[critterTwoInx]);
            playerTwo.Critters[critterTwoInx].TakeDamage(damageValue, playerTwo);
        }

        static void Description(Skill skill)
        {
            Console.WriteLine(skill.Name);
            Console.WriteLine(skill.Affinity);
            Console.WriteLine(skill.Type);
            Console.WriteLine(skill.Power);
        }
        
        static void Description(Critter critter)
        {
            Console.WriteLine(critter.Name);
            Console.WriteLine(critter.BaseAttack);
            Console.WriteLine(critter.BaseDefense);
            Console.WriteLine(critter.BaseSpeed);
            Console.WriteLine(critter.Affinity);
            Console.WriteLine(critter.CurrentSkills);
            Console.WriteLine(critter.Hp);
            Console.WriteLine(critter.DamageValue);
            Console.WriteLine(critter.AffinityMultiplier);
            Console.WriteLine(critter.AttackInc);
            Console.WriteLine(critter.DefenceInc);
            Console.WriteLine(critter.speedDec);
            Console.WriteLine(critter.AtkIncPPs);
            Console.WriteLine(critter.DefIncPPs);
            Console.WriteLine(critter.spdDecPPs);

            foreach (Skill skill in critter.Skills)
            {
                Console.WriteLine(skill.Name);
            }
        }

        static void Description(Player player)
        {
            Console.WriteLine(player.collection);
            Console.WriteLine(player.Name);
            Console.WriteLine(player.CurrentCritters);

            foreach (Critter critter in player.Critters)
            {
                Console.WriteLine(critter.Name);
            }
        }
    }
}
