using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text

public class Examine : MonoBehaviour
{
    private bool isKeyPressed = false;
    private KeyCode[] allowedKeys = { KeyCode.Alpha0, 
                                    KeyCode.Alpha1, 
                                    KeyCode.Alpha2,
                                    KeyCode.Alpha3,
                                    KeyCode.Alpha4,
                                    KeyCode.Alpha5,
                                    KeyCode.Alpha6,
                                    KeyCode.Alpha7,
                                    KeyCode.Alpha8,
                                    KeyCode.Alpha9,
                                    KeyCode.Backspace,
                                    KeyCode.Delete
                                     };

    /*
    private void Start()
    {
        //Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>();
        //infoText.text = "we are in";
        //infoText.text = "Which item do you want to use?" + "\n" +  itemstring;
    }
    */

    private void Update()
    {
        if (!isKeyPressed)
        {
            //Debug.Log("Press A, B, or C to continue...");
            CheckForKeyPress();
        }
    }

    private void CheckForKeyPress()
    {
        foreach (KeyCode key in allowedKeys)
        {
            if (Input.GetKeyDown(key))
            {
                //Debug.Log("You pressed " + key);
                isKeyPressed = true;
                whichKey(key); // which key has been pressed
                break;
            }
        }
    }

    private void whichKey(KeyCode kk)
    {
        // key corresponds to item
        int objectToExamine;  // index of the item in question
        Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>();
            
        if (kk == KeyCode.Alpha0)
        {
            objectToExamine = 0;
        } 
        else if (kk == KeyCode.Alpha1)
        {
            objectToExamine = 1;
        }
        else if (kk == KeyCode.Alpha2)
        {
            objectToExamine = 2;
        }
        else if (kk == KeyCode.Alpha3)
        {
            objectToExamine = 3;
        }
        else if (kk == KeyCode.Alpha4)
        {
            objectToExamine = 4;
        }
        else if (kk == KeyCode.Alpha5)
        {
            objectToExamine = 5;
        }
        else if (kk == KeyCode.Alpha6)
        {
            objectToExamine = 6;
        }
        else if (kk == KeyCode.Alpha7)
        {
            objectToExamine = 7;
        }
        else if (kk == KeyCode.Alpha8)
        {
            objectToExamine = 8;
        }
        else if (kk == KeyCode.Alpha9)
        {
            objectToExamine = 9;
        }
        else // backspace or delete
        {
            objectToExamine = 100;  //nonsense number
        }

           // first check for backspace or delete
        if (objectToExamine == 100)
        {
            infoText.text = "....................";
        }
        // check if item exists in itinerary
        else if (objectToExamine>=IntroScene.Inventory.inv.Count)
        {
            infoText.text = "Item " + objectToExamine.ToString() + " does not exist.";
        }
        else
        { // if it does, go to storyline for further instructions
            storyline.checkYourSources(IntroScene.Inventory.inv[objectToExamine],"exam");
        } 
    }
}
