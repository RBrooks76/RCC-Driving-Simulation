using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIBusMovement : MonoBehaviour
{
    public float speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(10.5f, 27f, -81f);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.tag == "bus"){
            this.transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }

    

    // void OnCollisionEnter(Collision collision){
    //     if(collision.gameObject.tag == "busEndPoint"){
    //         Destroy(this);
    //     }
    // }
}
