using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawn : MonoBehaviour
{
    public int activeBlockIndex;
    public GameObject activeBlock;
    public TMP_Text nextText;
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
        activeBlock= Instantiate(Tetrominoes[blocksToSpawn[0]], transform.position, Quaternion.identity);
        activeBlockIndex = blocksToSpawn[0];
        blocksToSpawn.RemoveAt(0);
        AddBlockToList();
        nextText.text = "Next block: " + Tetrominoes[blocksToSpawn[0]];
    }
    public void NewTetromino(int newIndex)
    {
        activeBlock= Instantiate(Tetrominoes[newIndex], transform.position, Quaternion.identity);
        activeBlockIndex = newIndex;
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
