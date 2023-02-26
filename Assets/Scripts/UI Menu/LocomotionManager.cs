using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionManager : MonoBehaviour
{
    public GameObject leftRayTeleport;
    public GameObject rightRayTeleport;

    private TeleportationProvider teleportationProvider;
    private ContinuousMoveProviderBase continuousMoveProvider;

    // Start is called before the first frame update
    void Start()
    {
        teleportationProvider = GetComponent<TeleportationProvider>();
        continuousMoveProvider =  GetComponent<ContinuousMoveProviderBase>();
    }

    // changes the locomotion type based on the player's chosen value
    public void SwitchLocomotion (int chosenValue) {
        // disables continuous and enables teleport if the player chooses the first one
        if(chosenValue == 0) {
            EnableContinuous();
            DisableTeleport();
        }

        // enable continuous and disables teleport if the player chooses the second one
        else if(chosenValue == 1) {
            EnableTeleport();
            DisableContinuous();
        }
    }

    // disables teleport
    private void DisableTeleport() {
        leftRayTeleport.SetActive(false);
        rightRayTeleport.SetActive(false);
        teleportationProvider.enabled = false;
    }

    // disables continuous
    private void DisableContinuous() {
        continuousMoveProvider.enabled = false;
    }

    // enable teleport
    private void EnableTeleport() {
        leftRayTeleport.SetActive(true);
        rightRayTeleport.SetActive(true);
        teleportationProvider.enabled = true;
    }

    // enables continuous
    private void EnableContinuous() {
        continuousMoveProvider.enabled = true;
    }
}
