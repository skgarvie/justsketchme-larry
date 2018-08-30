using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointGizmo : InteractionGizmo
{

	public GameObject jointMarkerPrefab;

	public override void Awake () {
        AddJointMarker();

        gameObject.layer = LayerMask.NameToLayer( "Joint" );
        base.Awake();
    }


	void Start () {

	}

	void Update () {

	}

    private void AddJointMarker()
    {
        marker = Instantiate(jointMarkerPrefab, transform);
        var collider = gameObject.AddComponent<SphereCollider>();
        collider.radius = 0.03f;
    }


}
