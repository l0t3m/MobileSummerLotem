using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour
{
    private float currentX = 0;

    public void MoveRight()
    {
        if (IsInputValid(SwipeDirection.Right, currentX))
        {
            currentX += 3.5f;
            UpdatePlayerX();
        }
    }

    public void MoveLeft()
    {
        if (IsInputValid(SwipeDirection.Left, currentX))
        {
            currentX -= 3.5f;
            UpdatePlayerX();
        }
    }

    private void UpdatePlayerX()
    {
        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
    }

    private bool IsInputValid(SwipeDirection swipeDir, float currentX)
    {
        if (swipeDir == SwipeDirection.Left && currentX == -3.5f)
        {
            return false;
        } 
        else if (swipeDir == SwipeDirection.Right && currentX == 3.5f)
        {
            return false;
        }
        return true;
    }
}
