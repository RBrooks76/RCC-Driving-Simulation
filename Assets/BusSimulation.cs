using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BusSimulation : MonoBehaviour
{   
    public GameObject Notification;
    public Text Text;
    public GameObject Bus;
    private Vector3 SpawnPosition;
    public bool state = false;
    public bool direction = false;

    public GameObject MainCanvas;
    public GameObject FailCanvas;
    public Text TipsNumber;

    public static BusSimulation Instance;
    void Awake(){
        if(Instance == null){
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPosition = new Vector3(Bus.gameObject.transform.position.x, Bus.gameObject.transform.position.y, Bus.gameObject.transform.position.z);
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

    void OnTriggerEnter(Collider other){
        if(this.tag == "BusEndPoint" && other.tag =="bus"){
            other.gameObject.SetActive(false);
            other.transform.position = SpawnPosition;
            other.gameObject.SetActive(true);
        }

        if(this.tag == "PlayerBusStopPoint"){
            if(BusSimulation.Instance.state && BusSimulation.Instance.direction){
                other.GetComponent<Transform>().parent.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                Notification.SetActive(true);
                Text.GetComponent<UnityEngine.UI.Text>().text = "Stop and Give way";
                Failed();
            } else {
                other.GetComponent<Transform>().parent.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Notification.SetActive(false);
            }
        }

        if(this.tag == "BusPreLine" || this.tag == "BusPreLine1"){
            BusSimulation.Instance.direction = !BusSimulation.Instance.direction;
        }
    }

    void OnTriggerStay(Collider other){
        if(this.tag == "BusDetectionArea" && other.tag =="bus"){
            BusSimulation.Instance.state = true;
        }

        if(this.tag == "PlayerBusStopPoint"){
            if(BusSimulation.Instance.state && BusSimulation.Instance.direction){
                other.GetComponent<Transform>().parent.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                Notification.SetActive(true);
                Text.GetComponent<UnityEngine.UI.Text>().text = "Stop and Give way";
            } else {
                other.GetComponent<Transform>().parent.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Notification.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other){
        if(this.tag == "BusDetectionArea" && other.tag =="bus"){
            BusSimulation.Instance.state = false;
        }

        if(this.tag == "PlayerBusStopPoint"){
            BusSimulation.Instance.direction = !BusSimulation.Instance.direction;
        }
    }
}
