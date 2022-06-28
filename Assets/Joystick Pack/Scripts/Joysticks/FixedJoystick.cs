using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FixedJoystick : Joystick
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        MoveTank.PointerDown = false;
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        MoveTank.PointerDown = true;
        base.OnPointerUp(eventData);
    }
}