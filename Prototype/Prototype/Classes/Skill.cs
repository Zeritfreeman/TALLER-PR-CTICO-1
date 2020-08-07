using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Classes
{
    class Skill
    {
        string name;
        string affinity;
        string type;
        float power;

        public Skill(string name, string affinity, string type, float power)
        {
            this.name = name;
            this.affinity = affinity;
            if (type == "SupportSkill")
            {
                this.type = type;
                this.power = 0;
            }
            else if (type == "AttackSkill" && power > 0 && power <= 10)
            {
                this.type = type;
                this.power = power;
            }

        }


        public string Name { get => name; set => name = value; }
        public string Affinity { get => affinity; set => affinity = value; }
        public string Type { get => type; set => type = value; }
        public float Power { get => power; set => power = value; }
    }
}
