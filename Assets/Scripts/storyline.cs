using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text
using UnityEngine.SceneManagement;  // scene switch
using System; // error Exception

public class storyline : MonoBehaviour
{
    // list of items
    private List<string> items = new List<string>();
    
    // Given an item, what happens if we try to Take/give/examine it
    public static Dictionary<string, string> takeItem = new Dictionary<string, string>();
    private Dictionary<string, string> giveItem = new Dictionary<string, string>();
    private Dictionary<string, string> examineItem = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {

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
        items.Add("tamagotchi"); // 4

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
      
    }

    public static void checkYourSources(string it1, string instr1, params string[] it2)
    {
        // if the item should be taken
        if (instr1 == "take")
        {
            try  // check if item in list
            { // if it is
                string message = takeItem[it1];
                if (message == "takenow") // check if you are allowed to take the item
                {
                    IntroScene.Inventory.inv.Add(it1); // add to inventory
                    write("You picked "+it1);

                    // remove item from game
                    GameObject.Find(it1).SetActive(false);
                    GameObject.Find(it1+"Click").SetActive(false);
                    // and from active state objects
                    IntroScene.CurrentState.ItemsActive.Remove(it1);
                }
                else if (message == "talk") // talk to the person
                {
                    talk(it1);
                }
                 else
                {
                    //infoText.text = message;
                    write(message);
                }
            }
            catch  // item not in dictionary
            {
                write("Item " + it1 + " not in dictionary.");
            }
        }
        // if the item should be given
        else if (instr1 == "give")
        {
            if (it2.Length != 1)  // check if the number of item to give is right
            {
                write("Too many/few inputs?");
            }
            else
            {
                string itToGive = it2[0];
                // means give it2 TO it1
                givethat(it1,itToGive); // see if a given combination exists
            }
        }
        // examine item
        else if (instr1 == "exam")
        {
            write("Just a regular " + it1 + ".");
        }
        else
        {
            write("doodley doodley day");
        }

    }

///////////////////////////////////////////////////////////////////////////////////////////////
/// valid combinations corresponding to give command  /////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////


    public static void givethat(string giveTo,string giveWhat)
    {
        if ((giveTo == "breakfast") & (giveWhat == "knife"))
        {
            SceneManager.LoadScene("Breakfast_instruction");
        }
        else if ((giveTo == "heart") & (giveWhat == "paperclip"))
        {
            write("Good riddance, " + giveWhat+ "!");

            // remove item from inventory
            IntroScene.Inventory.inv.Remove(giveWhat);
        }
        else if ((giveTo == "paperclip") & (giveWhat == "heart"))
        {
            write("Good riddance, " + giveWhat + "!");

            // remove item from iventory
            IntroScene.Inventory.inv.Remove(giveWhat);
        }
        else if ((giveTo == "cat") & (giveWhat == "origami"))
        {
            write("Good riddance, " + giveWhat + "!");
        
            // remove item from inventory
            IntroScene.Inventory.inv.Remove(giveWhat);           
        }
        else if ((giveTo == "mailbox") & (giveWhat == "mailboxKey"))
        {
            write("Good riddance, " + giveWhat + "!");   
        
            // remove item from inventory
            IntroScene.Inventory.inv.Remove(giveWhat);

            // switch to tamagotchi scene
            //SceneManager.LoadScene("Tamagotchi");
            
            // add tamagotchi item to inventory
            IntroScene.Inventory.inv.Add("tamagotchi");
            write("Inside of the mailbox, there is a letter from Japan. You open it and out falls a cat tamagotchi.");
            // start tamagotchi
            IntroScene.CurrentState.GameBools["tamagotchiStarted"] = true;
            // No more letters in the mailbox
            takeItem["mailbox"] = "Only bills. Ignore.";
        }
        else // if a combination is not found
        {
            // just write a message that a given combination doesn't exist 
            write("You can't give " + giveWhat + " to " + giveTo + ".");
        }
    }

    // ##################################################################################################
    // write a message to infotext
    private static void write(string whattowrite) 
    {
        Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>(); // ocate infostring
        infoText.text = whattowrite;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // talk to a person
    private static void talk(string person)
    {
        if (person == "barista")
        {
            //print("baristaschmarista");
            SceneManager.LoadScene("TalkBarista");

        }
    }
}
