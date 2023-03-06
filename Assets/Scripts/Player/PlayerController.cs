using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Access the height child component
    public GameObject hidingOffset;
    private Vector3 shift = new Vector3(0, 1.3f, 0);

    // Lowers the player height when hiding in a box
    public void playerEnterBox() {

        hidingOffset.transform.position -= shift;
    }

    // Raises the player height when hiding in a box
    public void playerLeaveBox() {

        hidingOffset.transform.position += shift;
    }
}
