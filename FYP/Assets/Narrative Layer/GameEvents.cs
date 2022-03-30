using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public List<int> causedByChar;
    public List<int> affectedChar;
    public CastManager cast;
    public int eventTimeStep;
    public int memChar=-1, mem=-1, longestTime=10000;
    public Memory memToAdd;
    public bool charfound = false;

    public void Start()
    {
        
    }
    void CheckMemory()
    {
        longestTime = 10000;
        charfound = false;
        //int longestTime = 0;
        //characters = FindObjectsOfType<CharacterInfo>();
        //check each characters memory

        for (int i = 0; i < cast.cast.Count; i++)
        {
            //Debug.Log(characters[i].name);
            for (int j = 0; j < cast.cast[i].brain.Count; j++)
            {
                if (cast.cast[i].brain[j].timeStamp < longestTime)
                {
                    longestTime = cast.cast[i].brain[j].timeStamp;
                    mem = j;
                    memChar = i;
                    charfound = true;
                }
            }
        }


        //picks event based on timestamp
        //if (characters.Length > 0 && mem>-1 && memChar > -1 && charfound == true)
        for (int i = 0; i < cast.cast.Count; i++)
        {
            for (int j = 0; j < cast.cast[i].brain.Count; j++)
            {
                switch (cast.cast[i].brain[j].id)
                {
                    case 1: //murder
                        causedByChar.Add(cast.cast[i].brain[j].causedByChar[0]);
                        affectedChar.Add(cast.cast[i].brain[j].affectedChar[0]);
                        
                        Debug.Log(cast.cast[causedByChar[0]].name + " you killed " + cast.cast[affectedChar[0]].name + " how could you");
                        MurderRememberPrecondition();
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
    
    public void CheckPrecondiion()
    {
        //check precondition based on characters memories idk
        if (memChar > 0 && mem > 0)
        {

        }
        //characters[memChar].brain[mem].activateEvent();
        
    }
    
    //void PlayedMurdered()
    //{
    //    causedByChar.Add(0);
    //    affectedChar.Add(0);
        
    //    //if cast member is vengeful
    //    if (cast.cast[0].traits[0] == (Trait.traitType)1 && cast.cast[affectedChar[0]].relations[0] > 0.5f)
    //    {
    //        Debug.Log(cast.cast[causedByChar[0]].name + " you killed " + cast.cast[affectedChar[0]].name + " prepare to die.");
    //        cast.cast[0].brain.Add(new Memory(this, 1, eventTimeStep, causedByChar, affectedChar, cast.cast, MurderRememberPrecondition));
    //        //change emotional state
    //    }
    //    if (cast.cast[0].traits[0] == (Trait.traitType)4 && cast.cast[causedByChar[0]].relations[0] > 0.5f)
    //    {
    //        Debug.Log(cast.cast[causedByChar[0]].name + " you killed " + cast.cast[affectedChar[0]].name + " while i cannot forget i can forgive.");
    //        cast.cast[0].brain.Add(new Memory(this, 1, eventTimeStep, causedByChar, affectedChar, cast.cast, MurderRememberPrecondition));
    //        //change emotional state
    //    }

    //}

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
        //test memory creation
        //if (Random.Range(0, 600) == 10 && cast.cast.Count > 0) 
        //{
        //    memToAdd.affectedChar = affectedChar;
        //    memToAdd.causedByChar = causedByChar;
        //    memToAdd.cast = cast.cast;
        //    memToAdd.timeStamp = eventTimeStep;
        //    memToAdd.id = 1;
        //    //memToAdd.precon = MurderRememberPrecondition;
        //    GameObject go = Instantiate(memToAdd.gameObject);
        //    cast.cast[0].brain.Add(go.GetComponent<Memory>());
        //    //Debug.Log("memory made");
        //}

    }

    public void MurderRememberPrecondition()
    {
        Debug.Log(cast.cast[0].name + " says " + cast.cast[causedByChar[0]].name + " you killed " + cast.cast[affectedChar[0]].name + " prepare to die.");
        //if cast member is vengeful
        //if (cast.cast[0].traits[0] == (Trait.traitType)1 && cast.cast[0].relations[0] > 0.5f)
        {
            cast.cast[0].GetComponentInParent<Jobs>().tasks.Add(new Task(cast.cast[causedByChar[0]].transform.position, Task.taskType.kill, cast.cast[causedByChar[0]]));
            //add kill character to jobs list
            //change emotional state
        }
    }
}
