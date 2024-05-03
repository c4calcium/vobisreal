using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonfordoor : MonoBehaviour
{
    private bool on, open;
    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        open = false;
    }


    // Update is called once per frame
    void Update() //button was at -5 x
    {
        if (on == true)
            StartCoroutine(isOpen());


        on = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "vob")
            on = true;
    }

    IEnumerator isOpen()
    {
        open = true;
        yield return new WaitForSeconds(3);
        open = false;
    }

    public bool getOpen()
    {
        return open;
    }



}