using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private CircleCollider2D ocollider;
    private Animator anim;

    private void Awake()
    {
        ocollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hit) return;
        float movementspeed = speed * Time.deltaTime;
        transform.Translate(movementspeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        //8:11
    }
}
