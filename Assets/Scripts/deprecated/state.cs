using System.Collections;
using System.Collections.Generic;
using UnityEngine;

        //current_state = 0
        //
        //
        //   --- 0 ---
        // the beginning
        //
        //  
        //

public class state : MonoBehaviour
{

    // creating static class for inventory
    //public class Inventory
    public class CurrentState
    {
        // Room 1
        //public static string room1_name = "room1";
        public static List<string> ItemsActive = new List<string>(); // list of active items
        //public static List<string> RoomsActive = new List<string>(); // list of active rooms
        //public static string CurrentlyIn; // which room are we in

        /* 
        public class Room
        {
            public static string last;
            public static string first;
        }


        public void AddRoom(string lastName, string firstName)
        {
            last = lastName;
            first = firstName;
            Room.Add(fist,last);
        }
        */

        //public static int myInt = 0;
        //public static List<string> inv = new List<string>(); // inventory


        /* no need to have this in the class
        public void add(string str)
        {
            inv.Add(str);
        }
        */
    }

    //CurrentState currState = new CurrentState(); // initiate inventory
    //currState.Room.last = "pipenguin";
   ////print(currState.Room);
    //print(inventory.inv.Count.ToString());

    //CurrentState.Room room1 = new CurrentState.Room("ahoj","world");


private void Start()
{
// initial state
CurrentState currentState = new CurrentState(); // initiate inventory
CurrentState.ItemsActive.Add("heja");
print(CurrentState.ItemsActive[0]);
}


}
