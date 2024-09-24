using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float verticalSpeed = 5f;

    [DoNotSerialize] public Animator animator;
    private Rigidbody rb;

    [DoNotSerialize] public bool CanMove = true;

    private float currentX = 0;
    private float currentY = 0;



    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        animator.SetFloat("VerticalVelocity", rb.velocity.y);
    }

    public IEnumerator MoveRight(float newX)
    {
        float originalX = transform.position.x;
        float currentX = originalX;
        CanMove = false;
        while (currentX < newX)
        {
            currentX = Mathf.Clamp(currentX + horizontalSpeed * Time.deltaTime, originalX, newX);
            rb.MovePosition(new Vector3(currentX, transform.position.y, transform.position.z));
            yield return null;
        }
        CanMove = true;
    }

    public IEnumerator MoveLeft(float newX)
    {

        float originalX = transform.position.x;
        float currentX = originalX;
        CanMove = false;
        while (currentX > newX)
        {
            currentX = Mathf.Clamp(currentX - horizontalSpeed * Time.deltaTime, newX, originalX);
            rb.MovePosition(new Vector3(currentX, transform.position.y, transform.position.z));
            yield return null;
        }
        CanMove = true;
    }

    public void MoveUp()
    {   
        animator.SetBool("IsGrounded", false);
        rb.AddForce(Vector3.up*verticalSpeed, ForceMode.Impulse);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0, 30), transform.position.z);
        //if (IsInputValid(SwipeDirection.Up))
    }



    private bool IsInputValid(SwipeDirection swipeDir)
    {
        if (swipeDir == SwipeDirection.Left && currentX == -3.5f)
        {
            return false;
        } 
        else if (swipeDir == SwipeDirection.Right && currentX == 3.5f)
        {
            return false;
        }
        else if (swipeDir == SwipeDirection.Up && currentY != 0)
        {
            return false;
        }
        else if (swipeDir == SwipeDirection.Down && currentY == 0)
        {
            return false;
        }
        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("IsGrounded", true);
        }
    }
}
