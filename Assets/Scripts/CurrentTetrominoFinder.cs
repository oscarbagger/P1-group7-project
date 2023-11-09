using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTetrominoFinder : MonoBehaviour
{
    public static GameObject CurrentTetrominoPrefab { get; private set; }

    // Update is called once per frame
    void Update()
    {
        FindCurrentTetrominoPrefab();
    }

    void FindCurrentTetrominoPrefab()
    {
        TetrisBlock[] tetrisBlocks = FindObjectsOfType<TetrisBlock>();

        if (tetrisBlocks.Length > 0 && tetrisBlocks[0].transform.childCount > 0)
        {
            CurrentTetrominoPrefab = tetrisBlocks[0].transform.GetChild(0).gameObject;
        }
        else
        {
            CurrentTetrominoPrefab = null;
        }
    }
}
