using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LockerManager : MonoBehaviour
{
    
    // "Borrow" the player
    public GameObject player;

    // Player's parameters to disable while hiding
    [SerializeField] GameObject leftRay;
    [SerializeField] GameObject rightRay;

    // Current hiding status
    private bool isPlayerHiding;

    // Hiding locations
    [SerializeField] GameObject enterObject;
    [SerializeField] GameObject exitObject;

    // Hiding positions
    private Vector3 enterPos;
    private Vector3 exitPos;
    private Vector3 rotation;

    // Trigger press action
    public InputActionReference actionReference = null;

    // Start is called before the first frame update
    void Start()
    {
        // Get hiding locations
        enterPos = enterObject.transform.position;
        exitPos = exitObject.transform.position;
        rotation = transform.eulerAngles;

        // Player is not hiding
        isPlayerHiding = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Player begins hiding
    public void enterHide() {

        // Adjust the position
        player.transform.position = enterPos;
        player.transform.eulerAngles = rotation;

        // Disable raycasts
        leftRay.SetActive(false);
        rightRay.SetActive(false);

        StartCoroutine(waitForTrigger());
    }

    // Triggers when trigger is pressed
    public void pressTrigger(InputAction.CallbackContext context)
    {
        if(isPlayerHiding) exitHide();
    }

    // Player leaves hiding
    public void exitHide() {

        // Leave the action reference
        actionReference.action.started -= pressTrigger;

        // Adjust the position
        player.transform.position = exitPos;

        // Enable raycasts
        leftRay.SetActive(true);
        rightRay.SetActive(true);

        // Player is no longer hiding
        isPlayerHiding = false;
    }

    // Player hides (coroutine introduced for delay)
    IEnumerator waitForTrigger() {

        // Wait for 1 second
        yield return new WaitForSeconds(1);

        // Wait for trigger
        actionReference.action.started += pressTrigger;

        // Player is now hiding
        isPlayerHiding = true;
    }
}
