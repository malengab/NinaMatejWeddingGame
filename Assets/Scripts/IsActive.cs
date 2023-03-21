using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text
using UnityEngine.SceneManagement;  // scene switch

// checks if an object is currently active, i.e. on the current state list
// if not, makes it invisible
// this script has to be dragged to every object
public class IsActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //IntroScene.Inventory.inv.Add(it1); // add to inventory
        if (IntroScene.CurrentState.ItemsActive.Contains(this.name))
        {
            GameObject.Find(this.name).SetActive(true);
            //print("found it!");
            //print(IntroScene.CurrentState.ItemsActive.Count.ToString());
        }
        else
        {
            GameObject.Find(this.name).SetActive(false);
            //print("didn't find it");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
