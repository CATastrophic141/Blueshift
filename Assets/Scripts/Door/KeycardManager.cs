using UnityEngine;
using UnityEngine.Events;

public class KeycardManager : MonoBehaviour
{

    public UnityEvent onPuzzleCompletion;
    public UnityEvent onPuzzleFail;

    public void AttachKeycard()
    {

        onPuzzleCompletion.Invoke();
    }

    public void DetachKeycard()
    {

        onPuzzleFail.Invoke();
    }
}
