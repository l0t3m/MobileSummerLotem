using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSelf : MonoBehaviour
{
    public bool rotateRight = true;
    private float side;
    // Start is called before the first frame update
    void Start()
    {
        side = rotateRight ? 50f : -50f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, side * Time.deltaTime);
    }
}
