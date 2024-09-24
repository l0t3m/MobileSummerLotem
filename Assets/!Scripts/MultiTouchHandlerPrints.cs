using System;
using UnityEngine;

public class MultiTouchHandlerPrints : MonoBehaviour
{
    public PlayerMovement PlayerHorizontalMovement;
    private Touch startTouch;
    
    

    void Update()
    {
        int touchCount = Input.touchCount;

        if (touchCount < 1)
            return;
        
        for (int i = 0; i < touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouch = Input.GetTouch(0);
                    break;

                case TouchPhase.Ended:
                    SwipeDirection dir = SwipeDetector.DetectSwipe(startTouch, touch);

                    if (dir != SwipeDirection.None)
                    {
                        if (dir == SwipeDirection.Right && transform.position.x < 3.5f && PlayerHorizontalMovement.CanMove)
                            StartCoroutine(PlayerHorizontalMovement.MoveRight(transform.position.x + 3.5f));
                        else if (dir == SwipeDirection.Left && transform.position.x > -3.5f && PlayerHorizontalMovement.CanMove)
                            StartCoroutine(PlayerHorizontalMovement.MoveLeft(transform.position.x - 3.5f));
                        else if (dir == SwipeDirection.Up && PlayerHorizontalMovement.animator.GetBool("IsGrounded"))
                            PlayerHorizontalMovement.MoveUp();
                    }
                    break;
            }
        }
    }
}
