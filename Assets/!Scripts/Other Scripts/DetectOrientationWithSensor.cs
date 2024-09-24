using UnityEngine;

public class DetectOrientationWithSensor : MonoBehaviour
{
    void Update()
    {
        Vector3 acceleration = Input.acceleration;
        if (Mathf.Abs(acceleration.x) > Mathf.Abs(acceleration.y))
        {
            if (acceleration.x > 0)
            {
                Debug.Log("Landscape Left");
            }
            else
            {
                Debug.Log("Landscape Right");
            }
        }
        else
        {
            if (acceleration.y > 0)
            {
                Debug.Log("Portrait Upside Down");
            }
            else
            {
                Debug.Log("Portrait");
            }
        }
    }
}