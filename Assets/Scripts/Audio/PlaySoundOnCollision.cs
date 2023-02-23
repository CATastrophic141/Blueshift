using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{

    // This is the audio source
    public AudioSource tickSource;


    // Initialize our variable as the audio source
    void Start()
    {

        tickSource = GetComponent<AudioSource>();
    }

    // Called whenever a collision is detected
    void OnCollisionEnter(Collision collision)
    {

        // Adjust the volume depending on the velocity (velocity faster than 5 is capped)
        tickSource.volume = Mathf.Clamp01(collision.relativeVelocity.magnitude / 5);

        // Testing the speed value (decomment for debugging)
        //Debug.Log("Speed: " + tickSource.volume);

        // Play the sound!
        tickSource.Play();
    }
}
