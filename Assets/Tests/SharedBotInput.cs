using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedBotInput : SharedVariable<BotInput>
{
    public static implicit operator SharedBotInput(BotInput value) => new SharedBotInput { Value = value };
}
