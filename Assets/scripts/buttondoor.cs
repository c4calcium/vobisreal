using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttondoor : MonoBehaviour
{
    private int count;
    private buttonfordoor temp;
    private bool close;
    public GameObject room;
    private BoxCollider2D box;
    private GameObject[] buttons;
    //private GameObject[] buttons2;
    private List<GameObject> buttons2 = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        close = true;
        box = GetComponent<BoxCollider2D>();
        count = 0;
        buttons = GameObject.FindGameObjectsWithTag("doorbutton");
        foreach (GameObject s in buttons)
        {
            print(s.transform.parent.gameObject + "   " + room);
            print(s.transform.parent.gameObject == room);
            if (s.transform.parent.gameObject == room)
            {
                print(s);
                if (s != null)
                    buttons2.Add(s);
                count++;
            }
        }


    }
    // Update is called once per frame
    void Update()
    {

        /**
         * HI CAL
         * 
         * 
         * ok so the issue is that it keeps setting the close to true even though it's supposed to register
         * as false because it should be checking the getOpen. so yeah
         * 
         * i commented out the test print statement but feel free to comment them back in to check stuff 
         * 
         * so yeah the first room works fine but after that it refuses to register as open
         * */
        close = true;
        foreach (GameObject h in buttons2)
        {
            //print("HELP");

            temp = h.GetComponent<buttonfordoor>();
           // print("Temp.getopen: " + temp.getOpen());
            if (temp.getOpen() == true)
                close = false;

        }

        if (close)
            box.isTrigger = false;
        else
            box.isTrigger = true;

      //  print("isTrigger: " + box.isTrigger);

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    // {
    //    if (collision.gameObject.name == "VOB" || )

    //  }
}
