using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressLevel : MonoBehaviour
{
    public static int stress = 0;
    public static int maxStress = TetrisBlock.height;
    public static int StressPercentage
    {
        get
        {
            return stress * 100 / maxStress;
        }
    }

    public void UpdateStressLevel()
    {
        stress = GetIndexOfHighestBlock();
        Debug.Log("Stress:"+StressPercentage);
    }

    // cycle through all indexes of our grid, top-down, left to right until an occupied space is found. then return that height index.
    public int GetIndexOfHighestBlock()
    {
        for (int i=TetrisBlock.height-1; i>-1;i--)
        {
            for(int j=0; j<TetrisBlock.width-1;j++)
            {
                if (TetrisBlock.grid[j,i]!=null)
                {
                    return i;
                }
            }
        }
        return 0;
    }    
}
