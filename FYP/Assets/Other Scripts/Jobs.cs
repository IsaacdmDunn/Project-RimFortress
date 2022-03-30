using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jobs : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Task> tasks;
    Task idle = new Task(new Vector3(0,0,0), Task.taskType.idle, null);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (tasks.Count > 0)
        {
            switch (tasks[0].type)
            {
                case Task.taskType.idle:
                    break;
                case Task.taskType.walkTo:
                    if (this.transform.position == tasks[0].pos) tasks[0].taskComplete = true;
                    else this.GetComponent<CharacterMovement>().target = tasks[0].pos;
                    break;
                case Task.taskType.kill:
                    this.GetComponent<CharacterMovement>().target = tasks[0].pos;
                    if (!tasks[0].character.isAlive) tasks[0].taskComplete = true;
                    break;
            }
            if (tasks[0].taskComplete == true)
            {
                tasks.RemoveAt(0);
            }
            
            
        }
        
    }
}
