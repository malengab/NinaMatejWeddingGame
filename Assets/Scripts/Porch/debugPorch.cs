using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugPorch : MonoBehaviour
{

    private bool debug;

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
        
    }
}
