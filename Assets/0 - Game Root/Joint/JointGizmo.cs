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
        marker = Instantiate(jointMarkerPrefab);
        marker.transform.parent = transform;
        //Setting the position after it has been spawned will allow it to retain it's scaling after parenting
        marker.transform.position = transform.position;
		marker.transform.localPosition += offset;
        var sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.radius = 0.03f;
        sphereCollider.center += offset;
    }


}
