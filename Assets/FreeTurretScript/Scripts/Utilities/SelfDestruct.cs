using UnityEngine;
using System.Collections;
[System.Serializable]
public partial class SelfDestruct : MonoBehaviour{
	public float delay;
	public GameObject explosion;
	public bool detachChildren;
	public virtual void Start(){
		this.Invoke("Die", this.delay);
	}
	public virtual void Die(){
		if(this.detachChildren){
		this.transform.DetachChildren();
		}
		if(this.explosion != null){
		UnityEngine.Object.Instantiate(this.explosion, this.transform.position, this.transform.rotation);
		}
		UnityEngine.Object.Destroy(this.gameObject);
	}
	public SelfDestruct(){
		this.delay = 1f;
		this.detachChildren = true;
	}
}