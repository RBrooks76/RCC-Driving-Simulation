using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrafficLight : MonoBehaviour
{
    public GameObject NotificationBG;
    public GameObject red;
    public GameObject yellow;
    public GameObject green;

    // public GameObject red2;
    // public GameObject yellow2;
    // public GameObject green2;
    public GameObject stopline;

    // public Global signalLight;
    public float loop_time = 6.0f;
    private float left_time = 6.0f;
    public int signalLight;
    public static TrafficLight Instance;
    void Awake(){
        if(Instance == null) {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        red.SetActive(false);
        yellow.SetActive(false);
        green.SetActive(false);

        // red2.SetActive(false);
        // yellow2.SetActive(false);
        // green2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        left_time -= Time.deltaTime ;

        if(left_time >= loop_time / 3 * 2){
            red.SetActive(true);
            yellow.SetActive(false);
            green.SetActive(false);

            // red2.SetActive(true);
            // yellow2.SetActive(false);
            // green2.SetActive(false);

            signalLight = 1;
        } else if(left_time < loop_time / 3 * 2 && left_time >= loop_time / 3){
            red.SetActive(false);
            yellow.SetActive(true);
            green.SetActive(false);

            // red2.SetActive(false);
            // yellow2.SetActive(true);
            // green2.SetActive(false);
            
            signalLight = 2;
        } else if(left_time < loop_time / 3 && left_time > 0){
            red.SetActive(false);
            yellow.SetActive(false);
            green.SetActive(true);

            // red2.SetActive(false);
            // yellow2.SetActive(false);
            // green2.SetActive(true);

            signalLight = 3;
        } else if( left_time < 0){
            left_time = loop_time;
        }
    }
}
