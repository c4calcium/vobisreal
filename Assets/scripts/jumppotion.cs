using UnityEngine;

public class jumppotion : MonoBehaviour {
 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "vob")
            power.setLevel("jump");
            gameObject.SetActive(false); // Hey.
        //power.setPowerChange(true);
    }
}