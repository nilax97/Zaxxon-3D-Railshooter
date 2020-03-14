using UnityEngine;
using System.Collections;
[System.Serializable]
public partial class InitialAngularVelocity : MonoBehaviour{
	public Vector3 startVelocity;
	public bool randomize;
	public virtual IEnumerator Start(){
		if(this.randomize){
		this.startVelocity = Random.rotation * this.startVelocity;
		}
		if(this.GetComponent<Rigidbody>() == null){
		yield break;
		}
		yield return new WaitForFixedUpdate();
		this.GetComponent<Rigidbody>().angularVelocity = this.GetComponent<Rigidbody>().angularVelocity + this.startVelocity;
	}
}