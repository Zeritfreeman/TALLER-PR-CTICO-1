using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Classes
{
    class Player
    {
        string name;
        Critter[] critters = new Critter[3];
        int currentCritters = 0;
        List<string> collection;

        public Player(string name, Critter[] critters)
        {
            this.name = name;
            for (int i = 0; i < this.critters.Length; i++)
            {
                this.critters[i] = critters[i];
                if (critters[i] != null) currentCritters++;
            }
        }

        public void AddCritter(Critter critter)
        {
            if(currentCritters < 3)
            {
                critters[currentCritters - 1] = critter;
            }
        }

        public string Name { get => name; }
    }
}
