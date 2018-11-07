using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scorelist", menuName = "Score/List", order = 1)]
public class ScoreList : ScriptableObject {

    public int[] Scores;    

    public int GetScore(int i)
    {
        return Scores[i];
    }

    public void SetNewScore(int NewScore)
    {
        //for loop that determines if the new score is any larger than the previous scores, and then decides where the new score belongs in the array.
        //this may work better as an arraylist but we can figure that put later.
    }
}
