using UnityEngine;

public class power : MonoBehaviour
{
    //public static bool powerChange = false;
    public static string level = "none";


    void Start()
    {
        //level = "none";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static string getLevel()
    {
        return level;
    }
    public static void setLevel(string lev)
    {
        level = lev;
    }
}