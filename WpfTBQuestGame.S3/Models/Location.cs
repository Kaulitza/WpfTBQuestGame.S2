using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.Models
{
    public class Location:ObservableObject
    {


        int _id; public int id { get { return _id; } set { _id = value; } }
        string _name; public string name { get { return _name; } set { _name = value; } }
        string _description; public string description { get { return _description; } set { _description = value; } }
        Boolean _accessible; public Boolean accessible { get { return _accessible; } set { _accessible = value; } }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        int _modifyExperientsPoints;public int modifyExperientsPoints { get { return _modifyExperientsPoints; }set { _modifyExperientsPoints=value;} }
        int _modifyLives; public int modifyLives{ get { return _modifyLives; } set { _modifyLives = value; } }
        private int _modifyHealth;public int ModifyHealth { get { return _modifyHealth; } set { _modifyHealth = value; } }
        int _requiredExperientsPoints; public int requiredExperientsPoints { get { return _requiredExperientsPoints; } set { _requiredExperientsPoints = value; } }
        private ObservableCollection<GameItem> _gameItems; public ObservableCollection<GameItem> GameItems { get { return _gameItems; }set { _gameItems = value; } }
        private int _requiredRelicid;public int RequiredRelicid { get { return _requiredRelicid; } set { _requiredRelicid = value; } }
        //public Location(int _id, string _name, string _description, Boolean _accessible)
        //{
        //    this._id = _id; this._name = _name;this._description = _description;this._accessible = _accessible;
        //}


        public Location()
        {
            _gameItems = new ObservableCollection<GameItem>();
        }

        public void ModifyExperiencePoints()
        {

        }

        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItem> updateLocationGameItems = new ObservableCollection<GameItem>();

            foreach(GameItem GameItem in _gameItems)
            {
                updateLocationGameItems.Add(GameItem);
            }

            GameItems.Clear();

            foreach (GameItem GameItem in updateLocationGameItems)
            {
                GameItems.Add(GameItem);
            }
        }
        public void AddGameItemToLocation(GameItem selectedGameItem)
        {
            if(selectedGameItem==null)
            {
                _gameItems.Add(selectedGameItem);
            }
            UpdateLocationGameItems();
        }

        public void RemoveGameItemToLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem == null)
            {
                _gameItems.Remove(selectedGameItem);
            }
            UpdateLocationGameItems();
        }
        public bool IsAccessibleByExperiencePoints(int playerExperiencePoints)
        {
            return playerExperiencePoints >= _requiredExperientsPoints ? true : false;
        }
    }
}
