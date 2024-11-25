using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float verticalSpeed = 7.5f;

    [DoNotSerialize] public Animator animator;
    private Rigidbody rb;

    [DoNotSerialize] public bool CanMove = true;

    private float currentX = 0;
    private float currentY = 0;
    private int currentPosition = 0;



    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -35f, 0);
    }

    private void Update()
    {
        animator.SetFloat("VerticalVelocity", rb.velocity.y);
    }

    public IEnumerator MoveRight(float newX)
    {
        if (currentPosition != 1)
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
            currentPosition++;
        }
    }

    public IEnumerator MoveLeft(float newX)
    {
        if (currentPosition != -1)
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
            currentPosition--;
        }
    }

    public void MoveUp()
    {   
        animator.SetBool("IsGrounded", false);
        rb.AddForce(Vector3.up*verticalSpeed, ForceMode.Impulse);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0, 5), transform.position.z);
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
