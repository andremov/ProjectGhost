using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float moveSpeed;
    //public float rotateSpeed;
    public bool viewLock = false;
    public bool canToggleViewLock = true;

    public EntityController shell;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //tangible = Input.GetAxis("Fire1") == 0;
        if (Input.GetAxis("Fire1")!=0)
        {
            shell.eai.OnButtonPress();
        } else
        {
            shell.eai.OnButtonRelease();
        }
        /*
        if (canToggleViewLock && Input.GetAxis("Fire2") != 0)
        {
            canToggleViewLock = false;
            viewLock = !viewLock;
        } else if(!canToggleViewLock && Input.GetAxis("Fire2") == 0)
        {
            canToggleViewLock = true;
        }
        */
        //gameObject.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime);

        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        shell.Move(moveVelocity);

        shell.LookAt(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        /*
        if (!viewLock) {
            gameObject.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * rotateSpeed * Time.deltaTime);
        } else
        {
            gameObject.transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime);
        }
        */
    }
}

/*
    Vector3 moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
    Vector3 moveVelocity = moveInput.normalized * moveSpeed;
    controller.Move (moveVelocity);

    
	controller.LookAt(point);

    public void Move(Vector3 _velocity) {
		velocity = _velocity;
	}

	public void LookAt(Vector3 lookPoint) {
		Vector3 heightCorrectedPoint = new Vector3 (lookPoint.x, transform.position.y, lookPoint.z);
		transform.LookAt (heightCorrectedPoint);
	}

    void FixedUpdate() {
		myRigidbody.MovePosition (myRigidbody.position + velocity * Time.fixedDeltaTime);

	}
*/
