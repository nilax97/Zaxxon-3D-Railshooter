using UnityEngine;
using System.Collections;
[System.Serializable]
public partial class Rotate : MonoBehaviour{
	[UnityEngine.Tooltip("Euler rotation to apply in degrees per second.")]
	public Vector3 rotation;
	[UnityEngine.Tooltip("Rotate in local space rather than world space.")]
	public bool local;
	public bool randomize;
	public virtual void Start(){
		if(this.randomize){
		this.rotation = Random.rotation * this.rotation;
		}
	}
	public virtual void Update(){
		this.transform.Rotate(this.rotation * Time.deltaTime, this.local ? Space.Self : Space.World);
	}
	public Rotate(){
		this.rotation = Vector3.zero;
	}
}