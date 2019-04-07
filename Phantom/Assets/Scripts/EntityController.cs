using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    bool controlled;
    public bool Controlled {
        get {
            return controlled;
        }
        set
        {
            if (!value)
            {
                velocity = Vector3.zero;
            }
            controlled = value;
        }
    }
    EntityActionsInterface eai;
    public EntityActionsInterface EntityActions
    {
        get
        {
            return eai;
        }
        private set
        {
            eai = value;
        }
    }

    [HideInInspector]
    public GameObject ghostForm;

    Rigidbody rb;
    Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        eai = GetComponent<EntityActionsInterface>();
    }
    
    void Update()
    {

    }

    public void Move(Vector3 vel)
    {
        velocity = vel;
    }

    public void LookAt(Vector3 point)
    {
        transform.LookAt(point);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
