using UnityEngine;

public class pause : MonoBehaviour
{
    private bool paused;
    [SerializeField] private GameObject pausemenu;
    private float waiting;

    void Awake()
    {
        paused = false;
        waiting = 0;
    }


    void Update()
    {
        if (waiting > 0)
            waiting -= Time.deltaTime;

        if ((Input.GetKey("escape") || Input.GetKey(KeyCode.E)) && !Input.GetKey("space"))
        {
            if (paused == false && waiting <= 0)
                {
                    paused = true;
                    pausemenu.SetActive(true);
                    waiting = 0.5f;
                    Time.timeScale = 0;
                }
            if (paused == true && waiting <= 0)
                {
                    paused = false;
                    pausemenu.SetActive(false);
                    waiting = 0.5f;
                }
        }

    
    }
    
    public void quitgame()
    {
        Application.Quit();
    }

    public void resumegame()
    {
        paused = false;
        pausemenu.SetActive(false);
        waiting = 0.5f;
        Time.timeScale = 1;
    }
}
