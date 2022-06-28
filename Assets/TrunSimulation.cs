using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrunSimulation : MonoBehaviour
{
    public GameObject Notification;
    public Text Text;
    public GameObject IndicatorButtons;
    public string direction = "";
    public bool state;
    private bool state1;

    public GameObject MainCanvas;
    public GameObject FailCanvas;
    public Text TipsNumber;

    public static TrunSimulation Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        direction  = "";
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

    void OnTriggerEnter(Collider other){

        if(this.tag == "LeftPreLine"){
            TrunSimulation.Instance.direction = "LEFT";
            print(TrunSimulation.Instance.direction);
        }

        

        // if(this.name == "LeftTurnLine"){
        //     TrunSimulation.Instance.state = TrunSimulation.Instance.state;
        // }

        if(TrunSimulation.Instance.direction == "LEFT"){

            if(this.tag == "RightPreLine"){
                TrunSimulation.Instance.direction = "";
                print(TrunSimulation.Instance.direction);
            }

            if(this.tag == "LeftTurnLine"){
                IndicatorButtons.SetActive(true);
                Notification.SetActive(true);
                Text.GetComponent<UnityEngine.UI.Text>().text = "Use Indicators";
            }

            if(this.tag == "LeftEndLine"){
                IndicatorButtons.SetActive(false);
                Notification.SetActive(false);
                string str = "LEFT";
                Condition(str);
            }

            if(this.tag == "RightPreLine"){
                TrunSimulation.Instance.direction = "";
            }

            if(this.tag == "RightEndLine"){
                IndicatorButtons.SetActive(true);
                Notification.SetActive(true);
            }

            if(this.tag == "RightTurnLine"){
                IndicatorButtons.SetActive(false);
                Notification.SetActive(false);
                string str = "LEFT";
                Condition(str);
            }
        } else if(TrunSimulation.Instance.direction == "RIGHT"){

            if(this.tag == "LeftPreLine"){
                TrunSimulation.Instance.direction = "";
                print(TrunSimulation.Instance.direction);
            }

            if(this.tag == "RightTurnLine"){
                IndicatorButtons.SetActive(true);
                Notification.SetActive(true);
            }

            if(this.tag == "RightEndLine"){
                IndicatorButtons.SetActive(false);
                Notification.SetActive(false);
                string str = "RIGHT";
                Condition(str);
            }

            if(this.tag == "LeftPreLine"){
                TrunSimulation.Instance.direction = "";
            }

            if(this.tag == "LeftEndLine"){
                IndicatorButtons.SetActive(true);
                Notification.SetActive(true);
            }

            if(this.tag == "LeftTurnLine"){
                IndicatorButtons.SetActive(false);
                Notification.SetActive(false);
                string str = "RIGHT";
                Condition(str);
            }
        } else {
            if(this.tag == "LeftPreLine"){
                TrunSimulation.Instance.direction = "LEFT";
                print(TrunSimulation.Instance.direction);
            }
            
            if(this.tag == "RightPreLine"){
                TrunSimulation.Instance.direction = "RIGHT";
                print(TrunSimulation.Instance.direction);
            }
        }

        if(this.tag == ("LeftPreLine")){
            IndicatorButtons.SetActive(false);
            Notification.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other){
        
    }

    void OnTriggerExit(Collider other){
        if(this.name == "PreLine2"){
            // TrunSimulation.Instance.direction = !TrunSimulation.Instance.direction;
        }
    }

    public void LeftIndicator(){
        if(RCC_CarControllerV3.Instance.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Left){
            RCC_CarControllerV3.Instance.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Left;
        } else {
            RCC_CarControllerV3.Instance.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Off;
        }
    }

    public void RightIndicator(){
        if(RCC_CarControllerV3.Instance.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Right){
            RCC_CarControllerV3.Instance.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Right;
        } else {
            RCC_CarControllerV3.Instance.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Off;
        }
    }

    public void Condition(string str){
        if(str == "LEFT"){
            if(RCC_CarControllerV3.Instance.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Left){
                Failed();
            } else {
                RCC_CarControllerV3.Instance.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Off;
            }
        }else if(str == "RIGHT"){
            if(RCC_CarControllerV3.Instance.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Right){
                Failed();
            } else {
                RCC_CarControllerV3.Instance.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Off;
            }
        }
        
    }
}
