using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugKitchen : MonoBehaviour
{

    private bool debug;

    // Start is called before the first frame update
    void Start()
    {
        debug = true;

        if (debug)
        {
            IntroScene.initiateCurrentState(); // load initial setup
            IntroScene.CurrentState.RoomsActive.Add("Porch");  
            IntroScene.CurrentState.ItemsActive.Add("knife");
            IntroScene.CurrentState.ItemsActive.Add("breakfast");
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
