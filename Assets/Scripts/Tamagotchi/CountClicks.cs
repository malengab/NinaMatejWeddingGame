using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountClicks : MonoBehaviour
{
    static int counter=0; // lets start with zero

    // Update is called once per frame
    public void UpdateCount()
    {
        counter ++;
        print(counter.ToString());
    }

    public int PrintResult()  // return the number of clicks
    {
        //print("Found it!");
        return counter;
    }
}
