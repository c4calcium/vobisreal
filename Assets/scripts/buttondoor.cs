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
    void Start()
    {
        close = true;
        box = GetComponent<BoxCollider2D>();
        count = 0;
        buttons = GameObject.FindGameObjectsWithTag("doorbutton");
        foreach (GameObject s in buttons)
        {
            //print(s.transform.parent.gameObject + "   " + room);
           // print(s.transform.parent.gameObject == room);
            if (s.transform.parent.gameObject == room)
            {
                //print(s);
                if (s != null)
                    buttons2.Add(s);
                count++;
            }
        }
    }
    void Update()
    {

       
        close = true;
        foreach (GameObject h in buttons2)
        {

            temp = h.GetComponent<buttonfordoor>();
           // print("Temp.getopen: " + temp.getOpen());
            if (temp.getOpen() == true)
                close = false;

        }

        if (close)
            box.isTrigger = false;
        else
            box.isTrigger = true;

    }
}
