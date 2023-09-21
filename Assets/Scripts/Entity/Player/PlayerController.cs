using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerController")]
public class PlayerController : InputController
{
    public override bool RetrieveJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }
    public override float RetrieveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }
    public override bool RetrieveRangedAttackInput()
    {
        return Input.GetButtonDown("Fire1");
    }
}
