using UnityEngine;

public class calbutton : MonoBehaviour
{
    [SerializeField] private int room;
    [SerializeField] private GameObject door;
    private static int room1bp, room2bp, room3bp, room4bp, room5bp; // bp means buttons pressed
    private SpriteRenderer sprite;
    private BoxCollider2D bcollider;
    private float timer3;
    private float timer4;

    void Awake()
    {
        
        sprite = GetComponent<SpriteRenderer>();
        bcollider = GetComponent<BoxCollider2D>();
        timer3 = 15;
        timer4 = 17;

        door.SetActive(true);

        room1bp = 0;
        room2bp = 0;
        room3bp = 0;
        room4bp = 0;

        room5bp = 0;

    }

    void Update()
    {
        if (room4bp == 0 && room == 4)
        {
                bcollider.enabled = true;
                sprite.color = new Color(1f, 1f, 1f, 1f);
        }

        if (room4bp > 0 && room4bp < 7)
        {
            if (timer4 <= 17)
                timer4 -= Time.deltaTime;
            if (room4bp == 7)
                timer4 = 100;
        }

        if (timer4 <= 0)
        {
            timer4 = 17;
            room4bp = 0;
        }


        if (room3bp == 0 && room == 3)
        {
                bcollider.enabled = true;
                sprite.color = new Color(1f, 1f, 1f, 1f);
        }

        if (room3bp == 1)
        {
                if(timer3 <= 3)
                    timer3 -= Time.deltaTime;
                if (room3bp == 2)
                    timer3 = 100;
        }

        if (timer3 <= 0)
            {
                timer3 = 15;
                room3bp = 0;
            }

        if (room5bp == 0 && room == 5)
        {
            bcollider.enabled = true;
            sprite.color = new Color(1f, 1f, 1f, 1f);
        }

        if (room5bp == 1)
        {
            if (timer3 <= 15)
                timer3 -= Time.deltaTime;
            if (room5bp == 2)
                timer3 = 100;
        }

        if (timer3 <= 0)
        {
            timer3 = 15;
            room5bp = 0;
        }

        if (room1bp == 1 && room == 1)
            opendoor();
        if (room2bp == 1 && room == 2)
            opendoor();
        if (room3bp == 2 && room == 3)
            opendoor();
        if (room4bp == 7 && room == 4)
            opendoor();
        if (room5bp == 2 && room == 5)
            opendoor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {            
            if (room == 1)
                room1bp++;
            else if (room == 2)
                room2bp++;
            else if (room == 3)
                room3bp++;
            else if (room == 4)
                room4bp++;
            else if (room == 5)
                room5bp++;
            /*else
                Debug.LogError("what room?");
            */
            bcollider.enabled = false;
            sprite.color = new Color(1f, 1f, 1f, 0f);

        }
    }

    private void opendoor()
    {
        if (door != null) // is door real?
        {
            door.SetActive(false);
        }/*
        else
        {
            Debug.LogError("door is not real!");
        }*/
    }
}