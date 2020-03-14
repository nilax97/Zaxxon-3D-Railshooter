using UnityEngine;
using System.Collections;
[System.Serializable]
[UnityEngine.RequireComponent(typeof(Rigidbody))]
[UnityEngine.RequireComponent(typeof(Collider))]
public partial class RigidbodyCharacterController : MonoBehaviour{
	public float walkSpeed = 3f;
	public float runSpeed = 10f;
	public float jumpHeight = 2f;
	public float strength = 10f;
	public KeyCode walkOrRunKey = KeyCode.LeftShift;
	public bool normallyRunning = true;
	public float maxSlope = 45f;
	public bool canGlide = false;
	[UnityEngine.Tooltip("Automatically orient character against curved terrains.")]
	public bool autoOrient = false;
	[UnityEngine.Tooltip("Character's local up direction, for curved terrains.")]
	public Vector3 localUp = Vector3.up;
	[Tooltip("Character's gravitational acceleration;\noverrides Physics.gravity.")]
	public float gravityOverride = 0f;
	[Tooltip("Use collision normal instead of relative position for ground detection.")]
	public bool useNormal = false;
	private float speed;
	private Vector3 thrust;
	private Vector3 targetVelocity;
	private bool flying = true;
	private Quaternion frameRotation = Quaternion.identity;
	private Vector3 oldVelocity;
	private Rigidbody attachedRigidbody;

	public virtual void OnCollisionStay(Collision collision){
		Debug.DrawLine(transform.position, collision.contacts[0].point, Color.magenta);
		Vector3 collisionVector = useNormal ? collision.contacts[0].normal : (transform.position - collision.contacts[0].point).normalized;
		Debug.DrawRay(collision.contacts[0].point, collisionVector, Color.white);
		if(Vector3.Angle(collisionVector, localUp) > maxSlope)	return;
		flying = false;
		if(autoOrient)	localUp = collisionVector;
	}

	public virtual void OnCollisionExit(){
		flying = true;
	}

	public virtual void FixedUpdate(){
		Debug.DrawRay(transform.position, localUp, Color.cyan);
		if(flying && !canGlide)	return;
		if(attachedRigidbody == null)	attachedRigidbody = GetComponent<Rigidbody>();
		if(attachedRigidbody == null){	Debug.LogError(gameObject.name + "'s attached Rigidbody has been lost!");	enabled = false;	return;	}

		if(!flying && Input.GetButtonDown("Jump")){
			attachedRigidbody.AddRelativeForce(Vector3.up * Mathf.Sqrt(Mathf.Max(0f, gravityOverride + (attachedRigidbody.useGravity ? Physics.gravity.magnitude : 0f)) * jumpHeight * 2f), ForceMode.VelocityChange);
			flying = true;
			return;
		}
		if((Input.GetAxisRaw("Horizontal") == 0f) && (Input.GetAxisRaw("Vertical") == 0f)){
			if(!flying && (attachedRigidbody.velocity.sqrMagnitude > Physics.sleepThreshold)){
				thrust = -attachedRigidbody.velocity.normalized;
				thrust = thrust + (transform.TransformDirection(thrust).y * transform.up);
				attachedRigidbody.AddForce(thrust * strength, ForceMode.Acceleration);
			}
			return;
		}
		
		frameRotation = Quaternion.FromToRotation(Vector3.up, localUp);
		frameRotation = frameRotation * Quaternion.Euler(0f, ((Quaternion.Inverse(frameRotation) * Camera.main.transform.rotation).eulerAngles.y + (Mathf.Atan2(Input.GetAxisRaw("Vertical"), -Input.GetAxisRaw("Horizontal")) * Mathf.Rad2Deg)) - 90f, 0f);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, frameRotation, (90f * Time.fixedDeltaTime) * strength);
		
		if((Input.GetKey(walkOrRunKey) == normallyRunning))
			speed = walkSpeed;
		else	speed = runSpeed;

		targetVelocity = ((frameRotation * Vector3.forward) * speed) * 2f;
		oldVelocity = attachedRigidbody.velocity;
		thrust = (targetVelocity - Vector3.Project(oldVelocity, targetVelocity)) - oldVelocity;
		thrust -= (transform.TransformDirection(thrust).y * transform.up);
		if(flying && runSpeed > 0f)	thrust *= walkSpeed / runSpeed;
		attachedRigidbody.AddForce(thrust * strength, ForceMode.Acceleration);

		Debug.DrawRay(transform.position, oldVelocity, Color.red);
		Debug.DrawLine(transform.position + oldVelocity, transform.position + Vector3.Project(oldVelocity, targetVelocity), Color.yellow);
		Debug.DrawRay(transform.position, targetVelocity, Color.green);
		Debug.DrawRay(transform.position, thrust, Color.blue);
	}

	public virtual void Orient(Vector3 up){
		localUp = up;
	}

	public virtual void Orient(Transform gravitySource){
		Vector3 gravitationalAcceleration = transform.position - gravitySource.position;
		gravityOverride = gravitationalAcceleration.magnitude;
		gravitationalAcceleration /= gravityOverride;
		Orient(gravitationalAcceleration);
		gravityOverride = 1f / gravityOverride / gravityOverride;
		//gravitationalAcceleration /= gravityOverride * gravityOverride;
		if(gravitySource.GetComponent<Gravity>())
			gravityOverride *= gravitySource.GetComponent<Rigidbody>().mass * Gravity.G;
	}

	public RigidbodyCharacterController(){
		walkSpeed = 3f;
		runSpeed = 10f;
		jumpHeight = 2f;
		strength = 10f;
		walkOrRunKey = KeyCode.LeftShift;
		normallyRunning = true;
		canGlide = false;
		localUp = Vector3.up;
		flying = true;
		frameRotation = Quaternion.identity;
	}
}