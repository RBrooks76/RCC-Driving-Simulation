// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UIElements;

// [AddComponentMenu("BoneCracker Games/Realistic Car Controller/UI/Mobile/Button")]
// public class keyController : MonoBehaviour
// {
//     #region RCC Settings Instance

// 	private RCC_Settings RCCSettingsInstance;
// 	private RCC_Settings RCCSettings {
// 		get {
// 			if (RCCSettingsInstance == null) {
// 				RCCSettingsInstance = RCC_Settings.Instance;
// 			}
// 			return RCCSettingsInstance;
// 		}
// 	}

// 	#endregion

// 	internal float input;
// 	private float sensitivity{get{return RCCSettings.UIButtonSensitivity;}}
// 	private float gravity{get{return RCCSettings.UIButtonGravity;}}
// 	public bool pressing;

// 	void Update(){
		
// 		if(pressing || Global.pressed_W)
// 			input += Time.deltaTime * sensitivity;
// 		else
// 			input -= Time.deltaTime * gravity;
		
// 		if(input < 0f)
// 			input = 0f;
		
// 		if(input > 1f)
// 			input = 1f;
		
// 	}

// 	void OnDisable(){

// 		input = 0f;
// 		pressing = false;

// 	}

//     void FixedUpdate()
//     {
//         if(Input.GetKeyDown(KeyCode.W)){
//             Debug.Log("shows____");
//             Global.pressed_W = true;
//             pressing = true;
//         }
//         if(Input.GetKeyDown(KeyCode.S)){
//             Global.pressed_S = true;
//         }if(Input.GetKeyDown(KeyCode.A)){
//             Global.pressed_A = true;
//         }if(Input.GetKeyDown(KeyCode.D)){
//             Global.pressed_D = true;
//         }


//         if(Input.GetKeyUp(KeyCode.W)){
//             Global.pressed_W = false;
//             input = 0f;
// 		    pressing = false;
//         }
//         if(Input.GetKeyUp(KeyCode.S)){
//             Global.pressed_S = false;
//         }if(Input.GetKeyUp(KeyCode.A)){
//             Global.pressed_A = false;
//         }if(Input.GetKeyUp(KeyCode.D)){
//             Global.pressed_D = false;
//         }


//     }

	

// }
