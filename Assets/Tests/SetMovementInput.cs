using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetMovementInput : Action
{
    public SharedBotInput SelfBotInput;
    public SharedVector2 Direction;

    public override TaskStatus OnUpdate()
    {
        SelfBotInput.Value.MovementInput = Direction.Value;
        return TaskStatus.Success;
    }
}
