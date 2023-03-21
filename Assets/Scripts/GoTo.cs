using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //text

// placed on collidor boxes
// will trigger upon touch
// moves scene to another room (script public input)
public class GoTo : MonoBehaviour
{
    public string DoorTo; // where does the door lead
    public string NoGo; // what to write in case door still closed
    private Text infoText;  // where to display
    private GameObject Ninej; // Find the player 
    private GameObject Figs;
    public string DoorSide;  // either L, R, U, or D // to know where to flip in the next turn    
/*
    void Start()
    {
    // if room we want to go to is on the list of active rooms
        if (IntroScene.CurrentState.RoomsActive.Contains(DoorTo))
        {
           print("helloleo");
        }
    }
*/

   // collison triggers entering another room
       private void OnTriggerEnter2D(Collider2D collision)
    {
        infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>();

        if (IntroScene.CurrentState.RoomsActive.Contains(DoorTo))
        {
            // record Ninej's positions
            Figs = GameObject.Find( "Figs" );
            Ninej = Figs.transform.Find( "Ninej" ).gameObject;

            if (DoorSide=="L") // door on the left
            {
                IntroScene.CurrentState.NinejPos = new Vector3(-Ninej.transform.position.x-2f, Ninej.transform.position.y, Ninej.transform.position.z);
            }
            else if (DoorSide=="R") // door on the right
            {
                IntroScene.CurrentState.NinejPos = new Vector3(-Ninej.transform.position.x+2f, Ninej.transform.position.y, Ninej.transform.position.z);
            }
            else if (DoorSide=="U") // door up
            {
                IntroScene.CurrentState.NinejPos = new Vector3(Ninej.transform.position.x, -Ninej.transform.position.y+2f, Ninej.transform.position.z);
            }
            else if (DoorSide=="D") // door down
            {
                IntroScene.CurrentState.NinejPos = new Vector3(Ninej.transform.position.x, -Ninej.transform.position.y- 2f, Ninej.transform.position.z);
            }
            else
            {
                print("hello");
            }
            // move to a new room
            SceneManager.LoadScene(DoorTo);
        }
        else  // the room is not accesible yet
        {
            //infoText.text = "Don't want to leave the house before breakfast.";   
            infoText.text = NoGo;   
        }
        
    }

}
