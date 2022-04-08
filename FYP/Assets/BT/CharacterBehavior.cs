using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public CharacterInfo info;
    public CastManager castManager;
    Node topNode;

    private void Start()
    {
        ConstructBT();
    }

    void ConstructBT()
    {
        WalktoNode idleNode = new WalktoNode(new Vector3( Random.Range(-4,5), Random.Range(-3, 3), 0), info.gameObject.transform);
        TalkNode talkNode = new TalkNode(false, info, castManager.cast[Random.Range(0, castManager.cast.Count - 1)]);
        topNode = new Selector(new List<Node> {talkNode,idleNode });
    }

    private void Update()
    {
        topNode.Evaluate();
    }

}
