using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPiece : MonoBehaviour
{
    public float opacity = 0.5f;

    private Transform ghostPieceTransform;
    private CheckChildBlocks checkChildBlocks;

    // Start is called before the first frame update
    void Start()
    {
        ghostPieceTransform = new GameObject("GhostPiece").transform;
        checkChildBlocks = FindObjectOfType<CheckChildBlocks>();
        CreateGhostPiece();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGhostPiecePosition();
    }

    void CreateGhostPiece()
    {
        Transform currentTetrominoTransform = checkChildBlocks.transform.GetChild(0);

        if (currentTetrominoTransform != null)
        {
            ghostPieceTransform.position = currentTetrominoTransform.position;
            ghostPieceTransform.localScale = currentTetrominoTransform.localScale;

            foreach (Transform child in currentTetrominoTransform)
            {
                GameObject ghostBlock = new GameObject("GhostBlock");
                ghostBlock.transform.parent = ghostPieceTransform;
                ghostBlock.transform.position = child.position;
                ghostBlock.transform.localScale = child.localScale;
                SpriteRenderer spriteRenderer = ghostBlock.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = child.GetComponent<SpriteRenderer>().sprite;
                spriteRenderer.color = new Color(1f, 1f, 1f, opacity);
            }
        }
    }

void UpdateGhostPiecePosition()
{
    Transform currentTetrominoTransform = checkChildBlocks.transform.GetChild(0);

    if (currentTetrominoTransform != null)
    {
        ghostPieceTransform.position = currentTetrominoTransform.position;

        // Ensure the ghost piece is not colliding with other blocks before moving it down
        while (IsValidMove())
        {
            ghostPieceTransform.position += new Vector3(0, -1, 0);
        }

        // Move the ghost piece up by one unit to place it just above the valid position
        ghostPieceTransform.position += new Vector3(0, 1, 0);
    }
    else
    {
        Debug.LogError("Current Tetromino Transform is null.");
    }
}


    bool IsValidMove()
    {
        foreach (Transform child in ghostPieceTransform)
        {
            int roundedX = Mathf.RoundToInt(child.transform.position.x);
            int roundedY = Mathf.RoundToInt(child.transform.position.y);

            if (roundedX < 0 || roundedX >= TetrisBlock.width || roundedY < 0 || roundedY >= TetrisBlock.height)
            {
                return false;
            }

            if (TetrisBlock.grid[roundedX, roundedY] != null)
                return false;
        }

        return true;
    }
}
