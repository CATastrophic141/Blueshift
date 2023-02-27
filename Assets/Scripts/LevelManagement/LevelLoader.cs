using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator; //Actively used animation for transition
    public float transitionTime = 1f; //Scene load delay

    public void LoadNextLevel()
    {
        //Retreives current scene index of build settings and adds 1
        //Coroutine required for transition delay
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); //Uses IEnumerator LoadLEvel function via coroutine
        Debug.Log("Loading scene index " + SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadCurrentLevel()
    {
        //Coroutine required for transition delay
        StartCoroutine(ReloadLevel()); //Uses IEnumerator LoadLEvel function via coroutine
        Debug.Log("Loading scene index " + SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("TransitionLevel"); //Sets animator trigger value to true, plays animation
        yield return new WaitForSeconds(transitionTime); //Delays transision so that the scene loading happens in the animation
        SceneManager.LoadScene(levelIndex); //Loads scene
    }

    IEnumerator ReloadLevel()
    {
        animator.SetTrigger("DeathReset"); //Sets animator trigger value to true, plays animation
        yield return new WaitForSeconds(transitionTime); //Delays transision so that the scene loading happens in the animation
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Loads scene
    }
}
