//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Transform securityCamera;
    //private EdgeCollider2D edge;
    private float turn;//, increment;
    private bool forward;
    //public float size;
    private int time1;
    // Start is called before the first frame update
    void Start()
    {
        securityCamera = GetComponent<Transform>();
       // edge = GetComponent<EdgeCollider2D>();
        
        forward = true;
        time1 = 0;
        //increment = /*securityCamera.transform.localScale.y*/ size / 30000.0f;
        turn = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {

        // Vector3 point = new Vector3(-16.3f, 13.7f, -2);
        //Vector3 axis = new Vector3(0, 1, 0);
        //securityCamera.transform.RotateAround(point, axis, 20 * Time.deltaTime);


        if (forward)
            turn += 0.0005f;//increment/*0.0005f*/;
        else
            turn -= 0.0005f;// increment/*0.0005f*/;
        if (time1 == 10)
            securityCamera.transform.Rotate(0, 0, turn);

        if (turn < -0.7f)
            forward = true;
        if (turn > 0.7f)
            forward = false;

        time1 ++;
        if (time1 == 11)
            time1 = 0;
        //(600 * increment)
        /*Time.deltaTime * 10
        print(securityCamera.position.z);
        if (securityCamera.position.z <= -50/* && (securityCamera.transform.position.z>0 || securityCamera.transform.position.z < -1)){ 
            print(securityCamera.position.z);
            forward = true;
         }
        if (securityCamera.position.z >= 16/* && (securityCamera.transform.position.z>0 || securityCamera.transform.position.z< -1)/)
        {
            print(securityCamera.position.z);
            forward = false;
        }
        print(forward);*/


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "vob")
            print("FOUND VOB");
    }


}
