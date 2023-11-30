using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    private float spawnDelayTime = 2f;
    private int spawnCounter = 0; // counts number of blocks being spawned
    private int eventCounter = 0;
    [SerializeField] private int firstEventCounterOffset;
    private int nextListLength = 3; // amount of blocks to have in the spawnlist at start of game.
    public int CountToNegative; // amount of blocks to spawn before a negative block will spawn.
    public int CountToEvent; // amount of blocks to spawn before an event will happen.
    [HideInInspector] public int activeBlockIndex; // the index of currently active block
    [HideInInspector] public GameObject activeBlock; // the active block gameobject
    public Image NextSprite; // sprite image of the next block to spawn
    public Sprite[] previewTetrominos; // array of sprites to use for displaying next block
    public GameObject[] Tetrominoes; // array of possible blocks to spawn
    public GameObject[] negativeTetrominoes; // array of possible negative blocks to spawn
    // Start is called before the first frame update
    [HideInInspector] public List<int> blocksToSpawn = new List<int>(); // a list of blocks to pull from when spawning new blocks.

    private CameraEvents camEvent;

    void Start()
    {
        eventCounter = firstEventCounterOffset;
        camEvent = GameObject.Find("Main Camera").GetComponent<CameraEvents>(); // get reference to cameraEvent script on camera.
        // fill up the blocksToSpawn list, calling the same method a number of times. 
        for(int i=0;i<nextListLength; i++)
        {
            AddBlockToList();        
        }
        // delay before spawning first block
        StartCoroutine(SpawnDelay(spawnDelayTime));

    }
    // instantiate new block
    public void NewTetromino()
    {
        spawnCounter++; // count up number of blocks spawned
        eventCounter++;
                        // if spawncounter reaches a certain number, spawn a negative block instead of a normal block
        if (eventCounter == CountToEvent) 
        {
            camEvent.PlayEvent(); // play an event
            eventCounter = 0;
        }
        if (spawnCounter==CountToNegative) {
            // instantiate prefab from array, taking the array index from the blocksToSpawn list
            activeBlock = Instantiate(negativeTetrominoes[blocksToSpawn[0]], transform.position, Quaternion.identity); 
            spawnCounter = 0; // reset spawncounter
        } else
        {
            // instantiate prefab from array, taking the array index from the blocksToSpawn list
            activeBlock = Instantiate(Tetrominoes[blocksToSpawn[0]], transform.position, Quaternion.identity);
        }
        activeBlockIndex = blocksToSpawn[0]; // update index of active block to match the newly instantiated block
        blocksToSpawn.RemoveAt(0); // remove the used index from list.
        AddBlockToList(); // add new block to spawnlist
        NextSprite.sprite = previewTetrominos[blocksToSpawn[0]]; // update next block preview
        NextSprite.SetNativeSize(); // update next block sprite size
    }
    // instantiate new block with specfified index, instead of pulling from the blocksToSpawn list.
    public void NewTetromino(int newIndex)
    {
        activeBlock= Instantiate(Tetrominoes[newIndex], transform.position, Quaternion.identity);
        activeBlockIndex = newIndex; // update index of active block to match the newly instantiated block
    }
    // add a random block to the blocksToSpawn list
    public void AddBlockToList()
    {
        // get random index from the range of the tetrominoes array.
            int randomInt = Random.Range(0, Tetrominoes.Length);
        // check length of the list
            if (blocksToSpawn.Count > 2)
            {
                // if randomInt is the same as last 2 numbers in list, then "reroll" it until it is not the same.
                while (randomInt == blocksToSpawn[blocksToSpawn.Count - 1] && randomInt == blocksToSpawn[blocksToSpawn.Count - 2])
                {
                    randomInt = Random.Range(0, Tetrominoes.Length); // get random index from the range of the tetrominoes array.
            }
        }
            blocksToSpawn.Add(randomInt);  // add the index to the list
    }
    private IEnumerator SpawnDelay(float time)
    {
        yield return new WaitForSeconds(time);
        NewTetromino();
    }
}
