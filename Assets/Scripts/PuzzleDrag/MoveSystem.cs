using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{

    public GameObject correctForm; // used to be item, now a folder
    public bool symmetry90;  // is object rotationally symmetric (90 degrees)
    public bool symmetry180; // is object rotationally symmetric (180 degrees)
    // public int id;
    private bool moving;
    private bool finish;
    private bool rotating;

    private float startPosX;
    private float startPosY;
    private float startRot;

    //private Vector3 resetPosition;

    //public string id = "mjau";

    // Start is called before the first frame update
    //void Start()
    //{
    //    resetPosition = this.transform.localPosition;
    //}

    // Update is called once per frame
    void Update()
    {
        //if (finish) {
        //    return;
        //}

        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        }

        if (rotating)
        {
            //Vector3 mousePos;
            //mousePos = Input.mousePosition;
            //mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.Rotate(0,0,90);
            rotating = false;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            startRot = this.transform.localRotation.z;

            moving = true;
            //print("notclicking");

        }
                
        if (Input.GetMouseButtonDown(1))
        {
            //Vector3 mousePos;
            //mousePos = Input.mousePosition;
            //mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            //startPosX = mousePos.x - this.transform.localPosition.x;
            //startPosY = mousePos.y - this.transform.localPosition.y;



            //moving = true;

        //    rotation  = this.transform.localRotation.z + 90;
            //this.transform.Rotate(0,0,90);
            //print("clicking");
            rotating = true;
            //moving = true;

        }
    }


    private void OnMouseUp()
    {
        moving = false;
        rotating = false;

    //print(this.transform.eulerAngles.z.ToString() + " " + correctForm.transform.GetChild(0).eulerAngles.z.ToString());
/*  
        Vector3 distance;
        distance = new Vector3(Mathf.Abs(this.transform.localPosition.x - correctForm.transform.GetChild(0).localPosition.x), 
            Mathf.Abs(this.transform.localPosition.y - correctForm.transform.GetChild(0).localPosition.y),
            Mathf.Abs(this.transform.localRotation.z - correctForm.transform.GetChild(0).localRotation.z));
        print("Distance = " + distance.ToString());

        float width1 = this.transform.GetComponent<SpriteRenderer>().bounds.size.x;
        print("Width = " + width1);
*/

        //foreach(Transform child in transform)
        //finish = false;
        // int id2 = 0;  // placeholder for the correct position's ID
        int id2;
        int id = this.gameObject.GetInstanceID();  // don't need this anymore
        // fo through all possible correct tile placements (in correctForm folder)
        for(int i = 0; i < correctForm.transform.childCount; i++)
        {
            /* this works if items not rotationally symmetric
            if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.GetChild(i).localPosition.x) < 0.5f && 
                Mathf.Abs(this.transform.localPosition.y - correctForm.transform.GetChild(i).localPosition.y) < 0.5f &&
                Mathf.Abs(this.transform.eulerAngles.z - correctForm.transform.GetChild(i).eulerAngles.z) < 0.5f ) 
                {
                    //this.transform.localPosition = new Vector3(correctForm.transform.localPosition.x,correctForm.transform.localPosition.y, correctForm.transform.localPosition.z);
                    finish = true;
                    //break; // don't look further
                    //print(id2.ToString());
                    //print("correct location");

                    //GameObject.Find("PointsHandler").GetComponent<WinScript>().AddPoints(id);
                    //this.gameObject.GetComponent<Collider2D>().enabled=false;  // so that points don't keep adding up upon clicking
                }
            */
            // first check if position is right
            if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.GetChild(i).localPosition.x) < 0.5f && 
                Mathf.Abs(this.transform.localPosition.y - correctForm.transform.GetChild(i).localPosition.y) < 0.5f)
                {   // rotation angles
                    float angle1 = this.transform.eulerAngles.z;
                    float angle2 = correctForm.transform.GetChild(i).eulerAngles.z;
                    // check if rotation is right
                    if (Mathf.Abs(angle1 - angle2) < 0.5f ) 
                    {   
                        finish = true;
                        //print("correct rot");
                    }
                    else if 
                    (// rotation is right given 180 symmetry
                        Mathf.Abs((angle1 + 180) % 360 - angle2) < 0.5f &&
                        symmetry180 == true
                    )
                    {
                        finish = true;
                        //print("almost cor rot 180");
                    }
                    else if 
                    (// rotation is right given 90 symmetry
                        Mathf.Abs((angle1 + 90) % 360 - angle2) < 0.5f &&
                        symmetry90 == true
                    )
                    {
                        finish = true;
                        //print("almost correct rot 90");
                    }
                    else if 
                    (// rotation is right given -90 symmetry
                        Mathf.Abs((angle1 - 90) % 360 - angle2) < 0.5f &&
                        symmetry90 == true
                    )
                    {
                        finish = true;
                        //print("almost correct rot -90");
                    }
                    else
                    {
                        finish = false;
                        //print("correct pos but not rotation");
                    }
                }
            
            else
            {
                finish = false;
                //print("Not finished");

                //this.transform.localPosition = new Vector3(resetPosition.x,resetPosition.y,resetPosition.z); 
                //this.transform.localRotation = new Vector3(this.transform.localRotation.x,this.transform.localRotation.y,90); //new rotation;   
                //this.transform.Rotate(0,0,90);   
            }

            id2 = correctForm.transform.GetChild(i).gameObject.GetInstanceID();
            GameObject.Find("PointsHandler").GetComponent<WinScript>().AddPoints(id,id2,finish);
                    
            
        }
        //id2 = this.gameObject.GetInstanceID();  // don't need this anymore
        
        //GameObject.Find("PointsHandler").GetComponent<WinScript>().AddPoints(id2,finish);
    }
}
