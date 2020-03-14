using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Gun : MonoBehaviour
{
    public Camera targeter;

    public GameObject bullet;

    public int weaponRange = 10;

    private RaycastHit hit;

    private Vector3 target;

    public virtual void Update(){
        if(Physics.Linecast(this.targeter.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.targeter.nearClipPlane)), this.targeter.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.weaponRange)), out this.hit))
            this.target = this.hit.point;
        else    this.target = this.targeter.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.weaponRange));
        this.transform.root.BroadcastMessage("Target", this.target);
        if(Input.GetButtonDown("Fire1"))    UnityEngine.Object.Instantiate(this.bullet, this.transform.position, this.transform.rotation);
    }

}