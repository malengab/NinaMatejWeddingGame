using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //text

public class MainMenu : MonoBehaviour
{

    
    private void Start()
    {
        Text infoText = GameObject.Find("Canvas/Infotext").GetComponent<UnityEngine.UI.Text>(); // ocate infostring
        infoText.text = "Oops! You cut the bread to too many pieces. Can you even assemble it again?";
    }


    // Start is called before the first frame update
    public void LoadGame()
    {
        // load the game scene
        SceneManager.LoadScene("PuzzleDrag"); 
    
    }
}
