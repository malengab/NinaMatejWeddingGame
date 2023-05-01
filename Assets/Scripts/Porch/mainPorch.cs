using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text

public class mainPorch : MonoBehaviour
{

    private bool debug; // debugging mode bool
    private Text infoText;  // infotext field
    //private Example example;  // callin instance of example script
    private Examine examine; // script EXAMINE

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
            infoText.text = "What do you want to examine? "+ IntroScene.ShowInv(); //ask what to examine from inventory

            // creates warning but works
            //Example example = new Example();//GetComponent<Example>(); // get an instance of Example, otherwise you're trying to access a non-static member (field, method, or property) of a class from a static method or a static field.
            //Example example = GetComponent<Example>();

            /*
            // ChatGPT: the Example class inherits from MonoBehaviour but is not attached to a GameObject, you can't create an instance of the Example class using the new keyword as you would for a normal class. Instead, you can use the AddComponent method to add the Example component to a GameObject at runtime and then access its fields and methods.
            GameObject exampleObject = new GameObject("ExampleObject");
            example = exampleObject.AddComponent<Example>();             
            //example.wrt(); 
            */

            // ChatGPT: the Example class inherits from MonoBehaviour but is not attached to a GameObject, you can't create an instance of the Example class using the new keyword as you would for a normal class. Instead, you can use the AddComponent method to add the Example component to a GameObject at runtime and then access its fields and methods.
            GameObject exObject = new GameObject("ExObject");
            examine = exObject.AddComponent<Examine>();             
            //example.wrt();             

            // go directly to storyline, no introdcene, it is attached anyway // update i don't even need to attach it
            // storyline.exam("this");

        }  
    }
     // when done using the Example component, Destroy on the GameObject to remove it from the scene and free up memory
        private void OnDestroy() 
        {
            Destroy(examine.gameObject);
        }
}
