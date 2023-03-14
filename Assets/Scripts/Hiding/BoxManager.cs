using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class BoxManager : MonoBehaviour
{
    // "Borrow" the player
    public GameObject player;

    // Player's parameters to disable while hiding
    [SerializeField] GameObject leftRay;
    [SerializeField] GameObject rightRay;
    [SerializeField] GameObject height;

    // Current hiding status
    private bool isPlayerHiding;

    // Hiding locations
    [SerializeField] GameObject enterObject;
    [SerializeField] GameObject exitObject;

    // Hiding positions
    private Vector3 enterPos;
    private Vector3 exitPos;
    private Vector3 rotation;

    // Call scripts for monster hiding
    public UnityEvent playerEnterHide;
    public UnityEvent playerExitHide;

    // Trigger press action
    public InputActionReference actionReference = null;

    // Lower the player's position in box
    private Vector3 shift = new Vector3(0, 1.1f, 0);

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

        // Lower the camera
        height.transform.position -= shift;

        // Disable raycasts
        leftRay.SetActive(false);
        rightRay.SetActive(false);

        // Call event
        playerEnterHide.Invoke();

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

        // Fix the height
        height.transform.position += shift;

        // Call event
        playerExitHide.Invoke();

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
