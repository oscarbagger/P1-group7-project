using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPiece : MonoBehaviour
{
    public float opacity = 0.5f;

    private Transform ghostPieceTransform;
    private GameObject currentTetrominoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ghostPieceTransform = new GameObject("GhostPiece").transform;
        CreateGhostPiece();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGhostPiecePosition();
    }

    void CreateGhostPiece()
    {
        currentTetrominoPrefab = CurrentTetrominoFinder.CurrentTetrominoPrefab;

        if (currentTetrominoPrefab != null)
        {
            ghostPieceTransform.position = currentTetrominoPrefab.transform.position;
            ghostPieceTransform.localScale = currentTetrominoPrefab.transform.localScale;

            foreach (Transform child in currentTetrominoPrefab.transform)
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
        currentTetrominoPrefab = CurrentTetrominoFinder.CurrentTetrominoPrefab;

        if (currentTetrominoPrefab != null)
        {
            ghostPieceTransform.position = currentTetrominoPrefab.transform.position;

            while (IsValidMove())
            {
                ghostPieceTransform.position += new Vector3(0, -1, 0);
            }

            ghostPieceTransform.position -= new Vector3(0, -1, 0);
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
