using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    public float playerSpeed;
    [SerializeField]private float jumpForce = 14f;

    [SerializeField] private LayerMask jumpbleGround;
    private Animator anim;
    private SpriteRenderer sprite;

    private enum movementStates {idle, running, jump, fall }

    [SerializeField] private AudioSource jumpSoundEffect;
    //private movementStates state = movementStates.idle;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, rb.velocity.y);
        movementStates state;

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.x > 0f)
        {
            state = movementStates.running;
            //sprite.flipX = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (rb.velocity.x < 0f)
        {
            state = movementStates.running;
            //sprite.flipX = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            state = movementStates.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = movementStates.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementStates.fall;
        }

        anim.SetInteger("state", (int)state);

    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 1f, jumpbleGround);
    }
}
