using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [HideInInspector]
    public EntityActionsInterface eai;
    Rigidbody rb;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        eai = GetComponent<EntityActionsInterface>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector3 vel)
    {
        velocity = vel;
    }

    public void LookAt(float horz, float vert)
    {
        Vector3 heightCorrectedPoint = new Vector3(transform.position.x+horz, transform.position.y, transform.position.z+vert);
        transform.LookAt(heightCorrectedPoint);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

    }
}
