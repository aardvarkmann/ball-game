using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    // controls speed and jump height
    public float speed;
    public float jump;

    public Text countText;
    public Text winText;
    // declares rigidbody on player
    private Rigidbody rb;
    private int count;



    // Use this for initialization
    void Start()
    {
        // assign variable to player rigidbody
        rb = GetComponent<Rigidbody>();
        // set beggining count of counts to 0
        count = 0;
        //run function to display ui
        SetCountText();
    }

    //updates with physics
    void FixedUpdate()
    {

        //local variable equal to horiozontal and vertical inputs on arrow keys and awsd
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");




        //assign values to movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);



        // add force by using the movement vector and multiplying it by public speed
        rb.AddForce(movement * speed);
             

    }

    // Uncheck active everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {

        //if the game object has the tag pick up,
        // set all other gameobjects to not active
        // add +1 to count
        // call function setcount
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
           count = count + 1;
           SetCountText();
        }
    }


    //runs once per frame 
    void Update()
    {
        // move ball upwards whenever space is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jump);


        }

    }


    //function that keeps track of count
    void SetCountText()
    {
        // update text field of count variable
        //check if count is more or equal to 12
        //if it is change winText to You Win!
        countText.text = "Count: " + count.ToString();
        if (count >= 3)
        {
            winText.text = "You Win!";
        }
    }

}

