using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentposx;
    private float size;
    private Vector3 velocity = Vector3.zero;
    private new Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        size = 6;
    }

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentposx, transform.position.y, transform.position.z), ref velocity, speed);
        if(camera.orthographicSize > (size + 0.05f))
        {
            camera.orthographicSize -= 0.01f;
        }
        else if(camera.orthographicSize < (size - 0.05f))
        {
            camera.orthographicSize += 0.01f;
        }
    }

    public void movetonewroom(Transform _newroom, float zoom)
    {
        currentposx = _newroom.position.x;
        size = zoom;
    }
}
