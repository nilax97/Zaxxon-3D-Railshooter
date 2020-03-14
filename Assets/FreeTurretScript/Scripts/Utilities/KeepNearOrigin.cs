using UnityEngine;
using System.Collections;
 // x is biggest
 // z is biggest
 // y is biggest
 // z is biggest
public enum KeepNearOriginMode{
	Barrier = 0, // Prevent motion beyond max range as if by an invisible wall
	Sphere = 1, // Wrap around object positions as if on a 4D hypersphere
	Torus = 2, // Wrap around object positions as if on a 4D hypertorus
	Destroy = 3 // Destroy objects that move beyond max range
}
[System.Serializable]
public partial class KeepNearOrigin : MonoBehaviour{
	public int maxRange;
	public KeepNearOriginMode mode;
	public Vector3 originOverride;
	public bool useStartPosition;
	[UnityEngine.Range(0f, 0.5f)]
	public float fudge;
	private Vector3 startPosition;
	public virtual void Start(){
		if(this.useStartPosition){
		this.startPosition = this.transform.position;
		}
	}
	public virtual void Update(){
		Vector3 position = this.transform.position - this.originOverride;
		if(this.useStartPosition){
		position = position - this.startPosition;
		}
		if(position.sqrMagnitude > (this.maxRange * this.maxRange)){
		if(this.mode == KeepNearOriginMode.Barrier){
			position = Vector3.Lerp(position, Vector3.ClampMagnitude(position, this.maxRange), 0.5f);
		}
		if(this.mode == KeepNearOriginMode.Sphere){
			position = Vector3.ClampMagnitude(-position, this.maxRange);
		}
		if(this.mode == KeepNearOriginMode.Torus){
			float x = Mathf.Abs(position.x);
			float y = Mathf.Abs(position.y);
			float z = Mathf.Abs(position.z);
			if(x > y){
				if(x > z){
				position.x = -position.x;
				}else{
				position.z = -position.z;
				}
			}else{
				if(y > z){
				position.y = -position.y;
				}else{
				position.z = -position.z;
				}
			}
		}
		if(this.mode == KeepNearOriginMode.Destroy){
			UnityEngine.Object.Destroy(this.gameObject);
		}
		this.transform.position = (position * (1f - this.fudge)) + this.originOverride;
		}
	}
	public KeepNearOrigin(){
		this.maxRange = 1000;
		this.mode = KeepNearOriginMode.Barrier;
		this.originOverride = Vector3.zero;
		this.fudge = 0.01f;
	}
}