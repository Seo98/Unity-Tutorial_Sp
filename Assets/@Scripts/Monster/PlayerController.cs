using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject hitbox;

    [SerializeField] private float speed = 5f;
    private float h;
    private float v;

    private bool isAttack = false;

    void Update()
    {
        Move();
        Attack();
    }

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        


        if(h == 0 && v == 0)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            int scaleX = h > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            animator.SetBool("Run", true);
            var dir = new Vector3(h, v, 0).normalized;
            transform.position += dir * speed * Time.deltaTime;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        hitbox.SetActive(true);

        yield return new WaitForSeconds(0.25f);
        hitbox.SetActive(false);
        isAttack = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Iitem>() != null)
        {
            Iitem item = other.gameObject.GetComponent<Iitem>();
            item.Get();
        }
    }

}
