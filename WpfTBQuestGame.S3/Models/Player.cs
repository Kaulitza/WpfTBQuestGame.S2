using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.Models
{
    public class Player : Character
    {

        private int _lives, _health, _experiencePoints, _wealth;
        private string _house;
        private string _armyname;

        private List<Location> _locationVisited;

        //private ObservableCollection<GameItem> _inventory;
        //private ObservableCollection<GameItem> _potions;
        //private ObservableCollection<GameItem> _Treasures;
        //private ObservableCollection<GameItem> _weapons;

        private ObservableCollection<GameItem> _inventory; public ObservableCollection<GameItem> Inventory { get { return _inventory; } set { _inventory = value; } }
        private ObservableCollection<GameItem> _potions; public ObservableCollection<GameItem> Potions { get { return _potions; } set { _potions = value; } }
        private ObservableCollection<GameItem> _treasures; public ObservableCollection<GameItem> Treasures { get { return _treasures; } set { _treasures = value; } }
        private ObservableCollection<GameItem> _weapons; public ObservableCollection<GameItem> Weapons { get { return _weapons; } set { _weapons = value; } }

        public enum ArmyName
        {
            Dothraki,
            Unsullied,
            Stark,
            Lannister,
            Targaryen
        }

        public Player() :base()
        {

            _locationVisited = new List<Location>();
            _weapons = new ObservableCollection<GameItem>();
            _treasures = new ObservableCollection<GameItem>();
            _potions = new ObservableCollection<GameItem>();
            _inventory = new ObservableCollection<GameItem>();
        }
        public Player(int id, string name, int locationid) : base(id, name, locationid)
        {
            _id = id;
            _name = name;
            _locationid = locationid;
        }
        public override void functionAbstract()
        {

        }
        public override void functionVirtual()
        {

        }
        public List<Location> LocationsVisited
        {
            get { return _locationVisited; }
            set { _locationVisited = value; }
        }
        public int Lives
        {
            get { return _lives; }
            set { _lives = value;OnPropertyChanged(nameof(_lives)); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(_name)); }
        }

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;

                if (_health > 100)
                {
                    _health = 100;
                }
                else if (_health <= 0)
                {
                    _health = 100;
                    _lives--;
                }
                OnPropertyChanged(nameof(_health)); }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; OnPropertyChanged(nameof(_experiencePoints)); }
        }
        public int Locationid
        {
            get { return _locationid; }
            set { _locationid = value; OnPropertyChanged(nameof(_locationid)); }
        }

        public string Army
        {
            get { return _armyname; }
            set { _armyname = value; OnPropertyChanged(nameof(_armyname)); }
        }
        public string HouseType
        {
            get { return _house; }
            set { _house = value; OnPropertyChanged(nameof(_house)); }
        }
        public int Wealth
        {
            get { return _wealth; }
            set { _wealth = value; OnPropertyChanged(nameof(_wealth)); }
        }

        public void UpdateInventoyCategories()
        {
            Potions.Clear();
            Treasures.Clear();
            Weapons.Clear();
            foreach(var GameItem in _inventory)
            {
                if (GameItem is Potion) Potions.Add(GameItem);
                if (GameItem is Treasure) Treasures.Add(GameItem);
                if (GameItem is Weapon) Weapons.Add(GameItem);
            }
        }

        public void calculatewealth()
        {
            Wealth = _inventory.Sum(i => i.Value);
        }

        public void AddGameItemToInventory(GameItem selectedGameItem)
        {

            if(selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }
           
        }

        public void RemoveGameItemToInventory(GameItem selectedGameItem)
        {
            //      GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.id == selectedGameItemQuantity.GameItem.id);

            if (selectedGameItem != null)
            {
                
                    _inventory.Remove(selectedGameItem);
                
            }
        }
        public bool HasVisited(Location location)
        {
            return _locationVisited.Contains(location);
        }

    }
}
