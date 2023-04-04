using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Feed : MonoBehaviour
{

    public GameObject Foods;    // all food figures (so that I can pick a random one)
    //public GameObject Heart;
    public GameObject Figs;     // all figures in folder /but food
    public Text lifeDisplay;   // text box to show vital signs
    public Slider hungerSlider;  // hunger meter slider
    public Slider happySlider;  // hunger meter slider


    private GameObject heart;
    private GameObject foo;  // particular food instance
    //private Vector2 StartPos;  // where does the food start
    //private Vector2 EndPos;   // where does the food end (cat's mouth)
    static float hungerCounter;  // how hungry // HUNGRY METER
    static float happyCounter; // how happy
    //private float timeRemaining;  // how much time to death
    static bool alive;  // is-the-cat-alive flag


    void Start()
    {

        int nclicks = GameObject.Find("Canvas").GetComponent<CountClicks>().PrintResult();  // call script to check point count
        if (nclicks == 0)  // the play button has not been clicked = we entered for the first time
        { // initialize
            hungerCounter = 10;
            happyCounter = 10;
            //timeRemaining = 10;
            alive = true;
        }
        /*  or it has been used in the past
        else
        {
            hungerCounter = 5;
            happyCounter = 5;
            alive = true;
        }
        */
        
    }

    void Update()
    {
        if ((hungerCounter > 0) & (happyCounter > 0))
        {
            hungerCounter -= Time.deltaTime;    // getting more hungry every second
            happyCounter -=Time.deltaTime/2;  // happines goes down slower
            //print(timeRemaining);

            lifeDisplay.text = "Papat"+ hungerCounter.ToString();
            hungerSlider.value = hungerCounter/10;
            
            happySlider.value = happyCounter/10;


            // change the bar color based on counter value from green to orange
            ColorBar(hungerSlider,hungerCounter);
            ColorBar(happySlider,happyCounter);
        }
        else
        {
            alive = false; // kitty dead
            Figs.transform.Find( "Kitty" ).gameObject.SetActive(false);
            Figs.transform.Find( "RIP" ).gameObject.SetActive(true);
            lifeDisplay.text = "KYS";//meow;
            //hungerSlider.value = 0f;
        }
    }

    void ColorBar(Slider slider, float count)  // // change the bar color based on counter value from green to orange
    {
            Color color;
            if (count >= 2) 
            {
                color = new Color(50f/255f, 205f/255f, 50f/255f);  // green
            }
            else
            {
                color = new Color(233f/255f, 79f/255f, 55f/255f);  // orange
            }
            slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color; 
    }

    public void Meow()  // press to feed
    {
        if (alive)
        {
            
            StartCoroutine(MoveFood());
            //Invoke("MoveFood",0);

            // increase the satiation counter
            hungerCounter = Math.Min(10,hungerCounter+1);
            //print(counter);
        }
    }

        public void Play()  // press to play
    {
        if (alive)
        {
            
            //StartCoroutine(MoveFood());
            print("GG");
            
            // load the minigame scene
            SceneManager.LoadScene("Minigame");//,LoadSceneMode.Additive); // LoadSceneMode.Additive doesnt destroy the previous scene and its variables
            //SceneManager.LoadSceneAsync("Minigame");//,LoadSceneMode.Additive);

            // increase the happiness counter
            happyCounter = Math.Min(10,happyCounter+3);
            //print(counter);
        }
    }

    IEnumerator MoveFood()
    {
        //foo = Figs.transform.Find( "RIP" ).gameObject;  // Figs has to be direct root

    // feed cat
        //print("WhosAGoodCat?");

    // random generate food  (nr from 0 to Foods.transform.childCount)
        foo = Foods.transform.GetChild(UnityEngine.Random.Range(0,Foods.transform.childCount)).gameObject;  // randomly select foods

        //StartPos = foo.transform.localPosition;
        //EndPos = Heart.transform.localPosition;  

        var period = 0.1f;

        //IceCream.SetActive(true);
        // Foods.transform.GetChild(1).gameObject.SetActive(true); // this one works

        foo.SetActive(true); // make the food show

        yield return new WaitForSeconds(1f);

    // move and hide food
        //foo.transform.localPosition = EndPos;
        //yield return new WaitForSeconds(1f);

        foo.SetActive(false);

        yield return new WaitForSeconds(period);

    // happy cat
        heart = Figs.transform.Find( "Heart" ).gameObject;
        heart.SetActive(true); 

        yield return new WaitForSeconds(period);

    // flash heart
        heart.SetActive(false); 
        yield return new WaitForSeconds(period);
        heart.SetActive(true); 
        yield return new WaitForSeconds(period);
        heart.SetActive(false); 
        yield return new WaitForSeconds(period);
        heart.SetActive(true); 
        yield return new WaitForSeconds(period);
        heart.SetActive(false); 
    }

}