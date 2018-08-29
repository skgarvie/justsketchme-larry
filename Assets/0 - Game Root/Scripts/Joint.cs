using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{

    private Material _jointMaterial;
    private Color _selectedColor = Color.yellow;
    private Color _hoverColor = Color.blue;
    private Color _defaultColor = Color.green;
    private Vector3 _defaultScale;
    private Vector3 _hoverScale;

    private Vector3 _selectedScale;

    private bool _selected = false;
    // Use this for initialization

    public void Awake()
    {
        _jointMaterial = GetComponent<Renderer>().material;
        _defaultScale = transform.localScale;
        _selectedScale = _defaultScale * 2;
        _hoverScale = _defaultScale * 3;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectJoint()
    {
        _jointMaterial.color = _selectedColor;
        transform.localScale = _selectedScale;
        _selected = true;
    }

    public void DeSelectJoint()
    {
        _jointMaterial.color = _defaultColor;
        transform.localScale = _defaultScale;
        _selected = false;
    }

    public void MouseOver()
    {
        if (_selected) return;

        _jointMaterial.color = _hoverColor;
        transform.localScale = _hoverScale;


    }

    public void MouseExit()
    {
        if (_selected) return;

        _jointMaterial.color = _defaultColor;
        transform.localScale = _defaultScale;

    }
}
