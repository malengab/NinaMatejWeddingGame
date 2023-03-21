using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneMain : MonoBehaviour
{
    public string room;

    public void LoadGame()
    {
        //SceneManager.LoadScene("Bedroom");
        SceneManager.LoadScene(room);
    }
}
