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
        float attackInc = 0, defenceInc = 0;
        public float speedDec = 0;
        int atkIncPPs = 0, defIncPPs = 0;
        public int spdDecPPs = 0;
        bool effective = false;
        bool ineffective = false;

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

            switch (affinity)
            {
                case "Light":
                    if (opponentCritter.affinity == "Dark") effective = true;
                    break;
                case "Dark":
                    if (opponentCritter.affinity == "Light") effective = true;
                    break;
                case "Fire":
                    if (opponentCritter.affinity == "Water") effective = true; 
                    break;
                case "Water":
                    if (opponentCritter.affinity == "Wind") effective = true;
                    else if (opponentCritter.affinity == "Fire") ineffective = true;
                    break;
                case "Earth":
                    if (opponentCritter.affinity == "Wind") effective = true;
                    break;
                case "Wind":
                    if (opponentCritter.affinity == "Water" || opponentCritter.affinity == "Earth") ineffective = true;
                    break;
                default:
                    break;
            }

            if (effective) affinityMultiplier = 2f;
            else if (ineffective) affinityMultiplier = .5f;
            else affinityMultiplier = 1f;
        }

        public float Attack(Skill useSkill)
        {
            if (useSkill.Type == "SupportSkill")
            {
                switch (useSkill.Name)
                {
                    case "AtkUp":
                        if (atkIncPPs <= 3) attackInc += baseAttack * .2f;
                        break;
                    case "DefUp":
                        if (defIncPPs <= 3) defenceInc += baseDefense * .2f;
                        break;
                    default:
                        break;
                }
                return 0;
            }
            else
            {
                damageValue = ((baseAttack + useSkill.Power) * affinityMultiplier) + attackInc;
                return damageValue;
            }
        }

        public float Attack(Skill useSkill, Critter enemyCritter)
        {
            if (useSkill.Type == "SupportSkill")
            {
                switch (useSkill.Name)
                {
                    case "AtkUp":
                        if (atkIncPPs <= 3) attackInc += baseAttack * .2f;
                        break;
                    case "DefUp":
                        if (defIncPPs <= 3) defenceInc += baseDefense * .2f;
                        break;
                    case "SpdDwn":
                        if (spdDecPPs <= 3) enemyCritter.speedDec += enemyCritter.BaseSpeed * .3f;
                        break;
                    default:
                        break;
                }
                return 0;
            }
            else
            {
                damageValue = ((baseAttack + useSkill.Power) * affinityMultiplier) + attackInc;
                return damageValue;
            }
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
