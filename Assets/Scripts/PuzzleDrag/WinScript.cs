using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI; // for button


public class WinScript : MonoBehaviour
{
    // creating static class for points
    public class TangramMatches
    {
        //public static List<string> inv = new List<string>(); // inventory
        public static Dictionary <(int,int),bool> points = new Dictionary<(int,int),bool>();
    }

    TangramMatches tangramMatches = new TangramMatches(); // initiate

    private int pointsToWin;
    private int currentPoints;
    public GameObject myShips;
    // check for unique matches (i.e. black pieces shouldn't have two solutions)
    private Dictionary <int,int> point; // = new Dictionary<int,int>();
    private bool tangramDone;  // check if we ever finished the minigame

    //Dictionary <int,bool> points = new Dictionary<int,bool>();

    //private  SortedDictionary<string, string> id_to_state;

    // Start is called before the first frame update
    void Start()
    {
        pointsToWin = myShips.transform.childCount;
        tangramDone = false; // initiate
    }

    // Update is called once per frame
    void Update()
    {
        //print(currentPoints);
        if ((currentPoints >= pointsToWin)   && // if all placed correctly
            !(tangramDone))   // and tangram not done
        {
            //WIN
            transform.GetChild(0).gameObject.SetActive(true);
            //this.gameObject.GetComponent<CorrectPos>().Victory();
            GameObject.Find("Correct").GetComponent<CorrectPos>().Victory();

            // add SNACK to your inventory and remove knife
            IntroScene.Inventory.inv.Add("snack"); // add to inventory
            IntroScene.Inventory.inv.Remove("knife"); // remove
            // remove breakfast from the game
            IntroScene.CurrentState.ItemsActive.Remove("breakfast");
            // allow ninej to leave the house
            IntroScene.CurrentState.RoomsActive.Add("Porch");

            // at that point, tangram is done
            tangramDone = true;
            IntroScene.CurrentState.GameFinished.Add("tangram");

            // failed attempts to show button only upon completion
            /*
            // load button to kitchen
            //UnityEngine.UI.Button myBut = GameObject.Find("Canvas").GetComponent<UnityEngine.UI.Button>();//.SetActive(true);
            
            //UnityEngine.UI.Button myBut = GameObject.Find("Canvas/Button").GetComponent<Button>();//.SetActive(true);
            //myBut.gameObject.SetActive(true);
            
            //GameObject.Find("GameObjectName").GetComponent<Button>();
            //Button ButtonObj = GameObject.Find("Button").GetComponent<Button>;

            //Button _button = GameObject.Find("Button").GetComponent<UnityEngine.UI.Button>();
            */
        }
    }

    //public void AddPoints(int id, bool status)
    // added id2 to have all combinations
    public void AddPoints(int id, int id2,bool status)
    {
        // print(id.ToString()+" "+id2.ToString() + ", status = " + status.ToString());
        //id_to_state[id] = id; //"done-o!";
        //currentPoints++;
        //points.Add(id,status);
        TangramMatches.points[(id,id2)] = status;

        //string hej;
        //hej = "";

        currentPoints = 0; // initiate
        point = new Dictionary<int,int>();
        
        foreach (var (key, value) in TangramMatches.points) //(int i=0; i< pointsToWin; i++)
        {
            //hej = hej + key;

            //currentPoints += value ? 1 : 0;
            //print(key.ToString() + " " +value.ToString());

            if (value)
            {
                point[key.Item2] = key.Item1;
                //print(point.ToString());
                // print(key.Item1);
            }

        }
        // finally count the unique matchings
        //REMOVE AFTER TESTING
        currentPoints = 7; //point.Count;

        //print(currentPoints);
    }

    public void endGame()
    {
        // load the game scene
        SceneManager.LoadScene("Kitchen");
    }


}
