using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocitySimulation : MonoBehaviour
{
    public bool state;
    public int stop_speed = 50;
    public GameObject Notification;
    public Text Text; 
    public GameObject MainCanvas;
    public GameObject FailCanvas;
    public Text TipsNumber;
    public static VelocitySimulation Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        state = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void Failed(){
        switch (Global.SceneNumber)
        {
            case 2 : 
                --CenterLineSimulation.Instance.easy_tips;
                TipsNumber.text = CenterLineSimulation.Instance.easy_tips.ToString();
                if(CenterLineSimulation.Instance.easy_tips <= 0){
                    Time.timeScale = 0.001f;
                    MainCanvas.SetActive(false);
                    FailCanvas.SetActive(true);
                }
                break;
            case 3 : 
                --CenterLineSimulation.Instance.hard_tips;
                TipsNumber.text = CenterLineSimulation.Instance.hard_tips.ToString();
                if(CenterLineSimulation.Instance.hard_tips <= 0){
                    Time.timeScale = 0.001f;
                    MainCanvas.SetActive(false);
                    FailCanvas.SetActive(true);
                }
                break;
            case 4 : 
                Time.timeScale = 0.001f;
                // if(other.tag == "Player"){
                    // Notification.SetActive(true);
                    // Text.GetComponent<UnityEngine.UI.Text>().text = "Don't cross the center line.";
                    MainCanvas.SetActive(false);
                    FailCanvas.SetActive(true);
                // }
                break;
        }
    }

    public void Notify(string str){
        Notification.SetActive(true);
        Text.GetComponent<UnityEngine.UI.Text>().text = str;
    }

    public void unNotify(){
        Notification.SetActive(false);
    }

    void OnTriggerEnter(Collider other){
        if(this.tag == "velocityPreLine" && other.tag == "Player"){
            VelocitySimulation.Instance.state = !VelocitySimulation.Instance.state;
        }

        if(this.tag == "VelocityPoint" && other.tag == "Player" && VelocitySimulation.Instance.state){
            // RCC_CarControllerV3.Instance.speed = other.GetComponent<Transform>().parent.parent.GetComponent<Rigidbody>().velocity.magnitude / 3.6f;
            if(RCC_CarControllerV3.Instance.speed > stop_speed){
                string words = "Don't go above the speed limit";
                Notify(words);
                Failed();
            }
        }
    }
    
    // void OnTriggerStay(Collider other){
        
    // }

    void OnTriggerExit(Collider other){
        if(this.tag == "VelocityPoint" && other.tag == "Player" && VelocitySimulation.Instance.state){
            unNotify();
            VelocitySimulation.Instance.state = !VelocitySimulation.Instance.state;
        }
    }
}
