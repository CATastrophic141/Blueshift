using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathReset : MonoBehaviour
{
    public LevelLoader script;

    void OnTriggerEnter(Collider other)
    {
        script.ReloadCurrentLevel();
    }
}
