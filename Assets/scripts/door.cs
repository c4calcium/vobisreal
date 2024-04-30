using UnityEngine;

public class door : MonoBehaviour
{
   [SerializeField] private Transform previousroom;
   [SerializeField] private Transform nextroom;   
   [SerializeField] private cameracontroller cam;
   [SerializeField] private float zoomprevious;
   [SerializeField] private float zoomahead;

   private void OnTriggerEnter2D(Collider2D collision)
   {
    if (collision.tag == "Player")
    {
        if(collision.transform.position.x < transform.position.x)
            cam.movetonewroom(nextroom, zoomahead);
        else
            cam.movetonewroom(previousroom, zoomprevious);
    }
   }
}
 