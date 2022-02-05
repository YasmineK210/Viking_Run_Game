using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]


public class playerScript : MonoBehaviour
{
    [SerializeField] float JumpingForce = 8f;
    [SerializeField] float movingSpeed = 5f;
    Animator animator;
    public Rigidbody rb;
    private bool turnLeft, turnRight;
    private bool onGround, canJump;
    bool isJumping;
    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isDead = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Viking_Sword") {
            movingSpeed = 0;
            JumpingForce = 0;
            isDead = true;
        }
        if (collision.gameObject.name == "Obstacle Variant") {
            movingSpeed--;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }

    void OnCollisionExit(Collision collision) 
    {
        onGround = false;
    }

    void Update()
    {
        if (transform.position.y <= -5f) {
            isDead = true;
        }
        if (isDead) {
            GameManager.inst.setGameOver();
            animator.SetBool("isDead", isDead);
        }
        isJumping = false;
        turnLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        turnRight = Input.GetKeyDown(KeyCode.RightArrow);
        canJump = Input.GetKeyDown(KeyCode.Space);

        if (turnLeft&&!isDead)
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        else if (turnRight&&!isDead)
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }
        else if (canJump && onGround&& !isDead) {
            rb.AddForce(JumpingForce * Vector3.up, ForceMode.Impulse);
            isJumping = true;
        }

        animator.SetBool("isJumping", isJumping);
    }

    private void FixedUpdate()
    {
        Vector3 moveForward = transform.forward * movingSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveForward);
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }
}
