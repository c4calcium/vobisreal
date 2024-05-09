//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{

    private Transform securityCamera;
    //private EdgeCollider2D edge;
    public float turn;//, increment;
    public bool forward;
    //public float size;
    private int time1;
    private int rev;
    public LevelManager level;

    // Start is called before the first frame update
    void Start()
    {
        securityCamera = GetComponent<Transform>();
       // edge = GetComponent<EdgeCollider2D>();
        
       // time1 = 0;
        turn = 0.03f;

        if (forward)
            rev = 1;
        else
            rev = -1;


        //increment = /*securityCamera.transform.localScale.y*/ size / 30000.0f;

    }

    // Update is called once per frame
    void Update()
    {

        // Vector3 point = new Vector3(-16.3f, 13.7f, -2);
        //Vector3 axis = new Vector3(0, 1, 0);
        //securityCamera.transform.RotateAround(point, axis, 20 * Time.deltaTime);

        if ((securityCamera.localRotation.z * 100) < -70 && rev == 1)
        { //(forward)
            forward = false;
           // print("BAKCWARD 1");
        }
        //increment/*0.0005f*/;
        else if ((securityCamera.localRotation.z * 100) > -10 && rev == 1)
        {
            forward = true;// increment/*0.0005f*/;
         //   print("FORWARD 1");
        }
        if ((securityCamera.localRotation.z * 100) > 70 && rev == -1)
        { //(forward)
            forward = true;
         //   print("BAKCWARD 2");
        }
        //increment/*0.0005f*/;
        else if ((securityCamera.localRotation.z * 100) < 10 && rev == -1)
        {
            forward = false;// increment/*0.0005f*/;
          //  print("FORWARD2 ");
        }

        /*if ((securityCamera.localRotation.z * 100) > 80 && rev == -1)
        { //(forward)
            forward = false;
            print("BAKCWARD 2");
        }
        ;
        else if ((securityCamera.localRotation.z * 100) < 0 && rev == -1)
        {
            forward = true;8;
            print("FORWARD 2");
        }*/

        //if (rev == 1)
        {
            if (forward)
                securityCamera.transform.Rotate(0, 0, -turn);//increment/*0.0005f*/;
            else
                securityCamera.transform.Rotate(0, 0, turn);// increment/*0.0005f*/;
                                                            //   if (time1 == 10)
        }
        
      //  if (rev == -1)
      //  {
        //    if (forward)
             //   securityCamera.transform.Rotate(0, 0, turn);//increment/*0.0005f*/;
          //  else
            //    securityCamera.transform.Rotate(0, 0, -turn);// increment/*0.0005f*/;
                                                            //   if (time1 == 10)
       // }
        // securityCamera.transform.Rotate(0, 0, turn);

        //  if (turn < -0.7f)
        //       forward = true;
        //     if (turn > 0.7f)
        //  forward = false;

        //  time1 ++;
        //  if (time1 == 11)
        //      time1 = 0;
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
            level.LoadLevel(SceneManager.GetActiveScene().name);
            //print("FOUND VOB");
    }


}
