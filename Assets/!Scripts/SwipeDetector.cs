using UnityEngine;

public enum SwipeDirection
{
    None, Left, Right, Up, Down
}

public class SwipeDetector : MonoBehaviour
{
    [SerializeField] static float minSwipeDistance = 200f;

    public static SwipeDirection DetectSwipe(Touch startT, Touch endT)
    {
        if (startT.position != endT.position)
        {
            
            float distanceX = Mathf.Abs(startT.position.x - endT.position.x);
            if (distanceX > minSwipeDistance)
            {
                if (startT.position.x < endT.position.x)
                {
                    return SwipeDirection.Right;
                }
                else
                {
                    return SwipeDirection.Left;
                }
            }

            float distanceY = Mathf.Abs(startT.position.y - endT.position.y);
            if (distanceY > minSwipeDistance)
            {
                if (startT.position.y < endT.position.y)
                {
                    return SwipeDirection.Up;
                }
                else
                {
                    return SwipeDirection.Down;
                }
            }
        }
        return SwipeDirection.None;
    }
}
