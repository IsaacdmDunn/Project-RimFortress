using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkNode : Node
{
    bool isInConversation;
    CharacterInfo target;
    CharacterInfo origin;

    public TalkNode(bool isInConversation, CharacterInfo target, CharacterInfo origin)
    {
        this.isInConversation = isInConversation;
        this.target = target;
        this.origin = origin;
    }

    public override NodeState Evaluate()
    {
        if (Random.Range(0, 5) == 0)
        {
            origin.dialogGen.PickPerson(origin.id, target.id);
            origin.dialogGen.CreateDialog();
            return NodeState.success;
        }
        
        return NodeState.failure;
    }

    
}
