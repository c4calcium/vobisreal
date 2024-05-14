using UnityEngine;

public class ball : MonoBehaviour
{ //IGNORE THIS we didn't end up using it
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private CircleCollider2D ocollider;
    private Animator anim;
    private float lifetime;

    private void Awake()
    {
        ocollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hit) return;
        float movementspeed = speed * Time.deltaTime * direction;
        transform.Translate(movementspeed, 0, 0);

        lifetime += Time.deltaTime;
        if(lifetime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) // WHY DOESN'T THIS WORK
    {
        hit = true;
        ocollider.enabled = false;
        anim.SetTrigger("explode");
    }

    public void setdirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        ocollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    
    private void deactivate()
    {
        gameObject.SetActive(false);
    }
}
