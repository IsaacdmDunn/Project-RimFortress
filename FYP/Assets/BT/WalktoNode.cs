using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalktoNode : Node
{
    public Vector3 target;
    public Transform origin;

    public WalktoNode(Vector3 target, Transform origin)
    {
        this.origin = origin;
        this.target = target;
        this.target += new Vector3(0.5f,0,0);
    }

    public override NodeState Evaluate()
    {
        
        if (origin.position.x < target.x && origin.position.y < target.y + 0.1f)
        {
            if (origin.position.x > target.x + 0.1f && origin.position.y > target.y)
            {
                target = new Vector3(Random.Range(-4, 5), Random.Range(-3, 3), 0);
                return NodeState.failure;
            }
        }
        else
        {
            if (origin.position.x < target.x)
            {
                origin.position += new Vector3(0.02f, 0, 0);
            }
            else if (origin.position.x >= target.x)
            {
                origin.position -= new Vector3(0.02f, 0, 0);
            }
            else if (origin.position.y < target.y)
            {
                origin.position += new Vector3(0, 0.02f, 0);
            }
            else if (origin.position.y >= target.y)
            {
                origin.position -= new Vector3(0, 0.02f, 0);
            }
            
        }
        
        return NodeState.success;
    }
}
