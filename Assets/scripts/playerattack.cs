using UnityEngine;

public class playerattack : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    private Animator anim;
    private playermovement playermovement;
    private float cooldowntimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playermovement = GetComponent<playermovement>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldowntimer > attackcooldown && playermovement.canattack())
            {
                attack();
            }

        cooldowntimer += Time.deltaTime;
    }

    private void attack()
        {
            anim.SetTrigger("attack");
            cooldowntimer = 0;
        }
}
