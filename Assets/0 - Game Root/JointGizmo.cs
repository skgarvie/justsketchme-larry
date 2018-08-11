using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointGizmo : MonoBehaviour {

	public GameObject jointMarkerPrefab;
	private GameObject jointMarker;

	void Awake () {
		jointMarker = Instantiate(jointMarkerPrefab, transform);
		var collider = gameObject.AddComponent<SphereCollider>();
		collider.radius = 0.03f;
		gameObject.layer = LayerMask.NameToLayer( "Joint" );
	}

	void Start () {

	}
	// Update is called once per frame
	void Update () {

	}
}
