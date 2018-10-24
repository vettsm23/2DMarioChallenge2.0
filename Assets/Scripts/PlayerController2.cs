using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private bool facingRight = true;

    public float speed;
    public float jumpforce;

    AudioSource jump11;

    //ground check
    private bool isOnGround;
    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask allGround;

    // private float jumpTimeCounter;
    //public float jumpTime;
    //private bool isJumping;

    //audio stuff

    private AudioSource source;
    public AudioClip jumpClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Awake()
    {

        // source = GetComponent<AudioSource>();

    }

    private void Update()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        //Vector2 movement = new Vector2(moveHorizontal, 0);

        // rb2d.AddForce(movement * speed);

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);
   
        isOnGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, allGround);

        Debug.Log(isOnGround);


        //stuff I added to flip my character
        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))

            other.gameObject.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.tag == "Ground" && isOnGround)
        {


            if (Input.GetKey(KeyCode.UpArrow))
            {
                // rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpforce;

                // Audio stuff
                jump11 = GetComponent<AudioSource>();
                jump11.Play();

            }
        }
    }
}