using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Animator doorAnim;

    public void OnActivateDoor()
    {

        doorAnim.SetBool("isOpening", true);
    }

    public void OnDeactivateDoor()
    {

        doorAnim.SetBool("isOpening", false);
    }
}
