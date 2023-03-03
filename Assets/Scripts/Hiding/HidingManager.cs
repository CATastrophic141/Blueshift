using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HidingManager : MonoBehaviour
{

    // Create a copy of the AI script
    public UnityEvent hide;
    public UnityEvent leaveHide;

    // Debugging
    /*
    private int tick = 0;
    void Update()
    {
        tick++;
    }
    */

    // Player hides
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Enter");
        hide.Invoke();
    }

    // Player leaves hiding location
    void OnTriggerExit(Collider col)
    {
        Debug.Log("Exit");
        leaveHide.Invoke();
    }
}
