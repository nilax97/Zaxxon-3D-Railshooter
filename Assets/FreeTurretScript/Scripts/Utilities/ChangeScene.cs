using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
[System.Serializable]
public partial class ChangeScene : MonoBehaviour{
	public KeyCode key;
	public string scene;
	public virtual void Update(){
		if(Input.GetKeyDown(this.key)){
		this.Execute();
		}
	}
	public virtual void Execute(){
		if(!string.IsNullOrEmpty(this.scene) && (this.scene != string.Empty)){
		this.Execute(this.scene);
		}
	}
	public virtual void Execute(string sceneName){
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	}
	public virtual void Execute(int sceneNumber){
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
	}
	public ChangeScene(){
		this.key = KeyCode.None;
	}
}