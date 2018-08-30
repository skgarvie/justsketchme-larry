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

    private void OnMouseOver()
    {
        highlighter.MouseOver();
    }

    private void OnMouseExit()
    {
        highlighter.MouseExit();
    }
}
