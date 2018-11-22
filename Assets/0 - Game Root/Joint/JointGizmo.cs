using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointGizmo : InteractionGizmo
{

	public GameObject jointMarkerPrefab;
	public Vector3 offset = Vector3.zero;

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
				marker.transform.localPosition += offset;
        var collider = gameObject.AddComponent<SphereCollider>();
        collider.radius = 0.03f;
				collider.center += offset;
    }


}
