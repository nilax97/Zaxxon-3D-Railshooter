using UnityEngine;
using System.Collections;
[System.Serializable]
public partial class Screenshot : MonoBehaviour{
	public KeyCode key;
	public string directory;
	public int superSize;
	public virtual void Update(){
		if(!Input.GetKeyDown(this.key)){
		return;
		}
		System.DateTime now = System.DateTime.Now;
		char zero = char.Parse("0");
		string nameString = (((((((this.directory + now.Year) + now.Month.ToString().PadLeft(2, zero)) + now.Day.ToString().PadLeft(2, zero)) + now.Hour.ToString().PadLeft(2, zero)) + now.Minute.ToString().PadLeft(2, zero)) + now.Second.ToString().PadLeft(2, zero)) + now.Millisecond.ToString().PadLeft(3, zero)) + ".png";
		MonoBehaviour.print(("Saving " + nameString) + "...");
		ScreenCapture.CaptureScreenshot(nameString, this.superSize);
	}
	public Screenshot(){
		this.directory = "Screenshots/";
	}
}