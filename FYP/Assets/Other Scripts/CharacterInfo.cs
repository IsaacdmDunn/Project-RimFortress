using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    
    public string name;
    //traits list
    public List<Likes.likeType> likes;
    public List<Likes.likeType> dislikes;
    public List<Trait.traitType> traits;
    public float happiness = 0.0f;
    public float angry = 0.0f; 
    public List<float> relations;
    public List<string> relationsCharacter;
    public List<Likes.likeType> uniqueLikes;
    public List<Trait.traitType> uniqueTraits;
    public bool isAlive = true;
    enum firstNames {John=0,Dave,Katie,Pauline,Mohammad,Greg };
    enum lastNames { Jackson=0, White, Black, Rose}

    public List<Memory> brain;

    public void Start()
    {
        
        
        firstNames fname = (firstNames)Random.Range(0, 6);
        lastNames lname = (lastNames)Random.Range(0, 4);
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
        }

    }
}
