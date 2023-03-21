using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text

public class CafeTalk : MonoBehaviour
{
    private Text introText;
    private GameObject Figs; 
    
    // Start is called before the first frame update
    void Start()
    {
        //Text introText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>();
        //introText.text = "Matěj wakes up feeling cold. The window is open and Nina is gone. There are some paper origami birds on the window sill.\n\n\n\n[press SPACE to continue]";
        
        // walk through the tutorial
        StartCoroutine(Talk());  // start tutorial coroutine
    }

    //IEnumerator Tutorial(Text introText)
    IEnumerator Talk()
    {
        Text introText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>();
        //Figs = GameObject.Find( "Figs" );  // find figs folder

        //GameObject Matej = Figs.transform.Find( "Ninej" ).gameObject; // find matej
        
        while((!Input.GetKeyDown(KeyCode.Space))) // wait for spacebar key
        yield return null; // to finish the while loop

        introText.text = "He gets up and walks around the room.";

        // wait for 0.5s (just in case space has been pressed before)
        yield return new WaitForSeconds(0.5f);

        ///////////////////////////////////////////////////////////////////////////////////////
       /* 
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
        */
    }
}
