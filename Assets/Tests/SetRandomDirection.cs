using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetRandomDirection : Action
{
    public SharedVector2 Direction;

    public override TaskStatus OnUpdate()
    {
        Direction.Value = Random.insideUnitCircle.normalized;
        return TaskStatus.Success;
    }
}
