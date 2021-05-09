using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoData : MonoBehaviour
{
    private SerialPort stream = new SerialPort("COM34", 9600);
    private string value;
    public static float speed=1;
    public static float enemiesPerMinute = 60;
    public static float scale = 1;

    // Start is called before the first frame update
    void Start()
    {
        stream.Open();
    }

    void onApplicationQuit()
    {
        stream.Close();
    }

    // Update is called once per frame
    void Update()
    {
        value = stream.ReadLine();
        speed = 1 + float.Parse(value)/340;
        
        enemiesPerMinute = 60 + 60* (float.Parse(value) / 340);
        print(enemiesPerMinute);
    }
}
