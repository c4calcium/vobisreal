using UnityEngine;

public class playerattack : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] balls;
    private Animator anim;
    private playermovement playermovement;
    private float cooldowntimer = Mathf.Infinity;
    private bool doiwanttoattack = false; // change this to enable attacking

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playermovement = GetComponent<playermovement>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldowntimer > attackcooldown && playermovement.canattack() && doiwanttoattack == true)
            {
                attack();
            }

        cooldowntimer += Time.deltaTime;
    }

    private void attack()
        {
            anim.SetTrigger("attack");
            cooldowntimer = 0;

            balls[findballs()].transform.position = firepoint.position;
            balls[findballs()].GetComponent<ball>().setdirection(Mathf.Sign(transform.localScale.x));
        }

        private int findballs()
        {
            for (int i = 0; i < balls.Length; i++)
            {
                if (!balls[i].activeInHierarchy)
                    return i;
            }
            return 0;
        }
}
