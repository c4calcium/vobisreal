//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{

    private Transform securityCamera;
    //private EdgeCollider2D edge;
    private float turn;//, increment;
    public bool forward;
    //public float size;
    private int time1;
    private int rev;
    public LevelManager level;

    // Start is called before the first frame update
    void Start()
    {
        securityCamera = GetComponent<Transform>();

        turn = 0.1f;

        if (forward)
            rev = 1;
        else
            rev = -1;


    }

    // Update is called once per frame
    void Update()
    {

        if ((securityCamera.localRotation.z * 100) < -70 && rev == 1)
        { 
            forward = false;
          
        }
        else if ((securityCamera.localRotation.z * 100) > -10 && rev == 1)
        {
            forward = true;
        }
        if ((securityCamera.localRotation.z * 100) > 70 && rev == -1)
        { 
            forward = true;
        }
        else if ((securityCamera.localRotation.z * 100) < 10 && rev == -1)
        {
            forward = false;
        }
        {
            if (forward)   //when playing in the build, add / subtract 0.5. idk why it only works when you do that
                securityCamera.transform.Rotate(0, 0, -turn/*-0.5f*/);
            else
                securityCamera.transform.Rotate(0, 0, turn/*+0.5f*/);
                                         
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "vob")
            level.LoadLevel(SceneManager.GetActiveScene().name);
            //print("FOUND VOB");
    }


}
