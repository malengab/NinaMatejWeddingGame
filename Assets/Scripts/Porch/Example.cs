using UnityEngine;

public class Example : MonoBehaviour
{
    private bool isKeyPressed = false;
    private KeyCode[] allowedKeys = { KeyCode.A, KeyCode.B, KeyCode.C };

    private void Update()
    {
        if (!isKeyPressed)
        {
            Debug.Log("Press A, B, or C to continue...");
            CheckForKeyPress();
        }
    }

    private void CheckForKeyPress()
    {
        foreach (KeyCode key in allowedKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Debug.Log("You pressed " + key);
                isKeyPressed = true;
                break;
            }
        }
    }

}