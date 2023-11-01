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
    }

    public int GetIndexOfHighestBlock()
    {
        for (int i=TetrisBlock.height-1; i>-1;i--)
        {
            for(int j=0; j<TetrisBlock.width;j++)
            {
                if (TetrisBlock.grid[i,j]!=null)
                {
                    return i;
                }
            }
        }
        return 0;
    }    
}
