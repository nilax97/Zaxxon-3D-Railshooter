using UnityEngine;
using System.Collections;
[System.Serializable]
public partial class DestroyOnContact : MonoBehaviour{
	public GameObject explosion;
	public string[] ignoreTags;
	public bool destroySelf;
	public bool detachChildren;
	public bool destroyOther;
	public virtual void OnCollisionEnter(Collision collision){
		foreach (string ignoreTag in this.ignoreTags){
		if(collision.gameObject.tag == ignoreTag){
			return;
		}
		}
		if(this.destroySelf){
		UnityEngine.Object.Destroy(this.gameObject);
		if(this.detachChildren){
			this.transform.DetachChildren();
		}
		}
		if(this.destroyOther){
		UnityEngine.Object.Destroy(collision.gameObject);
		}
		if(this.explosion != null){
		UnityEngine.Object.Instantiate(this.explosion, collision.contacts[0].point, Random.rotation);
		}
	}
	public DestroyOnContact(){
		this.destroySelf = true;
		this.detachChildren = true;
	}
}