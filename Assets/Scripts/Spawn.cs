using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawn : MonoBehaviour
{
    private int spawnCounter = 0;
    public int CountToNegative;
    [HideInInspector] public int activeBlockIndex;
    [HideInInspector] public GameObject activeBlock;
    public TMP_Text nextText;
    public GameObject[] Tetrominoes;
    public GameObject[] negativeTetrominoes;
    // Start is called before the first frame update
    [HideInInspector] public List<int> blocksToSpawn = new List<int>();

    private CameraEvents camEvent;

    void Start()
    {
        camEvent = GameObject.Find("Main Camera").GetComponent<CameraEvents>();
        for(int i=0;i<3; i++)
        {
            AddBlockToList();        
        }
        NewTetromino();
    }

    public void NewTetromino()
    {
        spawnCounter++;
        if (spawnCounter==CountToNegative) {
            activeBlock = Instantiate(negativeTetrominoes[blocksToSpawn[0]], transform.position, Quaternion.identity);
            spawnCounter = 0;
            camEvent.PlayEvent();
        } else
        {
            activeBlock = Instantiate(Tetrominoes[blocksToSpawn[0]], transform.position, Quaternion.identity);
        }
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
            int randomInt = Random.Range(0, Tetrominoes.Length);
            if (blocksToSpawn.Count > 2)
            {
                // if randomInt is the same as last 2 numbers in list, then reroll it till its not the same. 
                while (randomInt == blocksToSpawn[blocksToSpawn.Count - 1] && randomInt == blocksToSpawn[blocksToSpawn.Count - 2])
                {
                    randomInt = Random.Range(0, Tetrominoes.Length);
                }
            }
            blocksToSpawn.Add(randomInt);
    }
}
