using FinalSpace.Game.Gameplay.GameplayBases;
using FinalSpace.Game.Gameplay.Stars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSpace.Game.Gameplay
{
    class Player
    {
        private Planet currentPlanet;
        private Planet homePlanet;

        public string name;
        public int money;

        private bool communicating = false;

        private List<Planet> discoveredPlanets;

        public Player(string name, Planet homePlanet)
        {
            this.homePlanet = homePlanet;
            this.currentPlanet = homePlanet;
            this.name = name;
            this.money = 20000;

        }

        public Planet GetCurrentPlanet()
        {
            return currentPlanet;

        }

        public void Trade(ItemBase item)
        {


        }

        public bool IsCommunicating()
        {
            return communicating;

        }
    }
}
