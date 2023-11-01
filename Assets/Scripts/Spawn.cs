using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] Tetrominoes;
    // Start is called before the first frame update
    public List<int> blocksToSpawn = new List<int>();

    void Start()
    {
        for(int i=0;i<3; i++)
        {
            AddBlockToList();        
        }
        NewTetromino();
    }

    public void NewTetromino()
    {
        Instantiate(Tetrominoes[blocksToSpawn[0]], transform.position, Quaternion.identity);
        blocksToSpawn.RemoveAt(0);
        AddBlockToList();
        Debug.Log("Next block is: "+Tetrominoes[blocksToSpawn[0]]);
    }

    public void AddBlockToList()
    {
        int randomInt= Random.Range(0, Tetrominoes.Length);
        if (blocksToSpawn.Count>2)
        {
            // if randomInt is the same as last 2 numbers in list, then reroll it till its not the same. 
            while (randomInt==blocksToSpawn[blocksToSpawn.Count-1] && randomInt==blocksToSpawn[blocksToSpawn.Count-2])
            {
                randomInt = Random.Range(0, Tetrominoes.Length);
            }
        }
        blocksToSpawn.Add(randomInt);

    }
}
