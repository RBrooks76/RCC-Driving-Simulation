using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterLineSimulation : MonoBehaviour
{
    public GameObject Notification;
    public Text Text;

    public GameObject MainCanvas;
    public GameObject FailCanvas;
    public Text TipsNumber;

    public int easy_tips = Global.easy;
    public int hard_tips = Global.hard;

    public static CenterLineSimulation Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
        }

       
    }

    // Start is called before the first frame update
    void Start()
    {
        CenterLineSimulation.Instance.easy_tips = Global.easy;
        CenterLineSimulation.Instance.hard_tips = Global.hard;
        
        if(Global.SceneNumber == 2){
            TipsNumber.text = Global.easy.ToString();
        } else if(Global.SceneNumber == 3){
            TipsNumber.text = Global.hard.ToString();
        }
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

    private void OnTriggerEnter(Collider other){
        // print(Global.SceneNumber);
        if(this.tag == "centerline" && other.tag == "Player") {
            Failed();
        }
    }

    private void OnTriggerStay(Collider other){
        if(other.tag == "Player"){
            Notification.SetActive(true);   
            Text.GetComponent<UnityEngine.UI.Text>().text = "Don't cross the center line.";
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            Notification.SetActive(false);
        }
    }
}
