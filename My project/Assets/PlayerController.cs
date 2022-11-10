using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SerialController Arduino;
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
    }
}
