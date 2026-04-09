using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator anim;
    public SpriteRenderer sr;

    Rigidbody2D rb;
    float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        // ✅ ใช้ Bool แทน
        bool isWalking = Mathf.Abs(moveInput) > 0.1f;
        anim.SetBool("IsWalking", isWalking);

        // 🔥 พลิกซ้ายขวา
        if (moveInput > 0)
        {
            sr.flipX = false;
        }
        else if (moveInput < 0)
        {
            sr.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
}