using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class wall : MonoBehaviour
{
    public LevelManager level;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "vob")
        {
            level.LoadLevel(nextScene);
           // print("FOUND VOB");
        }
    }
}
