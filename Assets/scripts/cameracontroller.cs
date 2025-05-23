using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    public float currentposx;
    public float currentposy;
    public float size = 0f;
    private Vector3 velocity = Vector3.zero;
    private new Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        if (size == 0)
          size = 6;
    }

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentposx, currentposy, transform.position.z), ref velocity, speed);
        if(camera.orthographicSize > (size + 0.05f))
        {
            camera.orthographicSize -= 0.05f;
        }
        else if(camera.orthographicSize < (size - 0.05f))
        {
            camera.orthographicSize += 0.05f;
        }
    }

    public void movetonewroom(Transform _newroom, float zoom)
    {
        currentposx = _newroom.position.x;
        currentposy = _newroom.position.y;
        size = zoom;
    }
}
