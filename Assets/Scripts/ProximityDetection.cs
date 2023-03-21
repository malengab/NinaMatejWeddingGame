using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text

public class ProximityDetection : MonoBehaviour
{
    //public GameObject obj;    // any object
    //public GameObject Ninej;  // the player character
    //public GameObject objClick;  // dot appearing at proximity

    private GameObject Ninej; // Find the player
    private GameObject Figs; 
    private GameObject Obj;
    private bool close;
    private Text infoText;

    // Start is called before the first frame update
    void Start()
    {
        Figs = GameObject.Find( "Figs" );
        Ninej = Figs.transform.Find( "Ninej" ).gameObject;
        //Ninej = Figs.transform.Find( "ObstacleClick" ).gameObject;
        //print("Found Ninej!");

        // find infotext gameobject
        infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //private String clickname;
        var clickname = this.name+"Click";
        //print(clickname);
        Obj = Figs.transform.Find(this.name).gameObject; // find the new object

        /*
        // this should scale better
            if (Mathf.Abs(this.transform.localPosition.x - Ninej.transform.localPosition.x) < 3f && 
            Mathf.Abs(this.transform.localPosition.y - Ninej.transform.localPosition.y) < 3f &&
            Mathf.Abs(this.transform.localRotation.z - Ninej.transform.localRotation.z) < 3f ) 
        */
        float width1 = Ninej.GetComponent<SpriteRenderer>().bounds.size.x;
        float width2 = Obj.GetComponent<SpriteRenderer>().bounds.size.x;
        float height1 = Ninej.GetComponent<SpriteRenderer>().bounds.size.y;
        float height2 = Obj.GetComponent<SpriteRenderer>().bounds.size.y;
        
        if (Mathf.Abs(this.transform.localPosition.x - Ninej.transform.localPosition.x) <  (width1 + width2)/2 + .1f && 
            Mathf.Abs(this.transform.localPosition.y - Ninej.transform.localPosition.y) < (height1 + height2)/2 + .1f) 
            {
                //print("happy to be so close, "+clickname+"!");

                Figs.transform.Find(clickname).gameObject.SetActive(true);
                close = true;
                //var size = new Vector3(this.transform.Collider.box.x, this.transform.Collider.box.y, this.transform.Collider.box.z);
                //print(size.ToString());
                /* this works
                float width1 = Ninej.GetComponent<SpriteRenderer>().bounds.size.x;
                float width2 = Obj.GetComponent<SpriteRenderer>().bounds.size.x;
                print(width1.ToString() + " + "+width2.ToString());
                */
            }
            else
            {
                Figs.transform.Find(clickname).gameObject.SetActive(false);
                close = false;
            }
            
        if (close)
        {
            //print("You can press T or G!");
            GameObject.Find("Scripts").GetComponent<pressKey>().meow(this.name);
            //GameObject.Find("Correct").GetComponent<CorrectPos>().Victory();
            //print("we are close to "+this.name);
        }
    }
}
