using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 3f;
    private Rigidbody rb;
    public float rotationSpeed = 20f;
    private Animator animator;
    private bool hasChopped, hasCaught;

    // Start is called before the first frame update

    void Start()
    {
        hasCaught = false;
        hasChopped = false;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hasCaught == true)
        {
            rotationSpeed = 0;
            moveSpeed = 0;
            animator.SetBool("hasCaught", hasCaught);
            hasChopped = true;
        }
        if (hasChopped == true)
        {
            animator.SetBool("hasChopped", hasChopped);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "viking") {
            hasCaught = true;
        }
    }
}
