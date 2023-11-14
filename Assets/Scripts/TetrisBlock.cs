using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TetrisBlock : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 0.8f;
    public static int height = 22;
    public static int width = 10;
    public static Transform[,] grid = new Transform[width, height];
    public bool moveDown=false;

    //benny
    private bool GameEnd = false;

    // Update is called once per frame
    void Update()
    {
        MoveBlockDown();
        
    }
    private void Start()
    {
        previousTime = Time.time;
    }
    public void MoveBlockHorizontal(int movement)
    {
        transform.position += new Vector3(movement, 0, 0);
        if (!ValidMove())
            transform.position -= new Vector3(movement, 0, 0);
    }
    public void MoveBlockDown()
    {
        if (Time.time - previousTime > (moveDown ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                FreezeBlock();
            }
            previousTime = Time.time;
        }
    }
    public void Rotate(int rotation)
    {
        transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), rotation);
        if (!ValidMove())
        {
            //transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -rotation);
            // after rotating, if not in a valid position move block one space left or right until valid.
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(2, 0, 0);
            }

        }
    }
    public void HardDrop()  
    {
        while (ValidMove())
        {
            transform.position += new Vector3(0, -1, 0);
        }
        FreezeBlock();


    }
    public void FreezeBlock()
    {
        transform.position -= new Vector3(0, -1, 0); // Adjust to return to last valid position
        AddToGrid();
        CheckLines();
        gameOver();
        Hold.SetCanHold();
        FindObjectOfType<StressLevel>().UpdateStressLevel();
        this.enabled = false;
        FindObjectOfType<Spawn>().NewTetromino();

        
    }
    void CheckLines()
    {
        for (int i = height-1; i >= 0; i--)
        {
            if(HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }
    
    bool HasLine(int i)
    {
        for(int j = 0; j< width; j++)
        {
            if (grid[j, i] == null)
                return false;
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j,i] = null;
        }
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j,y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
                return false;
        }
        
        return true;

    }

    void gameOver()
    {
        for (int j = 0; j < width; j++)
            {
                if (ValidMove() == false && grid[j,height -2] != null)
                {
                    SceneManager.LoadScene(2);
                }

        }

    }
}