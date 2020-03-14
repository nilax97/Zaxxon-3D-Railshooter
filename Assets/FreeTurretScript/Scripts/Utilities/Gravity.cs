using UnityEngine;
using System.Collections;

[System.Serializable]
[UnityEngine.RequireComponent(typeof(Rigidbody))]

public partial class Gravity : MonoBehaviour{

	[Tooltip("Inverse gravity for niche applications such as \"white holes\"")]	public bool inverse = false;
	[Tooltip("Universal gravitational constant")]	public static float G = 1f;
	public static int precision;
	private float SOI;

	public virtual IEnumerator Start(){
		this.SOI = Mathf.Sqrt((G * this.GetComponent<Rigidbody>().mass) * Gravity.precision);
		MonoBehaviour.print((("SOI of " + this.name) + " is ") + this.SOI);
		Rigidbody[] children = this.gameObject.GetComponentsInChildren<Rigidbody>();
		yield return new WaitForFixedUpdate();
		yield return new WaitForFixedUpdate();
		foreach (Rigidbody child in children){
		if(child != this.GetComponent<Rigidbody>()){
			child.velocity = child.velocity + this.GetComponent<Rigidbody>().velocity;
		}
		}
	}

	public virtual void FixedUpdate(){
		foreach (Collider target in Physics.OverlapSphere(this.transform.position, this.SOI)){
		Debug.DrawLine(this.transform.position, target.transform.position, new Color(0.1f, 0.1f, 0.1f));
		if((target.attachedRigidbody == null) || (target.gameObject == this.gameObject) || target.transform.position == transform.position)
			continue;
		target.attachedRigidbody.AddForce((((inverse ? -1f : 1f) * G * this.GetComponent<Rigidbody>().mass) / (target.transform.position - this.transform.position).sqrMagnitude) * (this.transform.position - target.transform.position).normalized, ForceMode.Acceleration);
		}
	}

	public virtual void OnDrawGizmosSelected(){
		Gizmos.color = Color.gray;
		Gizmos.DrawWireSphere(this.transform.position, this.SOI);
	}

	public void SetG(float G){
		Gravity.G = G;
		print(Gravity.G);
	}

	static Gravity(){
		Gravity.precision = 1000;
	}
}