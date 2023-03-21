using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPos : MonoBehaviour
{
    public GameObject myShips;
    //public GameObject myBlackShips;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {      
    }

    // after placing everything correctly, snap to grid and disable further moves
    public void Victory()
    {
        //foreach(Transform child in transform)
        for(int i = 0; i < myShips.transform.childCount; i++)
        {   
            //myShips.transform.GetChild(i).localPosition = myBlackShips.transform.GetChild(i).localPosition;  // set exact location at the end
            //myShips.transform.GetChild(i).localRotation = myBlackShips.transform.GetChild(i).localRotation;  // set exact location at the end
            myShips.transform.GetChild(i).GetComponent<Collider2D>().enabled=false;  // so that points don't keep adding up upon clicking
        }  

    }
}
