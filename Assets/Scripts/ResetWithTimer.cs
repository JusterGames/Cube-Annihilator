using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class ResetWithTimer : MonoBehaviour
{
    //player reset code
    

    [SerializeField, Range(30, 300)]
    float timerInterval = 120f;

    [SerializeField]
    List<TextMeshPro> timerText = new List<TextMeshPro>();

    float timer = 0;
    bool timerIsRunning = true;

    Vector3 startPosition;
    Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        Debug.Log("Start Pos & Rot are " + startPosition + "&" + startRotation);
        startRotation = this.transform.rotation;
        timer = timerInterval;
    }

    // Update is called once per frame
    void Update()
    {
        //Timer code
        // every frame, subtract time from timer.
        if (timerIsRunning) 
        {
            timer -= Time.deltaTime;

            // Check if all "item" game objects have been destroyed
            if (GameObject.FindGameObjectsWithTag("item").Length == 0)
            {
                timerIsRunning = false;
            }
        }

        foreach(TextMeshPro text in timerText)
        {
            text.text = timer.ToString("0.00");
        }
        
        if (timer < 0)
        {
            ResetPlayer();
        }
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(0);

        } if (keyboard.escapeKey.wasPressedThisFrame) {
            Application.Quit(0);
       
        }
    }
   
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(0);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("I have Escaped!");
            timerIsRunning = false;
        }
    }

    void ResetPlayer()
    {
        Debug.Log("Starting the reset Player method");
        //Reset the player
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;
        //Reset the timer
        timer = timerInterval;
        // Restart timer
        timerIsRunning = true;
    }    
}
