using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficSignalSimulation : MonoBehaviour
{
    public GameObject Notification;
    public Text Text;
    private bool signal = false;

    public GameObject MainCanvas;
    public GameObject FailCanvas;
    public Text TipsNumber;

    // Start is called before the first frame update

    public static TrafficSignalSimulation Instance;

    void Awake(){
        if(Instance == null) {
            Instance = this;
        }
    }
    void Start()
    {
        
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

    void OnTriggerEnter (Collider other){
        if(this.tag == "signal_preline"){
            TrafficSignalSimulation.Instance.signal = true;
        }

        if(this.tag == "signal_line"){
            if(TrafficSignalSimulation.Instance.signal){
                if(TrafficLight.Instance.signalLight == 1 || TrafficLight.Instance.signalLight == 2){
                    other.GetComponent<Transform>().parent.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                    Notification.SetActive(true);
                    Text.GetComponent<UnityEngine.UI.Text>().text = "Take a look Traffic Signal";
                    Failed();
                } else {
                    other.GetComponent<Transform>().parent.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    Notification.SetActive(false);
                }
            }
        }
    }

    void OnTriggerStay(Collider other){
        if(this.tag == "signal_line"){
            if(TrafficSignalSimulation.Instance.signal){
                if(TrafficLight.Instance.signalLight == 1 || TrafficLight.Instance.signalLight == 2){
                    other.GetComponent<Transform>().parent.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                    Notification.SetActive(true);
                    Text.GetComponent<UnityEngine.UI.Text>().text = "Take a look Traffic Signal";
                } else {
                    other.GetComponent<Transform>().parent.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    Notification.SetActive(false);
                }
            }
        }
    }

    void OnTriggerExit(Collider other){
        if(this.gameObject.tag == "signal_line"){
            TrafficSignalSimulation.Instance.signal = false;
            other.GetComponent<Transform>().parent.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;    
        }
    }
}
