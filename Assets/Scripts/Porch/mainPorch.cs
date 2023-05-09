using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text

public class mainPorch : MonoBehaviour
{

    private bool debug; // debugging mode bool
    private Text infoText;  // infotext field
    
    // Start is called before the first frame update
    void Start()
    {
        debug = true;

        if (debug)
        {
            IntroScene.initiateCurrentState(); // load initial setup
            //IntroScene.Inventory.inv.Add("onemoreloss");
            IntroScene.CurrentState.RoomsActive.Add("Porch");  
            IntroScene.Inventory.inv.Add("mailboxKey");
            IntroScene.CurrentState.ItemsActive.Add("mailbox");
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        // find infotext gameobject
        Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>();

        // check if any important key has been pressed
        if (Input.GetKeyDown(KeyCode.H))  // press H key for help
        {
            //print("Heeelp");
            //infoText.text = "Press G for GIVE, T for TAKE/TALK (both next to an object), I for INVENTORY, H for HELP, R for a random quote.";
            infoText.text = IntroScene.Help();

        }
        if (Input.GetKeyDown(KeyCode.I)) // press I key for inventory
        {
            infoText.text = IntroScene.ShowInv();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))  // wipe the infotext
        {
            infoText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.R))  // random quote
        {
            infoText.text = IntroScene.RandomQuote();
        } 
        if (Input.GetKeyDown(KeyCode.E))  // examine object from inventory
        {
            //infoText.text = "What do you want to examine? "+ IntroScene.ShowInv(); //ask what to examine from inventory
            IntroScene.Examine();
        }  
    }
}
