using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Access the height child component
    Transform cameraHeight;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
        // Attach camera height to child component
        cameraHeight = this.transform.Find("HidingOffset");
        position = cameraHeight.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Lowers the player height when hiding in a box
    public void playerEnterBox() {

        position.y -= 1;
    }

    // Raises the player height when hiding in a box
    public void playerLeaveBox() {

        position.y += 1;
    }
}
