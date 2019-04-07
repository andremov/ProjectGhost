using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityActionsInterface : MonoBehaviour
{
    public abstract void OnButtonPress(int buttonId);
    public abstract void OnButtonRelease(int buttonId);
}
