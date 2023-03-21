using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text

public class pressKey : MonoBehaviour
{

    // static List<string> inv = new List<string>(); // inventory old version
    IntroScene.Inventory inventory = new IntroScene.Inventory(); // initiate inventory
    private Text infoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void meow(string str)
    {
        // find infotext gameobject
        Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>();
        //infoText.text = "Take (T) or give (G).";


        if (Input.GetKeyDown(KeyCode.T))  // pick up
        {
            // add item to inventory

            /*
            //print("Wow, you did press T...");
            inv.Add(str);
            //print(inv.Count.ToString()); # how many items in itinerary
            */

            //string message = GameObject.Find("Scripts").GetComponent<storyline>().checkYourSources(str,"take");
            //print(message);
            GameObject.Find("Scripts").GetComponent<storyline>().checkYourSources(str,"take");

            /* move to script storyline
            // if the message is TAKE
            if (message == "take")
            {
                // add to inventory
                // inv.Add(str);
                // inventory.add(str); // works but I change it here instead
                IntroScene.Inventory.inv.Add(str);
                infoText.text = "You picked "+str;

                // remove item from game
                GameObject.Find(str).SetActive(false);
                GameObject.Find(str+"Click").SetActive(false);
            }
            else
            {
                infoText.text = message;
            }
            */


        }

        
        if (Input.GetKeyDown(KeyCode.G))   // give item / use it
        {

            // StartCoroutine(Give(infoText,inv,str));
            StartCoroutine(Give(infoText,str));
        
        }
        
    }   

    
    // IEnumerator Give(Text infoText,List<string> inv,string str)
    IEnumerator Give(Text infoText,string str)
    {
        /* old version from when inv wasn't static
        // list itenery items
        string itemstring = "";
        for (int i = 0; i < inv.Count; i++) 
        {
            itemstring += "(" + i.ToString() + ") " + inv[i] + " ";
        }
        */

        // list itenery items
        string itemstring = "";
        for (int i = 0; i < IntroScene.Inventory.inv.Count; i++) 
        {
            itemstring += "(" + i.ToString() + ") " + IntroScene.Inventory.inv[i] + " ";
        }

            
        infoText.text = "Which item do you want to use?" + "\n" +  itemstring;
        //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1));
        //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha2));
        //print("success");
        //yield return null;

        // wait until a number is pressed
        // very ugly while loop
        while((!Input.GetKeyDown(KeyCode.Alpha0)) & 
                (!Input.GetKeyDown(KeyCode.Alpha1)) &
                (!Input.GetKeyDown(KeyCode.Alpha2)) &
                (!Input.GetKeyDown(KeyCode.Alpha3)) &
                (!Input.GetKeyDown(KeyCode.Alpha4)) &
                (!Input.GetKeyDown(KeyCode.Alpha5)) &
                (!Input.GetKeyDown(KeyCode.Alpha6)) &
                (!Input.GetKeyDown(KeyCode.Alpha7)) &
                (!Input.GetKeyDown(KeyCode.Alpha8)) &
                (!Input.GetKeyDown(KeyCode.Alpha9)) &
                (!Input.GetKeyDown(KeyCode.Backspace)))
        
        yield return null; // to finish the while loop

        int objectToRemove;
        // this sections still records the SAME keystroke, so no need to click twice
        // even uglier for loop
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            objectToRemove = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            objectToRemove = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            objectToRemove = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            objectToRemove = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            objectToRemove = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            objectToRemove = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            objectToRemove = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            objectToRemove = 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            objectToRemove = 8;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            objectToRemove = 9;
        }
        else
        {
            objectToRemove = 100;  //nonsense number
        }

        // first check for backspace
        if (objectToRemove == 100)
        {
            //yield return null;   // leave loop if pressed
            infoText.text = "....................";
            yield break;
        }

        // check if item exists in itinerary
        if (objectToRemove>=IntroScene.Inventory.inv.Count)
        {
            infoText.text = "Item " + objectToRemove.ToString() + " does not exist.";
            yield return null;
        }
        else
        {
            /* moved directly to storyline script
            infoText.text = "Good riddance, " + IntroScene.Inventory.inv[objectToRemove] + "!";

            // check your story sources

            string message = GameObject.Find("Scripts").GetComponent<storyline>().checkYourSources(str,"give",IntroScene.Inventory.inv[objectToRemove]);
            //print(message);

            // if the message is GIVE
            if (message == "givenow")
            {
                // remove item from inventory
                IntroScene.Inventory.inv.RemoveAt(objectToRemove);
            }
            else
            {
                infoText.text = message;
            }
            */
            
        GameObject.Find("Scripts").GetComponent<storyline>().checkYourSources(str,"give",IntroScene.Inventory.inv[objectToRemove]);

        }
        yield return null;



        /* infinite loop, but some nice functions inside
        bool keypressed = false;
        while (!keypressed)
        {
            for (int j = 0; j < inv.Count; j++)
            //{
                //string keystroke = "KeyCode.Alpha1";// + inv[j].ToString();
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1));
            {
                //infoText.text = "Give " + inv[j].ToString() + " to him.";
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    infoText.text = "Gimmegimmegimme";
                    keypressed = true;
                    yield return null;
                }
            }
        //}
        }
        // if number pressed
        //yield return null;        
       */ 
    }
    
}