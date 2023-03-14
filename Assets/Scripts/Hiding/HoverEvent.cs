using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEvent : MonoBehaviour
{
    // Reference itself
    public GameObject self;

    // Selection outline
    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        outline = self.AddComponent<Outline>();
        outline.OutlineColor = new Color(61f/255f,210f/255f,244f/255f);
        outline.OutlineWidth = 14f;
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Text goes here
    }

    // Make the locker "selected" when hovered over
    public void onHover() {

        outline.enabled = true;
    }

    // Make the locker return to normal when hover leaves'
    public void onExitHover() {

        outline.enabled = false;
    }
}
