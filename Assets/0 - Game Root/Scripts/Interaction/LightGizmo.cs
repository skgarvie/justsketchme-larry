using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGizmo : InteractionGizmo
{
    public override void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Light");
        base.Awake();
    }

    void Start () {
		
	}
	
	void Update () {
		
	}


}
