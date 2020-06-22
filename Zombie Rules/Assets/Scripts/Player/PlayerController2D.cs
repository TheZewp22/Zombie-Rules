using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
Rigidbody2D rb2d;
Animator animator;
float hMovement = 0f;



[SerializeField]
float moveSpeed = 10f;
[SerializeField]
float jumpForce = 5f;
[SerializeField]
Transform groundCheck;
[SerializeField]
float checkRadius = 0.5f;
[SerializeField]
LayerMask whatIsGround;
bool isGrounded = true;
[SerializeField]
int extraJumpsValue = 2;
int extraJumps;



    // Start is called before the first frame update
    void Start()
    {
    extraJumps = extraJumpsValue;
    rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    if (Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround))
    {
    isGrounded = true;
    extraJumps = extraJumpsValue;
    } else {
    isGrounded = false;
    }
    

    hMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
    if (hMovement < 0)
    {
    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    } else {
    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    
    if (Input.GetKeyDown("space"))
    {
    Jump();
    }
    }
    void FixedUpdate()
    {
    rb2d.velocity = new Vector2(hMovement, rb2d.velocity.y);
    }

    void Jump()
    {
    
    if (extraJumps > 0)
    {
    if (isGrounded == true)
    {
    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    } else {
    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    extraJumps--;
    }

    }
    }
    }
