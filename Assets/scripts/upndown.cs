//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class upndown : MonoBehaviour
{

    private Transform securityCamera;
    //private EdgeCollider2D edge;
    private float turn;
    public bool forward; //whether it starts off turning left or right, true = starts off rotating forward, or left, false is backward / right
    public float size = 0f; //you can change how much it moves
    private int rev; // rev = reverse
    public LevelManager level;

    // Start is called before the first frame update
    void Start()
    {
        securityCamera = GetComponent<Transform>();

        turn = 0.03f;

        if (forward)
            rev = 1;
        else
            rev = -1;


    }

    // Update is called once per frame
    void Update()
    {

        if ((securityCamera.localRotation.z * 100) < -30-size && rev == 1)
        { 
            forward = false;
          
        }
        else if ((securityCamera.localRotation.z * 100) > 30+size && rev == 1)
        {
            forward = true;
        }
        if ((securityCamera.localRotation.z * 100) > 30+size && rev == -1)
        { 
            forward = true;
        }
        else if ((securityCamera.localRotation.z * 100) < -30-size && rev == -1)
        {
            forward = false;
        }
        {
            if (forward)   //when playing in the build, add / subtract 0.5. idk why it only works when you do that
                securityCamera.transform.Rotate(0, 0, -turn-0.5f);
                //securityCamera.transform.Rotate(0, 0, -turn);
            else
                securityCamera.transform.Rotate(0, 0, turn + 0.5f);
              // securityCamera.transform.Rotate(0, 0, turn);
                                         
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "vob")
            level.LoadLevel(SceneManager.GetActiveScene().name);
    }


}
