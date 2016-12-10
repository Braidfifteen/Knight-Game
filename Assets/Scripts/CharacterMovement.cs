using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float maxSpeed = 10f;
    private bool facingRight = true;
    private float move = 0;

    public Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!PlayerManager.SharedInstance.IsDead)
        {
            if (!GameManager.IsMobile)
            {
                move = Input.GetAxis("Horizontal");
            }

            if (move < 0 && facingRight)
            {
                facingRight = !facingRight;
                transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            }
            if (move > 0 && !facingRight)
            {
                facingRight = !facingRight;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            if (move != 0)
                anim.SetBool("isRunning", true);
            else
                anim.SetBool("isRunning", false);
        }
    }

    void FixedUpdate()
    {
        if (!PlayerManager.SharedInstance.IsDead)
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);//AddForce(new Vector2(move * maxSpeed, rb.velocity.y));
    }

    public void MobileMoveLeft()
    {
        move = -1;
    }

    public void MobileMoveRight()
    {
        move = 1;
    }

    public void MobileMoveStop()
    {
        move = 0;
    }
}
