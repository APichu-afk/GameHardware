using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SerialController Arduino;
    public Text indicator;
    // Start is called before the first frame update
    void Start()
    {
        Arduino = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sending data
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Sending A");
            Arduino.SendSerialMessage("A");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Sending B");
            Arduino.SendSerialMessage("B");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Sending X");
            Arduino.SendSerialMessage("X");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Sending Y");
            Arduino.SendSerialMessage("Y");
        }
        //Reciving data
        string message = Arduino.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + message);

        if (message == "Red")
        {
            //change to red
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            indicator.text = "Red";
            indicator.color = Color.red;
        }

        if (message == "Green")
        {
            //change to blue
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            indicator.text = "Green";
            indicator.color = Color.green;
        }

        if (message == "Yellow")
        {
            //change to yellow
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            indicator.text = "Yellow";
            indicator.color = Color.yellow;
        }

        if (message == "Blue")
        {
            //change to blue
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            indicator.text = "Blue";
            indicator.color = Color.blue;
        }

        if (message == "COMMAND LEFT")
        {
            
            gameObject.transform.position += new Vector3(-10.0f, 0.0f, 0.0f) * Time.deltaTime;
        }

        if (message.Contains("COMMAND UP"))
        {
            
            gameObject.transform.position += new Vector3(0.0f, 0.0f, 10.0f) * Time.deltaTime;
        }
        
        if (message.Contains("COMMAND RIGHT"))
        {
            
            gameObject.transform.position += new Vector3(10.0f, 0.0f, 0.0f) * Time.deltaTime;
        }
        
        if (message.Contains("COMMAND DOWN"))
        {
            
            gameObject.transform.position += new Vector3(0.0f, 0.0f, -10.0f) * Time.deltaTime;
        }

        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Red" && gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.red)
        {
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "Yellow" && gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.yellow)
        {
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "Blue" && gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.blue)
        {
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "Green" && gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.green)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("You win");
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Red" && gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.red)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Yellow" && gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.yellow)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Blue" && gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.blue)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Green" && gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.green)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("You win");
        }
    }
}
