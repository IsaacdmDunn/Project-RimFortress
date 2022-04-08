using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    
    public string name;
    public int id;
    public int health = 100;
    //traits list
    public List<Likes.likeType> likes;
    public List<Likes.likeType> dislikes;
    public List<Trait.traitType> traits;
    public float happiness = 0.0f;
    public float angry = 0.0f; 
    public List<float> relations;
    public List<Likes.likeType> uniqueLikes;
    public List<Trait.traitType> uniqueTraits;
    public bool isAlive = true;
    enum firstNames {John=0,Dave,Katie,Pauline,Mohammad,Greg, Boris,Ashley,Jackie,Kevin };
    enum lastNames { Jackson=0, White, Black, Rose, Hobbs, Dunn, Harris, North, Anderson}

    public List<Memory> brain;
    public CastManager cast;
    public List<int> causedBy;
    public List<int> affected;

    public DialogGenerator dialogGen;

    public void Start()
    {
        frame = Random.Range(0, 3000);

        id = cast.cast.Count;
        dialogGen = new DialogGenerator();
        dialogGen.char1ID = id;
        dialogGen.castManager = cast;
        cast.cast.Add(this);
        

        firstNames fname = (firstNames)Random.Range(0, 9);
        lastNames lname = (lastNames)Random.Range(0, 8);
        name = fname.ToString() + " " + lname.ToString();

        for (int i = 0; i < 4; i++)
        {
            Likes.likeType _like = (Likes.likeType)i;
            uniqueLikes.Add(_like);
        }
        for (int i = 0; i < 4; i++)
        {
            Trait.traitType _trait = (Trait.traitType)i;
            uniqueTraits.Add(_trait);
        }


        for (int i = 0; i < 2; i++)
        {
            Likes.likeType _like = uniqueLikes[Random.Range(0, uniqueLikes.Count)];
            likes.Add(_like);
            uniqueLikes.Remove(_like);
        }
        for (int i = 0; i < 2; i++)
        {
            Likes.likeType _dislike = uniqueLikes[Random.Range(0, uniqueLikes.Count)];
            dislikes.Add(_dislike);
            uniqueLikes.Remove(_dislike);
        }
        for (int i = 0; i < 2; i++)
        {
            Trait.traitType _trait = uniqueTraits[Random.Range(0, uniqueTraits.Count)];
            traits.Add(_trait);
            uniqueTraits.Remove(_trait);
        }

        //coroutine to delay initialisation of traits so that other characters can initialise
        {
            StartCoroutine(LateStart(1));
        }

        IEnumerator LateStart(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            cast.SetInitialRelations(id);
        }

        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Jobs>().tasks.Count > 0 && isAlive)
        {
            if (collision.gameObject.GetComponent<Jobs>().tasks[0].type == Task.taskType.attack || collision.gameObject.GetComponent<Jobs>().tasks[0].type == Task.taskType.kill)
            {
                for (int i = 0; i < cast.cast.Count; i++)
                {
                    
                    
                    causedBy.Add(collision.gameObject.GetComponent<CharacterInfo>().id);
                    affected.Add(id);

                    Memory memToAdd = new Memory(null, 0, 0, null, null, null);
                    memToAdd.affectedChar = affected;
                    memToAdd.causedByChar = causedBy;
                    memToAdd.cast = cast.cast;
                    memToAdd.timeStamp = 0;
                    memToAdd.id = 1;
                    memToAdd.precon = null;
                    //GameObject go = Instantiate(memToAdd.gameObject);
                    for (int j = 0; j < cast.cast.Count; j++)
                    {
                        if (j != affected[0] && j != causedBy[0] && isAlive)
                        {
                            cast.cast[j].brain.Add(memToAdd);

                        }
                        
                    }
                    isAlive = false;
                }
            }
        }
    }


    int frame;

    private void Update()
    {
        //change for job system in behaviour trees
        if (frame == 3000)
        {
            
            frame = 0;

            dialogGen.castManager = cast;
            dialogGen.PickRandomPerson();
            dialogGen.CreateDialog();

            for (int i = 0; i < relations.Count; i++)
            {
                if (relations[i] > 1f)
                {
                    relations[i] = 1f;
                }
                else if (relations[i] < -1f)
                {
                    relations[i] = -1f;
                }
            }
        }
        frame++;
        
    }

    public void SendDialogMessage(string dialog)
    {
        FindObjectOfType<UI>().dialog.Add(dialog);
    }

}
