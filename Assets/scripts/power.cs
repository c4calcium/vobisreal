using UnityEngine;

public class power : MonoBehaviour
{
    //public static bool powerChange = false;
    public static string level;


    // Start is called before the first frame update
    void Start()
    {
        level = "none";
    }

    // Update is called once per frame
    void Update()
    {
        //if (powerChange == true)
          //  print("POWERCHANGE");
    }

    public static string getLevel()
    {
        return level;
    }
    /*
    public bool getPowerChange()
    {
        return powerChange;
    }
    */
    public static void setLevel(string lev)
    {
        level = lev;
    }
}