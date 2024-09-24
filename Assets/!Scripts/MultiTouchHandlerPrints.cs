using UnityEngine;

public class MultiTouchHandlerPrints : MonoBehaviour
{
    public PlayerHorizontalMovement PlayerHorizontalMovement;
    private Touch startTouch;
    private float minSwipeDistance = 500f;

    void Update()
    {
        int touchCount = Input.touchCount;

        if (touchCount < 1)
            return;
        
        for (int i = 0; i < touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            //Debug.Log("Touch " + i + " - Position: " + touch.position + " Phase: " + touch.phase);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouch = Input.GetTouch(0);
                    break;

                case TouchPhase.Ended:
                    SwipeDirection dir = SwipeDetector.DetectSwipe(startTouch, touch, minSwipeDistance);

                    if (dir != SwipeDirection.None)
                    {
                        if (dir == SwipeDirection.Right)
                            PlayerHorizontalMovement.MoveRight();
                        else
                            PlayerHorizontalMovement.MoveLeft();
                    }
                    break;
            }
        }
    }
}
