using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostActions : EntityActionsInterface
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
        if (buttonId == 1)
        {
            GoGhost(true);
        }

        if (buttonId == 2)
        {
            Capture();
        }
    }

    public override void OnButtonRelease(int buttonId)
    {

        if (buttonId == 1)
        {
            GoGhost(false);
        }
        
    }

    public void Capture()
    {
        if (Physics.SphereCast(transform.position, 1f, transform.forward, out RaycastHit hit, 5))
        {
            EntityController newShell = hit.collider.gameObject.GetComponent<EntityController>();
            if (newShell != null)
            {
                if (FindObjectOfType<PlayerHandler>().CanSwapShells)
                {
                    ent.Controlled = false;
                    newShell.Controlled = true;

                    FindObjectOfType<PlayerHandler>().Shell = newShell;
                    /*
                    newShell.ghostForm = gameObject;
                    
                    gameObject.SetActive(false);
                    */
                    Destroy(gameObject);
                }
            }
        }
    }

    void GoGhost(bool state)
    {
        gameObject.layer = state? 12 : 11;
    }
}
