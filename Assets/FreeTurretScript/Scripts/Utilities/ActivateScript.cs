using UnityEngine;
using System.Collections;
[System.Serializable]
public partial class ActivateScript : MonoBehaviour{
	public Behaviour targetScript;
	public KeyCode key;
	public bool toggle;
	public bool deactivateOnStart;
	public virtual void Start(){
		if(this.deactivateOnStart){
		this.targetScript.enabled = false;
		}
		if((this.key == KeyCode.None) || (this.targetScript == null)){
		MonoBehaviour.print("Undefined variable for script activator. Disabling.");
		this.enabled = false;
		}
	}
	public virtual void Update(){
		if(Input.GetKeyDown(this.key) || (!this.toggle && Input.GetKeyUp(this.key))){
		this.targetScript.enabled = !this.targetScript.enabled;
		}
	}
	public ActivateScript(){
		this.deactivateOnStart = true;
	}
}