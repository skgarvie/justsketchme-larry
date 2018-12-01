using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHighlighter : MonoBehaviour {

    private Material _material;

    private Color _selectedColor = Color.yellow;
    private Color _hoverColor = Color.blue;
    private Color _defaultColor = Color.green;

    private Vector3 _defaultScale;
    private float _hoverScale = 3;
    private float _selectedScale = 2;

    private bool _selected = false;
    // Use this for initialization

    public void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _defaultScale = transform.localScale;

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Select()
    {
        //_material.color = _selectedColor;
        //transform.localScale = _defaultScale * _selectedScale;
        _selected = true;
    }

    public void DeSelect()
    {
        _material.color = _defaultColor;
        transform.localScale = _defaultScale;
        _selected = false;
    }

    public void MouseOver()
    {
        //if (_selected) return;

        _material.color = _hoverColor;
        transform.localScale = _defaultScale * _hoverScale;


    }

    public void MouseExit()
    {
        //if (_selected) return;

        _material.color = _defaultColor;
        transform.localScale = _defaultScale;

    }
}
