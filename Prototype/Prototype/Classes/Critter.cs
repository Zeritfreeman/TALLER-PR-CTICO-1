using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Classes
{
    class Critter
    {
        string name;
        float baseAttack;
        float baseDefense;
        float baseSpeed;
        string affinity;
        Skill[] skills = new Skill[3];
        int currentSkills = 0;
        float hp;
        float damageValue = 0;
        float affinityMultiplier = 1;

        public Critter(string name, float baseAttack, float baseDefense, float baseSpeed, string affinity, Skill[] skills, float hp)
        {
            this.name = name;
            if (baseAttack >= 10 && baseAttack <= 100) this.baseAttack = baseAttack;
            if (baseDefense >= 10 && baseDefense <= 100) this.baseDefense = baseDefense;
            if (baseSpeed >= 1 && baseSpeed <= 50) this.baseSpeed = baseSpeed;
            this.affinity = affinity;
            for (int i = 0; i < this.skills.Length; i++)
            {
                this.skills[i] = skills[i];
                if (skills[i] != null) currentSkills++;
            }
            this.hp = hp;

            damageValue = baseAttack;
        }

        public void CompareSkills(Critter opponentCritter)
        {
            if (affinity == opponentCritter.affinity) affinityMultiplier = .5f;
            else if (affinity == "Light" && opponentCritter.affinity == "Dark") affinityMultiplier = 2f;
            else if (affinity == "Dark" && opponentCritter.affinity == "Light") affinityMultiplier = 2f;
            else if (affinity == "Fire" && opponentCritter.affinity == "Water") affinityMultiplier = 2f;
            else if (affinity == "Light" && opponentCritter.affinity == "Dark") affinityMultiplier = 2f;
            else if (affinity == "Light" && opponentCritter.affinity == "Dark") affinityMultiplier = 2f;

            /*switch (affinity)
            {
                case "Light":
                
                    Console.WriteLine("Case 1");
                    break;
                case "Dark":
                    Console.WriteLine("Case 2");
                    break;
                case "Fire":
                    ;
                    break;
                case "Fire":
                    ;
                    break;
                case "Fire":
                    ;
                    break;

            }*/
        }

        public float Attack(Skill useSkill)
        {
            damageValue = (baseAttack + useSkill.Power) * 
            return damageValue;
        }

        public void TakeDamage(float damageTaken)
        {
            hp -= damageTaken;
        }

        public string Name { get => name; set => name = value; }
        public float BaseAttack { get => baseAttack; set => baseAttack = value; }
        public float BaseDefense { get => baseDefense; set => baseDefense = value; }
        public float BaseSpeed { get => baseSpeed; set => baseSpeed = value; }
        public string Affinity { get => affinity; set => affinity = value; }
        public float Hp { get => hp; set => hp = value; }
    }
}
