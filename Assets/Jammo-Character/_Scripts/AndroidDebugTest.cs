using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidDebugTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("My app has started.");
        Debug.Log("Checking debug using UnityRemote5.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrintHi()
    {
        Debug.Log("HIIIIIIIII!");
    }
}
