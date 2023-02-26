using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public LevelLoader script;

    void OnTriggerEnter(Collider other)
    {
        script.LoadNextLevel();
    }
}

