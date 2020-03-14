using UnityEngine;
using System.Collections;
[System.Serializable]
public partial class InitialVelocity : MonoBehaviour{
	public Vector3 startVelocity;
	public bool randomize;
	public bool localSpace;
	public virtual IEnumerator Start(){
		if(this.randomize){
		this.startVelocity = Random.rotation * this.startVelocity;
		}
		if(this.GetComponent<Rigidbody>() == null){
		yield break;
		}
		yield return new WaitForFixedUpdate();
		if(this.localSpace){
		this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity + this.transform.TransformDirection(this.startVelocity);
		}else{
		this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity + this.startVelocity;
		}
	}
}