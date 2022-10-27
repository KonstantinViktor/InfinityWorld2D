using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform checkGroundPoint;

    [SerializeField] private LayerMask graundLayer;

    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float radius;

    private bool facingRight;

    private float moveInput => Input.GetAxis("Horizontal");

    private bool CheckGround => Physics2D.OverlapCircle(checkGroundPoint.position, radius, graundLayer);

    private Rigidbody2D rd;
    private Animator anim;

    private float posX => speed * moveInput;

    private void Start()
    {
        facingRight = false;
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        rd.velocity = new Vector2(posX, rd.velocity.y);

        if (moveInput > 0 && facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && !facingRight)
        {
            Flip();
        }

        if (moveInput != 0) anim.SetBool("IsRun", true);
        else if (moveInput == 0) anim.SetBool("IsRun", false);
    }

    private void FixedUpdate()
    {
        if (CheckGround && Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("IsJump");
            rd.velocity = Vector2.up * jump * Time.deltaTime;
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, -0);
        facingRight = !facingRight;
    }
}