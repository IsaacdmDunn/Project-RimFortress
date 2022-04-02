using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public List<int> causedByChar;
    public List<int> affectedChar;
    public CastManager cast;
    public int eventTimeStep;
    public int longestTime=10000;
    public Memory memToAdd;

    public void Start()
    {
        
    }
    void CheckMemory()
    {
        longestTime = 10000;

        //check each characters memory
        for (int i = 0; i < cast.cast.Count; i++)
        {
            if (cast.cast[i].isAlive)
            {
                for (int j = 0; j < cast.cast[i].brain.Count; j++)
                {
                    if (cast.cast[i].brain[j].timeStamp < longestTime)
                    {
                        longestTime = cast.cast[i].brain[j].timeStamp;
                    }
                }
            }
        }


        //picks event based on timestamp
        for (int i = 0; i < cast.cast.Count; i++)
        {
            
            for (int j = 0; j < cast.cast[i].brain.Count; j++)
            {
                if (cast.cast[i].isAlive)
                {
                    switch (cast.cast[i].brain[j].id)
                    {
                        case 1: //murder
                            causedByChar.Add(cast.cast[i].brain[j].causedByChar[0]);
                            affectedChar.Add(cast.cast[i].brain[j].affectedChar[0]);

                            Debug.Log(cast.cast[i].name + " says " + cast.cast[causedByChar[0]].name + " you killed " + cast.cast[affectedChar[0]].name + " how could you");
                            MurderRememberPrecondition(i, j);
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                }
            }
        }
    }
    
    void LoveTriangle()
    {

    }

    private void Update()
    {
        
        if (Random.Range(0, 600) == 10) // randomly increases timestep to allow for events to transpire at certain times
        {
            eventTimeStep++;
            CheckMemory();
        }
    }

    public void MurderRememberPrecondition(int characterID, int memoryID)
    {
        if (cast.cast[characterID].brain[memoryID].cast[causedByChar[0]].isAlive)// && characterID != causedByChar[0] && characterID != affectedChar[0])
        {

            //if cast member is vengeful
            if (cast.cast[characterID].traits.Contains((Trait.traitType)1))// && cast.cast[0].relations[0] > 0.5f)
            {
                Debug.Log(cast.cast[0].name + " says " + cast.cast[causedByChar[0]].name + " you killed " + cast.cast[affectedChar[0]].name + " prepare to die.");
                cast.cast[characterID].GetComponentInParent<Jobs>().tasks.Add(new Task(cast.cast[causedByChar[0]].transform.position, Task.taskType.kill, cast.cast[causedByChar[0]]));
                //add kill character to jobs list
                //change emotional state
            }
        }
        cast.cast[characterID].brain.RemoveAt(memoryID);
        
    }
}
