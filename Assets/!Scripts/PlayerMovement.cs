using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float currentX = 0;

    private void Update()
    {
        
    }

    public void MoveRight()
    {
        currentX += 3.5f;
        UpdatePlayerMovement();
    }

    public void MoveLeft()
    {
        currentX -= 3.5f;
        UpdatePlayerMovement();
    }

    private void UpdatePlayerMovement()
    {
        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
    }
}
