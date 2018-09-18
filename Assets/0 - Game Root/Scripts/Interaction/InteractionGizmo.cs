using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGizmo : MonoBehaviour {

    [SerializeField] protected GameObject marker;
    public InteractionHighlighter highlighter;

    public virtual void Awake()
    {
        highlighter = marker.GetComponent<InteractionHighlighter>();
    }

    void Start () {
		
	}

    void Update () {
		
	}

    public void ToggleHighlighter(bool show)
    {
        highlighter.gameObject.SetActive(show);
    }

    private void OnMouseOver()
    {
        if (highlighter.gameObject.activeSelf)
            highlighter.MouseOver();
    }

    private void OnMouseExit()
    {
        if (highlighter.gameObject.activeSelf)
            highlighter.MouseExit();
    }
}
