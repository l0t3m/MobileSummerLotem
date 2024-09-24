using UnityEngine;

public enum SwipeDirection
{
    None, Left, Right
}

public class SwipeDetector : MonoBehaviour
{
    public static SwipeDirection DetectSwipe(Touch startT, Touch endT, float minDistance)
    {
        if (startT.position != endT.position)
        {
            float distance = Mathf.Abs(startT.position.x - endT.position.x);
            if (distance > minDistance)
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
        }
        return SwipeDirection.None;
    }
}
