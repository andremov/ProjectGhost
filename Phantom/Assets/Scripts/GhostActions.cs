using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostActions : EntityActionsInterface
{
    public override void OnButtonPress()
    {

        gameObject.layer = 12;
    }

    public override void OnButtonRelease()
    {

        gameObject.layer = 11;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
