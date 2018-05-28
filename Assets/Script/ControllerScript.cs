using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllerScript : MonoBehaviour
{

    Rigidbody2D Player;
    Animator anim;
    Vector2 die;

    bool facingRight = true;
    bool grounded = false;
    float move;
    bool doubleJump = false;
    bool duck;

    public float maxSpeed = 10f;
    public GameObject DieScreen;
    public GameObject PlayerModel;
    public AudioClip dieSound;
    float groundRadius = 0.2f;
    public Transform GroundCheck;
    public LayerMask whatIsGround;
    public Transform dieLine;
    public int dieLength;
    public float jumpForce = 700f;
    public int score = 0;

    public Text text;

    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        DieScreen.SetActive(false);
        die = new Vector2(-100, Player.position.y - dieLength);
        dieLine.position = new Vector2(Player.position.x, die.y);
    }

    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");
        Player = GetComponent<Rigidbody2D>();
        Player.velocity = new Vector2(move * maxSpeed, Player.velocity.y);
        dieLine.position = new Vector2(Player.position.x, die.y);


        grounded = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        if (grounded)
            doubleJump = false;

        anim.SetFloat("vSpeed", Player.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));


        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        duck = anim.GetBool("Duck");
        if (!duck && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            anim.SetBool("Duck", true);

        }

        if (duck && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {

            anim.SetBool("Duck", false);
        }

    }

    void Update()
    {
        if ((grounded || !doubleJump) && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)))
        {
            anim.SetBool("Ground", false);
            Player.AddForce(new Vector2(0, jumpForce));

            if (!grounded && !doubleJump)
                doubleJump = true;

        }
        
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "DieLine")
        {

            DieScreen.SetActive(true);
            GetComponent<AudioSource>().Play();
            Time.timeScale = 0;
            PlayerModel.gameObject.SetActive(false);
        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            collision.gameObject.SetActive(false);
            score += 1;
            string[] m = text.text.Split(':');
            m[1] = score.ToString();
            text.text = m[0] + ": " + m[1];
        }
    }
}



