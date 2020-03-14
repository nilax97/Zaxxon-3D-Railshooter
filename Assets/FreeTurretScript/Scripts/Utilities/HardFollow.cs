using UnityEngine;
using System.Collections;
[System.Serializable]
[UnityEngine.AddComponentMenu("Camera-Control/Hard Follow")]
public partial class HardFollow : MonoBehaviour{
	public Transform target;
	[UnityEngine.Tooltip("Take exact position of target rather than maintain relative position.")]
	public bool sticky;
	private Vector3 lastPosition;
	public virtual void Start(){
		if(this.target == null){
		return;
		}
		this.lastPosition = this.target.position;
	}
	public virtual void LateUpdate(){
		if(this.target == null){
		return;
		}
		if(this.sticky){
		this.transform.position = this.target.position;
		return;
		}
		this.transform.position = this.transform.position + (this.target.position - this.lastPosition);
		this.lastPosition = this.target.position;
	}
	void Target (Transform target){
		this.target = target;
	}
}