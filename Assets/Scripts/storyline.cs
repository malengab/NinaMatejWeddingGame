using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text
using UnityEngine.SceneManagement;  // scene switch

public class storyline : MonoBehaviour
{
    //private bool debug; // are we in debugging mode
    private List<string> items = new List<string>();
    //private GameObject Figs; // all items
    //private int ne;

    // Given an item, what happens if we try to Take it?
    private Dictionary<string, string> takeItem = new Dictionary<string, string>();

    private Dictionary<string, string> giveItem = new Dictionary<string, string>();
    // private Dictionary<(string,string), string> giveItem = new Dictionary<(string,string), string>();
    //static List<string> inv = new List<string>();  // inventory
    //private Text infoText;

    //private Dictionary<string, string> giveItem;
     
    //Dictionary <string, string> fruits = new Dictionary<string, string>();  

    // Call methods using names in C# (using reflection)
    public void InvokeMethod(string methodName, object[] objs)
    {
        GetType().GetMethod(methodName).Invoke(this, new object[] { objs });
    }


    // Start is called before the first frame update
    void Start()
    {
        /*
        debug = true;

        if (debug) // if in debugging mode run IntroScene here
        {
            gameObject.GetComponent<IntroScene>().Start();
        }
        */

        //Figs = GameObject.Find( "Figs" );
        //ne = Figs.transform.childCount;

        // I could do this automatically but still need to list all interactions manually so whatever
        items.Add("heart");    // Room nr 1 = bedroom
        items.Add("RIP");       // 1
        items.Add("paperclip"); // 1
        items.Add("origami");   // 0 = intro
        items.Add("cat");       // 0
        items.Add("breakfast"); // 2 = kitchen
        items.Add("knife");     // 2
        items.Add("snack");     // 3 = tangram minigame, through PuzzleDrag/WinScript
        items.Add("mailbox");   // 4 = porch
        items.Add("barista");   // 5 = cafe
        items.Add("mailboxKey");  // ?

        // dictionary of interactions with items (TAKE)
        // format (ITEM, INSTRUCTION)
        // if INSTRUCTION = "takenow" -> ITEM added to itinerary + generic confirmation message.
        // if INSTRUCTION = <other message> -> print <other message> and nothing else happens.
        // else -> prints a message "ITEM not in dictionary".
        takeItem.Add("heart","takenow");
        takeItem.Add("RIP","You can't just pick a tombstone!");
        takeItem.Add("paperclip","takenow");
        takeItem.Add("origami","takenow");
        takeItem.Add("cat","The cat growls and hisses. You decide not to push the issue.");
        takeItem.Add("breakfast","You will need a knife to eat your breakfast.");
        takeItem.Add("knife","takenow");
        takeItem.Add("mailbox","There are important-looking letters in the mailbox. Where did you leave your keys?");
        takeItem.Add("barista","talk"); // talk not take

        /* obsolete: removed last parameter
        // dictionary of interactions with items (GIVE)
        // format ((RECIPIENT,ITEM), INSTRUCTION)
        // if INSTRUCTION = "givenow" -> ITEM removed from itinerary + generic confirmation message.
        // if INSTRUCTION = <other message> -> <other message> printed and nothing else happens.
        // if else -> message "You can't give ITEM to RECIPIENT" and nothing happens.
        giveItem.Add(("heart","paperclip"),"givenow");
        giveItem.Add(("RIP","paperclip"),"Wow, why would you give a paperclip to the tombstone?");
        giveItem.Add(("paperclip","heart"),"givenow");
        giveItem.Add(("cat","origami"),"givenow");
        giveItem.Add(("breakfast","knife"),"breakfastknife"); //,"breakfast");
        */

        // OBS I don't actually use the giveItem list, rather the method RECIPIENT_ITEM directly
        // dictionary of interactions with items (GIVE)
        // format (RECIPIENT,ITEM)
        // There is a method RECIPIENT_ITEM() corresponding to each valid combination with further instructions
        // All other combinations not listed here or missing RECIPIENT_ITEM method-> message "You can't give ITEM to RECIPIENT" and nothing happens.
        giveItem.Add("heart","paperclip");
        //giveItem.Add(("RIP","paperclip"),"Wow, why would you give a paperclip to the tombstone?");
        giveItem.Add("paperclip","heart");
        giveItem.Add("cat","origami");
        giveItem.Add("breakfast","knife"); 
        giveItem.Add("mailbox","mailboxKey");
      
    //print(CurrentState.ItemsActive[0]);
    }

    public void checkYourSources(string it1, string instr1, params string[] it2)
    {
        Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>(); // ocate infostring
        //string message;

        if (instr1 == "take")
        {
            try  // check if item in list
            { // if it is
                string message = takeItem[it1];
                if (message == "takenow") // check if you are allowed to take the item
                {
                    IntroScene.Inventory.inv.Add(it1); // add to inventory
                    infoText.text = "You picked "+it1;

                    // remove item from game
                    GameObject.Find(it1).SetActive(false);
                    GameObject.Find(it1+"Click").SetActive(false);
                    // and from active state objects
                    IntroScene.CurrentState.ItemsActive.Remove(it1);
                    //print("Removed"+it1);
                    //print(IntroScene.CurrentState.ItemsActive.Count.ToString());
                }
                else if (message == "talk") // talk to the person
                {
                    //print("talking heads");
                    talk(it1);
                }
                 else
                {
                    infoText.text = message;
                }
            }
            catch  // item not in dictionary
            {
                infoText.text=  "Item " + it1 + " not in dictionary."; 
            }
        }
        else if (instr1 == "give")
        {
            if (it2.Length != 1)  // check if the number of item to give is right
            {
                infoText.text = "Too many/few inputs?";
            }
            else
            {
                string itToGive = it2[0];
                // means give it2 TO it1
                try
                { // check if a given combination exists
                    //print(it1+"_"+it2[0]);

                    /*  # giveaway instruction was not specific enough
                    string message = giveItem[(it1,itToGive)];  // what is the message in that case
                    if (message == "givenow")
                    {
                        // remove item from iInvokeMethodnventory
                        IntroScene.Inventory.inv.Remove(itToGive);
                        infoText.text = "Good riddance, " + itToGive + "!";
                    }
                    else
                    {   // can't give it2 to it1
                        infoText.text = message;
                    }
                    */
                    //string methodName = giveItem[(it1,itToGive)];
                    //print(methodName);
                    
                    string methodName = it1 + "_" + itToGive; 
                    // args = string you pass to the functions
                    // args[0] expects itToGive
                    string[] args = new[] { itToGive };  // make an array
                    object[] objs = args;       // wrap it as an object
                    InvokeMethod(methodName,objs);  // invoke corresponding function
                    
                }
                catch // if a given combination doesn't exist throw a message only
                {
                    //return "dooley fooley";
                    infoText.text = "You can't give " + itToGive + " to " + it1 + ".";
                }
                
            }
        }
        else
        {
            infoText.text = "doodley doodley day";
        }

    }


///////////////////////////////////////////////////////////////////////////////////////////////
/// methods corresponding to give command  ////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////

    public void breakfast_knife(string[] args)
    { //args = {ITEM_TO_BE_GIVEN}
        /*
        // print("success!");
        Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>(); // ocate infostring
        infoText.text = "Good riddance, " + args[0] + "!";
        //print(args[0]);

        // UPDATE: only remove the knife after minigame is done
        // remove item from iInvokeMethodnventory
        // IntroScene.Inventory.inv.Remove(args[0]);   
        */

        // launch intoscene to a minigame
        SceneManager.LoadScene("Breakfast_instruction");      
    }

    public void heart_paperclip(string[] args)
    { //args = {ITEM_TO_BE_GIVEN}
        Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>(); // ocate infostring
        infoText.text = "Good riddance, " + args[0] + "!";
        
        // remove item from iInvokeMethodnventory
        IntroScene.Inventory.inv.Remove(args[0]);
    }

    public void paperclip_heart(string[] args)
    { //args = {ITEM_TO_BE_GIVEN}
        Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>(); // ocate infostring
        infoText.text = "Good riddance, " + args[0] + "!";
        
        // remove item from iInvokeMethodnventory
        IntroScene.Inventory.inv.Remove(args[0]);
    }

    public void cat_origami(string[] args)
    { //args = {ITEM_TO_BE_GIVEN}
        Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>(); // ocate infostring
        infoText.text = "Good riddance, " + args[0] + "!";
        
        // remove item from iInvokeMethodnventory
        IntroScene.Inventory.inv.Remove(args[0]);
    }

    public void mailbox_mailboxKey(string[] args)
    // here will be the tamagochi minigame
    { //args = {ITEM_TO_BE_GIVEN}
        Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>(); // ocate infostring
        infoText.text = "Good riddance, " + args[0] + "!";
        
        // remove item from iInvokeMethodnventory
        IntroScene.Inventory.inv.Remove(args[0]);
    }

    

    private void talk(string person)
    {
        if (person == "barista")
        {
            //print("baristaschmarista");
            SceneManager.LoadScene("TalkBarista");

        }
    }

    /* older version when the output was just a string
    public string checkYourSources(string it1, string instr1, params string[] it2)
    {
        if (instr1 == "take")
        {
            try  // check if item in list
            {
                return takeItem[it1];
            }
            catch
            {
                return "Item " + it1 + " not in dictionary."; 
            }
        }
        else if (instr1 == "give")
        {
            // means give it1 TO it2
            try
            { // check if a given combination exists
                //print(it1+"_"+it2[0]);
                return giveItem[(it1,it2[0])];
            }
            catch
            {
                //return "dooley fooley";
                return "You can't give " + it2[0] + " to " + it1 + ".";
            }
        }
        else if (it2.Length != 0)
        {
            return "doodley doodley day";
        }
        else
        {
            return "nothing to say";
        }
    }
    */

}
