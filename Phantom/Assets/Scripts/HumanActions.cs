using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanActions : EntityActionsInterface
{

    EntityController ent;

    void Start()
    {
        ent = GetComponent<EntityController>();
    }

    void Update()
    {

    }

    public override void OnButtonPress(int buttonId)
    {

        if (buttonId == 2)
        {
            LeaveBody();
        }
    }

    public override void OnButtonRelease(int buttonId)
    {
        
    }
    
    void LeaveBody()
    {
        if (FindObjectOfType<PlayerHandler>().CanSwapShells)
        {
            /*
            GameObject ghost = GetComponent<EntityController>().ghostForm;

            ghost.SetActive(true);
            ghost.transform.rotation = transform.rotation;
            ghost.transform.position = transform.position - (transform.forward * 2f);

            EntityController ghostEnt = ghost.GetComponent<EntityController>();

            FindObjectOfType<PlayerHandler>().Shell = ghostEnt;

            ent.Controlled = false;
            ghostEnt.Controlled = true;
            */

            FindObjectOfType<PlayerHandler>().Shell = null;

        }
    }
}
