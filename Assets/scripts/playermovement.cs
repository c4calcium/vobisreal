using Unity.VisualScripting;
using UnityEngine;

public class playermovement : MonoBehaviour
{
   [SerializeField] private float speed;
   [SerializeField] private float jumpamount;
   [SerializeField] private LayerMask groundlayer;
   [SerializeField] private LayerMask walllayer;
   private Rigidbody2D body;
   private Animator anim;
   private CapsuleCollider2D capsulecollider;
   private float walljumpcooldown;
   private float horizontalinput;

   private void Awake()
   {
      body = GetComponent<Rigidbody2D>(); 
      anim = GetComponent<Animator>(); 
      capsulecollider = GetComponent<CapsuleCollider2D>();
   }

   private void Update()
   {
      horizontalinput = Input.GetAxis("Horizontal");

      //flipping the lad
      if(horizontalinput > 0.01f)
         transform.localScale = Vector3.one;
      else if (horizontalinput < -0.01f)
         transform.localScale = new Vector3(-1, 1, 1);

      //animates the lad
      anim.SetBool("walk", horizontalinput != 0);
      anim.SetBool("grounded", isgrounded());

//wall jumping
      if(walljumpcooldown > 0.2f)
      {
         body.velocity = new Vector2(horizontalinput * speed,body.velocity.y);

         if (onwall() && !isgrounded())
         {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
         }
         else
            body.gravityScale = 8;

         if (Input.GetKey(KeyCode.Space))
            jump();

      }
      else
         walljumpcooldown += Time.deltaTime;

   }

   private void jump()
   {
      if(isgrounded())
      {
         body.velocity = new Vector2(body.velocity.x, jumpamount);
         anim.SetTrigger("jump");
      }
      else if(onwall() && !isgrounded())
      {
         if(horizontalinput == 0)
         {
            body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 8, 4);
            transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
         }
         else
            body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 4, 8);
         walljumpcooldown = 0;
      }
   }
   private bool isgrounded()
   {
      RaycastHit2D raycastHit = Physics2D.BoxCast(capsulecollider.bounds.center, capsulecollider.bounds.size, 0, Vector2.down, 0.1f, groundlayer);
      return raycastHit.collider != null;
   }

   private bool onwall()
   {
      RaycastHit2D raycastHit = Physics2D.BoxCast(capsulecollider.bounds.center, capsulecollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, walllayer);
      return raycastHit.collider != null;
   }

}
