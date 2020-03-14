using UnityEngine;
using System.Collections;

public class Done_BGScroller1 : MonoBehaviour
{
	public float scrollSpeed;
	// public float tileSizeZ;
	private MeshRenderer mesh_renderer;
	// private Vector3 startPosition;

	void Start ()
	{
		scrollSpeed = 0.1f;
		// startPosition = transform.position;
		mesh_renderer = GetComponent<MeshRenderer>();
	}

	void Update ()
	{
		float x = -1*Time.time*scrollSpeed;
		Vector2 offset = new Vector2(x,0);
		mesh_renderer.sharedMaterial.SetTextureOffset("_MainTex",offset);
		// float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		// transform.position = startPosition + Vector3.forward * newPosition;
	}
}