using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.Models;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.PresentationLayer
{
    public class GameSessionViewModel :ObservableObject
    {
        #region FIELDS

        private Player _player;
        private Map _gameMap; 
        private Location _currentlocation;
        private Location _northLocation, _eastLocation, _southLocation, _westLocation;
        private string _currentLocationInformation;
        private string _gameMessage;

        //  private List<string> AccessibleLocationsNames;
        private GameItem _currentGameItem;

        #endregion

        #region PROPERTIES

        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }

        public string GameMessage
        {
            get { return _gameMessage; }
            set { _gameMessage = value; }
        }
        public string MessageDisplay
        {
            get { return _currentlocation.Message; }
        }

        public Map GameMap { get { return _gameMap; } set { _gameMap = value; } }

        public Location CurretLocation
        {
            get { return _currentlocation; }
            set
            {
                _currentlocation = value;
                _currentLocationInformation = _currentlocation.description;
                OnPropertyChanged(nameof(CurretLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public Location NorthLocation
        {
            get { return _northLocation; }
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }

        public Location EastLocation
        {
            get { return _eastLocation; }
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }

        public Location SouthLocation
        {
            get { return _southLocation; }
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }

        public Location WestLocation
        {
            get { return _westLocation; }
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }

        public bool HasNorthLocation
        {
            get
            {
                if (NorthLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool HasEastLocation { get { return EastLocation != null; } }
        public bool HasSouthLocation { get { return SouthLocation != null; } }
        public bool HasWestLocation { get { return WestLocation != null; } }


        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public string CurrentLocationName
        {
            get { return _currentlocation.name; }
            set { _currentlocation.name = value; }
        }

        public ObservableCollection<Location> AccessibleLocations
        { get { return _gameMap.AccessibleLocations; } }

        public List<string> AccessibleLocationsnames
        { get { return _gameMap.AccessibleLocationsNames; } }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }
        

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {
            
        }

        public GameSessionViewModel(Player player,
                string initialMessages,
                Map gameMap,
                GameMapCoordinates currentLocationCoordinates
                )
        {
            _player = player;
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentlocation = _gameMap.CurrentLocation;
            GameMessage = initialMessages;

            _currentLocationInformation = CurretLocation.description;

            UpdateAvailableTravelPoints();


        }
        #endregion

        #region METHODS

       

        public void AddItemToInventory()
        {
            if(_currentGameItem!=null && _currentlocation.GameItems.Contains(_currentGameItem))
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentlocation.RemoveGameItemToLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);
            }
        }
        public void RemoveItemToInventory()
        {
            if (_currentGameItem != null )
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentlocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);
            }
        }

        private void OnPlayerPickUp(GameItem gameItem)
        {
            _player.ExperiencePoints += gameItem.ExperiencePoints;
            _player.Wealth += gameItem.Value;
        }

        private void OnPlayerPutDown(GameItem gameItem)
        {
            _player.Wealth -= gameItem.Value;
        }




        public void OnUseGameItem()
        {
           

            if(_currentGameItem is Potion )
            {
                //ProcessPotionUse(potion);
            }
            else if(_currentGameItem is Relic)
            {
               // ProcessRelicUse(relic);
            }           
        }

        private void ProcessRelicUse(Relic relic)
        {
            string message;
            switch (relic.UseAction)
            {
                case Relic.UseActionType.OPENLOCATION:
                    message = _gameMap.OpenLocationByRelic(relic.id);
                    CurrentLocationName = relic.UseMessage;
                    break;
                case Relic.UseActionType.KILLPLAYER:
                    PlayerDies(relic.UseMessage);
                    break;
                default:
                    break;
            }
        }

        private void PlayerDies(string message)
        {
            string messagetext = message + "\n\n Would you like to play again ";
            string titleText = "Death";

            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuiteApplication();
                    break;
            }
        }

        public void QuiteApplication()
        {
           Application.Current.Shutdown();
        }

        public void ResetPlayer()
        {
            Environment.Exit(0);

            //_player._id = 1;
            //_player.Name = "Bonzo";
            //_player.Army = Player.ArmyName.Lannister.ToString();
            //    _player.HouseType = Character.House.Targaryan.ToString();
            //    _player.Health = 60;
            //    _player.Lives = 3;
            //    _player.ExperiencePoints = 0;
            //    _player.Locationid = 0;
            //_player.Inventory = new ObservableCollection<GameItem>()
            //    {
            //        GameItemById(1002),
            //        GameItemById(2001)
            //    };
        }
        //public static GameItem GameItemById(int id)
        //{
        //    return StandardGameItems().FirstOrDefault(i => i.id == id);
        //}

        //public static List<GameItem> StandardGameItems()
        //{
        //    return new List<GameItem>()
        //    {
        //        new Weapon(1001,"Longsword",74,"Iron Weapon",1,"The long Sword is a sword",4),
        //        new Weapon(1002,"Phaser",250,"Iron Weapon",1,"Phaser are common",2),
        //        new Treasure(2020,"Small Diamond",250,Treasure.TreasureType.Diamond,1,"Diamonds are rare",4),
        //        new Treasure(1020,"Ring",34,Treasure.TreasureType.Gold,1,"Gold shines",5),
        //        new Potion(2020,"Distilled Lion Mocus",5,40,1,"Potion Description",4),
        //        new Relic(2020,"Crystal Key",5,"Conjured by the Forest Wizard",4,Relic.UseActionType.KILLPLAYER.ToString()),
        //        new Relic(2020,"Stick of Adol",5,"Long polished wooden rod",4,Relic.UseActionType.OPENLOCATION.ToString())
        //    };

        //}

        private void ProcessPotionUse(Potion potion)
        {
            _player.Health += potion.HealthChange;
            _player.Lives += potion.LivesChange;
            _player.RemoveGameItemToInventory(_currentGameItem);
        }


        private void UpdateAvailableTravelPoints()
        {
            //
            // reset travel location information
            //
            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            //
            // north location exists
            //
            if (_gameMap.NorthLocation() != null)
            {
                Location nextNorthLocation = _gameMap.NorthLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextNorthLocation.accessible == true || PlayerCanAccessLocation(nextNorthLocation))
                {
                    NorthLocation = nextNorthLocation;
                }
            }

            //
            // east location exists
            //
            if (_gameMap.EastLocation() != null)
            {
                Location nextEastLocation = _gameMap.EastLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextEastLocation.accessible == true || PlayerCanAccessLocation(nextEastLocation))
                {
                    EastLocation = nextEastLocation;
                }
            }

            //
            // south location exists
            //
            if (_gameMap.SouthLocation() != null)
            {
                Location nextSouthLocation = _gameMap.SouthLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextSouthLocation.accessible == true || PlayerCanAccessLocation(nextSouthLocation))
                {
                    SouthLocation = nextSouthLocation;
                }
            }

            //
            // west location exists
            //
            if (_gameMap.WestLocation() != null)
            {
                Location nextWestLocation = _gameMap.WestLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextWestLocation.accessible == true || PlayerCanAccessLocation(nextWestLocation))
                {
                    WestLocation = nextWestLocation;
                }
            }
        }

        private bool PlayerCanAccessLocation(Location nextLocation)
        {
            //
            // check access by experience points
            //
            if (nextLocation.IsAccessibleByExperiencePoints(_player.ExperiencePoints))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnPlayerMove()
        {
            //
            // update player stats when in new location
            //
            if (!_player.HasVisited(_currentlocation))
            {
                //
                // add location to list of visited locations
                //
                _player.LocationsVisited.Add(_currentlocation);

                // 
                // update experience points
                //
                _player.ExperiencePoints += _currentlocation.modifyExperientsPoints;

                //
                // update health
                //
                _player.Health += _currentlocation.ModifyHealth;

                //
                // update lives
                //
                _player.Lives += _currentlocation.modifyLives;

                //
                // display a new message if available
                //
                OnPropertyChanged(nameof(MessageDisplay));
            }
        }

        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.MoveNorth();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        /// <summary>
        /// travel east
        /// </summary>
        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.MoveEast();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        /// <summary>
        /// travel south
        /// </summary>
        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.MoveSouth();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        /// <summary>
        /// travel west
        /// </summary>
        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.MoveWest();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        #endregion
    }
}
