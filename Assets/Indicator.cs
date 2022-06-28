using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LeftIndicator(){
        Debug.Log("Left Indicator");
        if(RCC_CarControllerV3.Instance.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Left){
            RCC_CarControllerV3.Instance.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Left;
        } else {
            RCC_CarControllerV3.Instance.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Off;
        }
    }

    public void RightIndicator(){
        Debug.Log("Right Indicator");
        if(RCC_CarControllerV3.Instance.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Right){
            RCC_CarControllerV3.Instance.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Right;
        } else {
            RCC_CarControllerV3.Instance.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Off;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
