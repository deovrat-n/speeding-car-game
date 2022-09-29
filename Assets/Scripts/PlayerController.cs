using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{   //private variables
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float turnSpeed=25.0f;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
  
    

    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   // here we get the input 
        
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Move the vehicle forward
        // transform.Translate(Vector3.forward * Time.deltaTime*speed*forwardInput);
        //if (check == 1) 
       // {
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            //rotate the car
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
            speedometerText.text = "Speed:" + speed + "kph";
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.text = "rpm:" + rpm;
       // }
    }

   void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "ground")
        {
            Debug.Log("object on ground");
            //check = 1;
        }
        else
        {
            Debug.Log("object not on ground");
           // check = 0;
        }
       
    }
    
}
