using UnityEngine;

public class jumppotion : MonoBehaviour {
 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "vob")
            power.setLevel("jump");
            Destroy(gameObject);
        //power.setPowerChange(true);
    }
}