using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveNinej : MonoBehaviour
{
    float speed = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // update Ninej's position in the room
        //transform.position = new Vector3(7,-3,0);
        transform.position = IntroScene.CurrentState.NinejPos;
    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
        transform.position += move * speed * Time.deltaTime;       
    }
}
