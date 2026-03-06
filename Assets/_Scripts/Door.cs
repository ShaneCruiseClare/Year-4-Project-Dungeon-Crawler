using UnityEngine;

namespace Project1
{
    public class Door
    {
        public Location location;
        public bool locked = true;

        // needs COLOUR key .....
        public bool blueKey = false;
        public bool redKey = false;
        
        public bool IsDoorLocked(bool exit, bool blueKey, bool redKey)
        {
            if (locked == true & blueKey == false & redKey == false)
            {
                Debug.Log("Door is locked! find a key");
            }
            else if (locked == true & blueKey == true)
            {
                Debug.Log("Door is locked! but you have the blue key, try using it");
            }
            else if (locked == true & redKey == true)
            {
                Debug.Log("Door is locked! but you have the red key, try using it");
            }
            else if (locked == false)
            {
                Debug.Log("Door is open!!");
            }
            return locked = true;
        }
        

    }
}
