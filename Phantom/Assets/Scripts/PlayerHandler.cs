using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float moveSpeed;
    bool viewLock = false;
    readonly float shellSwapCooldown = 2f;
    //bool CanToggleViewLock = true;

    public GameObject ghostPrefab;

    EntityController shell;
    public EntityController Shell {
        set
        {
            if (value == null)
            {
                CreateGhostForm();
            }
            else
            {
                shell = value;
                StartCoroutine(DoSwapCooldown());
            }
        }
        private get
        {
            return shell;
        }
    }


    bool canSwapShells;
    public bool CanSwapShells
    {
        get
        {
            return canSwapShells;
        }
        private set
        {
            canSwapShells = value;
        }
    }

    public float value = 1f;
    public HealthInterface healthUI;

    void Start()
    {
        if (Shell == null)
        {
            CreateGhostForm();
        }
    }

    void CreateGhostForm()
    {
        Shell = Instantiate(ghostPrefab, transform.position, transform.rotation).GetComponent<EntityController>();
    }

    void Update()
    {

        value -= 0.01f * Time.deltaTime;
        healthUI.DisplayedHealth = value;

        if (Input.GetAxis("Fire1")!=0)
        {
            Shell.EntityActions.OnButtonPress(1);
        } else
        {
            Shell.EntityActions.OnButtonRelease(1);
        }

        if (Input.GetAxisRaw("Jump") != 0)
        {
            Shell.EntityActions.OnButtonPress(2);
        } else
        {
            Shell.EntityActions.OnButtonRelease(2);
        }

        viewLock = Input.GetAxis("Fire2") != 0;

        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        Vector3 moveInput = new Vector3(horz, 0, vert);
        moveInput = transform.rotation * moveInput;

        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        Shell.Move(moveVelocity);

        if (viewLock)
        {
            transform.rotation = Shell.transform.rotation;
        } else
        {
            Vector3 lookPoint = new Vector3(horz, 0, vert);
            lookPoint = transform.rotation * lookPoint;
            Shell.LookAt(lookPoint + Shell.transform.position);
        }


        transform.position = Shell.transform.position;

        if (viewLock)
        {
            transform.rotation = Shell.transform.rotation;
        }
    }

    public IEnumerator DoSwapCooldown()
    {
        CanSwapShells = false;
        float cooldownSpeed = 1f / shellSwapCooldown;
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime * cooldownSpeed;
            yield return null;
        }

        Debug.Log("Swap ready!");
        CanSwapShells = true;
    }

}