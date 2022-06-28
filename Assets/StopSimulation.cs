using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StopSimulation : MonoBehaviour
{
    public GameObject Notification;
    public Text Text;

    public GameObject MainCanvas;
    public GameObject FailCanvas;
    public Text TipsNumber;

    // Start is called before the first frame update
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

    void OnCollisionEnter(Collision collision){
        Notification.SetActive(true);
        Text.GetComponent<UnityEngine.UI.Text>().text = "Stop Completely";
        Failed();
    }

    void OnCollisionExit(Collision collision){
        if(this.tag == "PlayerStopPoint"){
            Notification.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other){
        if(this.tag == "PlayerStopPoint" && other.tag == "Player"){
            Notification.SetActive(false);
        }
    }
}
