using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text

public class IntroScene : MonoBehaviour
{
    // creating static class for inventory
    public class Inventory
    {
        //public static int myInt = 0;
        public static List<string> inv = new List<string>(); // inventory

        /* no need to have this in the class
        public void add(string str)
        {
            inv.Add(str);
        }
        */
    }
    //static List<string> inv = new List<string>(); // inventory
    
    Inventory inventory = new Inventory(); // initiate inventory
    private Text introText;
    private GameObject Figs; 
    
    // current state is a static class that remembers what state is the player in
    // has list of active items, rooms
    public class CurrentState
    {
        public static List<string> ItemsActive = new List<string>(); // list of active items
        public static List<string> RoomsActive = new List<string>(); // list of active rooms
        public static Vector3 NinejPos = new Vector3(0f,0f,0f);  // Ninej position in the room
    } 

    CurrentState currentState = new CurrentState(); // initiate current state

    // Start is called before the first frame update
    public void Start()
    {
        //Text introText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>();
        //introText.text = "Matěj wakes up feeling cold. The window is open and Nina is gone. There are some paper origami birds on the window sill.\n\n\n\n[press SPACE to continue]";
        
        // initiate state
        initiateCurrentState();

        // walk through the tutorial
        StartCoroutine(Tutorial());  // start tutorial coroutine
    }

    // initiate the current state- i.e. which objects and rooms are active/available
    // used to be (but we awnted to call it from debugs)
    // private void initiateCurrentState()
    public static void initiateCurrentState()
    {
        // initiate state of the game, i.e., which rooms/items are active
        CurrentState.ItemsActive.Add("heart");    // Room nr 1 = bedroom
        CurrentState.ItemsActive.Add("RIP");       // 1
        CurrentState.ItemsActive.Add("paperclip"); // 1
        //CurrentState.ItemsActive.Add("origami");   // 0 = intro
        //CurrentState.ItemsActive.Add("cat");       // 0
        CurrentState.ItemsActive.Add("breakfast"); // 2 = kitchen
        CurrentState.ItemsActive.Add("knife");     // 2
        //CurrentState.ItemsActive.Add("snack");     // 3 = tangram minigame, through PuzzleDrag/WinScript
        CurrentState.ItemsActive.Add("mailbox");    // 4 = porch
        //CurrentState.ItemsActive.Add("mailboxKey");  // ?
        CurrentState.ItemsActive.Add("barista");    // 5 cafe
        

        ////////////////////////////
        // Active rooms
        CurrentState.RoomsActive.Add("Bedroom");     // 1
        CurrentState.RoomsActive.Add("Kitchen");     // 2
        //CurrentState.RoomsActive.Add("Porch");     // 4
        CurrentState.RoomsActive.Add("Cafe");        // 5

    }

    private void Update()
    {    
        //Text introText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>();
        // StartCoroutine(Tutorial(introText));  // start tutorial coroutine
        

    }

    //IEnumerator Tutorial(Text introText)
    IEnumerator Tutorial()
    {
        Text introText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>();
        Figs = GameObject.Find( "Figs" );  // find figs folder

        GameObject Matej = Figs.transform.Find( "Ninej" ).gameObject; // find matej
        GameObject origami = Figs.transform.Find( "origami" ).gameObject; // find origami
        GameObject cat = Figs.transform.Find( "cat" ).gameObject; // find origami

        while((!Input.GetKeyDown(KeyCode.Space))) // wait for spacebar key
        yield return null; // to finish the while loop

        introText.text = "He gets up and walks around the room.";

        // wait for 0.5s (just in case space has been pressed before)
        yield return new WaitForSeconds(0.5f);

        ///////////////////////////////////////////////////////////////////////////////////////
        
        while((!Input.GetKeyDown(KeyCode.Space))) // wait for spacebar key
        yield return null; // to finish the while loop

        Matej.SetActive(true); //show matej
        introText.text = "He gets up and walks around the room.\n\n\n\n\n\n[You can move around using arrows]";

        // wait for 0.5s (just in case space has been pressed before)
        yield return new WaitForSeconds(0.5f);
        
        ////////////////////////////////////////////////////////////////////////////////////////

        while((!Input.GetKeyDown(KeyCode.Space))) // wait for spacebar key
        yield return null; // to finish the while loop

        introText.text = "[Get closer to objects to interact with them.]\n\n\n\n\n\n[To take an object press T.]";
        origami.SetActive(true); //show origami

   
        //inventory.add("blew"); // removed add function from class

        //print(inventory.inv.Count.ToString());  //produces error bc you can't access static members with instance syntax
        // print(Inventory.inv[0]); // capitalized bc static variable value is shared among all instances

        // wait for 0.5s (just in case space has been pressed before)
        //yield return new WaitForSeconds(0.5f);
        
        /////////////////////////////////////////////////////////////////////////////////////

        while(!(Inventory.inv.Count>0)) // wait for Matej to pick up the item
        yield return null; // to finish the while loop
        cat.SetActive(true); //show cat
        introText.text = "[Items can be used in a proximity of another object by pressing G.]";

        while(!(Inventory.inv.Count==0)) // wait for Matej to give up the item
        yield return null; // to finish the while loop        
        introText.text = "The cat snatches the origami bird and runs away.";
        cat.SetActive(false);
        Figs.transform.Find( "catClick" ).gameObject.SetActive(false);

        // find the button to continu
        //Button contButton = GameObject.Find("continueButton").GetComponent<Button>();
        //contButton.gameObject.SetActive(false);
        //transform.gameObject.SetActive(true);
        //GameObject.Find("continueButton").GetComponentInChildren<Text>().text = "la di da";
        //GameObject.Find("continueButton").GetComponent<Button>().gameObject.SetActive(true);


        // wait for 0.5s (just in case space has been pressed before)
        yield return new WaitForSeconds(0.5f);
        
        ////////////////////////////////////////////////////////////////////////////////////////

        while((!Input.GetKeyDown(KeyCode.Space))) // wait for spacebar key
        yield return null; // to finish the while loop

        introText.text = "You are done with the tutorial.";
        yield return null;
        
    }

/*
    void waitForSpace()  // wait for space hit
    {
        // wait for 0.5s (just in case space has been pressed before)
        //yield return new WaitForSeconds(0.5f);

        while((!Input.GetKeyDown(KeyCode.Space))) // wait for spacebar key
        yield return null; // to finish the while loop

        // wait for 0.5s (just in case space should be pressed afterwards)
        //yield return new WaitForSeconds(0.5f);
    }
*/
}