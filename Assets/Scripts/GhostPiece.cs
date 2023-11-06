using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPiece : MonoBehaviour
{
    private TetrisBlock tetrisBlock;
    private bool canMove = true;

    private void Start()
    {
        tetrisBlock = GetComponent<TetrisBlock>();
        CalculateGhostPosition();
    }

    private void Update()
    {
        if (canMove)
        {
            CalculateGhostPosition();
        }
    }

    public void CalculateGhostPosition()
    {
        transform.position = tetrisBlock.transform.position;

        while (CanMoveDown())
        {
            transform.position += new Vector3(0, -1, 0);
        }
    }

    private bool CanMoveDown()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedY <= 0 || TetrisBlock.grid[roundedX, roundedY - 1] != null)
            {
                canMove = false;
                return false;
            }
        }

        canMove = true;
        return true;
    }
}
