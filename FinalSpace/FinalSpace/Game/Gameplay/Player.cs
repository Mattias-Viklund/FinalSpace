using FinalSpace.Game.Gameplay.Items;
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

        private string name;
        private int money;

        private bool communicating = false;

        private List<Planet> discoveredPlanets = new List<Planet>();

        public Player(string name, Planet homePlanet)
        {
            this.homePlanet = homePlanet;
            this.currentPlanet = homePlanet;
            this.name = name;
            this.money = 20000;

        }

        public bool DiscoveredPlanet(Planet planet)
        {
            foreach (Planet p in discoveredPlanets)
            {
                if (p.GetName() == planet.GetName())
                    return true;

            }

            discoveredPlanets.Add(planet);
            return false;

        }

        public Planet GetCurrentPlanet()
        {
            return currentPlanet;

        }

        public void Trade(ItemBase item)
        {


        }

        public string GetName()
        {
            return name;

        }

        public int GetMoney()
        {
            return money;

        }

        public void SetMoney(int money)
        {
            this.money = money;

        }

        public bool IsCommunicating()
        {
            return communicating;

        }

        public void SetCommunicating(bool b)
        {
            communicating = b;

        }
    }
}
