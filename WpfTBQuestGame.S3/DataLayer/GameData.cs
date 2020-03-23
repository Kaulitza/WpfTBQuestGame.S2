using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.Models;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.DataLayer
{
    public class GameData
    {
      
        public static Player PlayerData()
        {
            return new Player()
            {
                _id = 1,
                Name = "Dany",
                Army = Player.ArmyName.Targaryen.ToString(),
                HouseType = Character.House.Targaryan.ToString(),
                Health = 100,
                Lives = 3,
                ExperiencePoints = 0,
                Locationid = 0,
                //Inventory = new ObservableCollection<GameItemQuantity>()
                //{
                //    new GameItemQuantity(GameItemById(1002), 1),
                //    new GameItemQuantity(GameItemById(2001), 5),
                //}

            };
        }
        public static string InitialMessages()
        {
            return  "Winter is coming! The Night King is making his way to the wall!"+
                "Make your way through Westeros to gather supplies and allies!"+
                "And remember: Valar Morghulis!";
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Map GameMap()
        {

            int rows = 7;
            int columns = 3;

            Map gameMap = new Map(rows, columns);

            gameMap.MapLocation[0, 0] = new Location()
            {
                id = 1,
                name = "Not Accessible Location",
                accessible = false,
                modifyExperientsPoints = 10,
                Message = "This location is not accessible"
            };
            gameMap.MapLocation[0, 1] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            //
            // row 2
            //
            gameMap.MapLocation[0, 2] = new Location()
            {
                id = 3,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };
            gameMap.MapLocation[1, 0] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,

               
                modifyExperientsPoints = 50,
                modifyLives = -1,
                requiredExperientsPoints = 40
            };

            //
            // row 3
            //
            gameMap.MapLocation[1, 1] = new Location()
            {
                id = 5,
                name = "Dreadfort",
                description = "House Bolton, chance to gather supplies or allies",
                accessible = false,
                modifyExperientsPoints = 20,
                ModifyHealth = 50,
                Message = "Traveler, our telemetry places you at the Xantoria Market. We have reports of local health potions."
                // GameItems = new ObservableCollection<GameItemQuantity>
                //{
                //    new GameItemQuantity(GameItemById(3001), 1),
                //    new GameItemQuantity(GameItemById(1002), 1),
                //    new GameItemQuantity(GameItemById(4001), 1)
                //},
            };
            gameMap.MapLocation[1, 2] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[2, 0] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[2, 1] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[2, 2] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[3, 0] = new Location()
            {
                id = 2,
                name = "Winterfell",
                description = "This is House Stark",
                accessible = true,
                modifyExperientsPoints = 10,
                //GameItems = new ObservableCollection<GameItemQuantity>
                //{
                //    new GameItemQuantity(GameItemById(4002), 1)
                //},
            };

            gameMap.MapLocation[3, 1] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                
            };

            gameMap.MapLocation[3, 2] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                
            };

            gameMap.MapLocation[4, 0] = new Location()
            {
                id = 2,
                name = "Location Not Accessible",
                description = "This location is not accessible",
                accessible = false,
             
            };


            gameMap.MapLocation[4, 1] = new Location()
            {
                id = 2,
                name = "The Twins",
                description = "House Frey, you have to pay to pass",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[4, 2] = new Location()
            {
                id = 2,
                name = "Location Not Accessible",
                description = "This location is not accessible",
                accessible = false,

            };

            gameMap.MapLocation[5, 0] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[5, 1] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[5, 2] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                
            };

            gameMap.MapLocation[6, 0] = new Location()
            {
                id = 2,
                name = "Casterly Rock",
                description = "House Lannister, Gather supplies or allies",
                accessible = true,
                modifyExperientsPoints = 10,
               // GameItems = new ObservableCollection<GameItemQuantity>
                //{
                //    new GameItemQuantity(GameItemById(3001), 1),
                //    new GameItemQuantity(GameItemById(1002), 1),
                //    new GameItemQuantity(GameItemById(4001), 1)
                //},
            };

            gameMap.MapLocation[6, 1] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemById(3002),
                },
            };

            gameMap.MapLocation[6, 2] = new Location()
            {
                id = 2,
                name = "Storm's end",
                description = "House Barethon, gather supplies or allies",
                accessible = true,
                modifyExperientsPoints = 10,
                //GameItems = new ObservableCollection<GameItemQuantity>()
                //{
                //    new GameItemQuantity(GameItemById(2001), 10)
                //}
            };

            return gameMap;
        }
      
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, "Longsword", 75, 1, 4, "The longsword is a type of sword characterized as having a cruciform hilt with a grip for two-handed use and 85 to 110 cm in length.", 10),
                new Weapon(1002, "Phaser", 250, 1, 9, "Phasers are common and versatile phased array pulsed energy projectile weapons.", 10),
                new Treasure(2001, "Gold Coin", 10, Treasure.TreasureType.Gold, "24 karat gold coin", 1),
                new Treasure(2002, "Small Diamond", 50, Treasure.TreasureType.Diamond, "A small pea-sized diamond of various colors.", 1),
                new Treasure(2003, "Kalzonian Manuscript", 10, Treasure.TreasureType.Brinze, "Reportedly stolen during the Zantorian raids of of the 4th dynasty, it is said to contain information about early galactic technologies.", 5),
                new Potion(3001, "Distilled Baladorian Lion Mucus", 5, 40, 1, "Rare potion due to the dangers of procurement. Add 40 points of health.", 5),
                new Relic(4001, "Crystal Key", 5, "Conjured by the Forest Wizard, it opens many doors.", 5, "You have opened the Epitoria's Reading Room.", Relic.UseActionType.OPENLOCATION),
                new Relic(4002, "Stick of Adol", 5, "Long polished wooden rod with sliding silver ribbons..", 5, "Sliding the silver ribbons, you feel a sharp pain in your left temple and quickly die.", Relic.UseActionType.KILLPLAYER)
            };

        }
        public static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.id == id);
        }

    }
}
