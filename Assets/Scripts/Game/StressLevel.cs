using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressLevel : MonoBehaviour
{
    public static int stress = 0;
    public static int maxStress = TetrisBlock.height;
    public Animator characterAnimator;
    public static int StressPercentage // returns stress as a percentage in relation to height of the grid, aka max stress. 
    {
        get
        {
            return stress * 100 / maxStress;
        }
    }
    private void Start()
    {
        stress = 0;
        UpdateStressLevel();
    }

    public void UpdateStressLevel()
    {
        stress = GetIndexOfHighestBlock(); // set stress to the same as the highest occupied space in the tetris grid.
        characterAnimator.SetInteger("stress",StressPercentage);
    }

    // cycle through all indexes of our grid, top-down, left to right until an occupied space is found.
    public int GetIndexOfHighestBlock()
    {
        for (int i=TetrisBlock.height-1; i>-1;i--)
        {
            for(int j=0; j<TetrisBlock.width-1;j++)
            {
                if (TetrisBlock.grid[j,i]!=null) // if a position in the grid is occupied return its height index
                {
                    return i;
                }
            }
        }
        return 0;
    }    
}
