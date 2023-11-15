using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TetrisBlock : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public static float fallTime = 0.8f;
    public static int height = 22;
    public static int width = 12;
    public static Transform[,] grid = new Transform[width, height];
    public bool moveDown = false;
    AudioManager Audio;
    // Flag for game end
    private bool GameEnd = false;

    // Update is called once per frame
    void Update()
    {
        MoveBlockDown();
    }

    private void Awake()
    {
        Audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        previousTime = Time.time;   // Initialize the previousTime variable
    }

    // Method to move the block horizontally
    public void MoveBlockHorizontal(int movement)
    {
        transform.position += new Vector3(movement, 0, 0);      // Move the block horizontally
        if (!ValidMove())                                       // Check if the move is valid, otherwise, revert the position
            transform.position -= new Vector3(movement, 0, 0);
    }

    // Method to move the block down
    public void MoveBlockDown()
    {
        if (Time.time - previousTime > (moveDown ? fallTime / 10 : fallTime))       // Check if it's time to move the block down
        {
            transform.position += new Vector3(0, -1, 0);                            // Move the block downwards
            if (!ValidMove())                                                       // Check if the move is valid, otherwise, freeze the block
            {
                FreezeBlock();
            }
            previousTime = Time.time;                                               // Update the previous time
        }
    }

    // Method to rotate the block
    public void Rotate(int rotation)
    {
        transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), rotation);    // Rotate the block around the specified rotation point
        if (!ValidMove())                                                                                   // Check if the rotation is valid, otherwise, perform wall kicks for adjustment
        {
            transform.position += new Vector3(1, 0, 0);                                                     // Attempt to move the block to the right
            if (!ValidMove())                                                                               // Check if the adjusted position is valid, otherwise, attempt to move to the left
            {
                transform.position -= new Vector3(2, 0, 0);
                if (!ValidMove())
                {
                    transform.position += new Vector3(1, 0, 0);                                                     // Attempt to move the block to the right
                    transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -rotation);    // Rotate the block around the specified rotation point

                }
            }
        }
    }

    // Method for hard dropping the block
    public void HardDrop()
    {
        while (ValidMove())                               // Move the block down until it's not a valid move
        {
            transform.position += new Vector3(0, -1, 0);
        }
        FreezeBlock();                                    // After reaching the lowest possible position, call on FreezeBlock method
    }

    // Method for freezing the block
    public void FreezeBlock()
    {
        transform.position -= new Vector3(0, -1, 0);            // Adjust to return to last valid position
        AddToGrid();                                            // Add the block to the grid, check for completed lines, and update game state
        CheckLines();
        gameOver();
        Hold.SetCanHold();
        FindObjectOfType<StressLevel>().UpdateStressLevel();

        this.enabled = false;                                   // Disable this script and spawn a new tetromino
        FindObjectOfType<Spawn>().NewTetromino();
    }

    // Method to check for completed lines
    void CheckLines()
    {
        for (int i = height - 1; i >= 0; i--)         // Iterate through each row from bottom to top
        {
            if (HasLine(i))                          // Check if the current row has a complete line
            {
                DeleteLine(i);                      // If a complete line is found, delete it and shift rows down
                RowDown(i+1);
            }
        }
    }

    // Method to check if the specified row has a complete line
    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)       // Iterate through each cell in the row
        {
            if (grid[j, i] == null)         // Check if any cell is empty (null), indicating the line is not complete
                return false;
        }
        return true;                        // All cells in the row are occupied, indicating a complete line
    }

    // Method to delete the specified complete line
    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)           // Iterate through each cell in the complete line
        {
            if (IsNegative(grid[j, i].gameObject) == false) // check if game object is not a negative block
            {
                Destroy(grid[j, i].gameObject);       // Destroy the game object in the grid cell and set it to null
                grid[j, i] = null;
            }

        }
    }
    // Method to check if an object is part of a negative block
    private bool IsNegative(GameObject obj)
    {
        if (obj.CompareTag("negative"))
        {
            Debug.Log("negative found");
            return true;
        }
        else return false;
    }

    // Method to shift rows down starting from the specified row index
    void RowDown(int i)
    {
        for (int y = i; y < height; y++)                                        // Iterate through each row starting from the specified index
        {
            for (int j = 0; j < width; j++)                                     // Iterate through each cell in the row
            {
                if (grid[j, y] != null && grid[j, y - 1]==null)                 // If the cell is occupied, move the block in the row above down
                {
                    grid[j, y - 1] = grid[j, y];                                // Shift the block and update its position in the grid
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    // Method to add the current block's children to the game grid
    void AddToGrid()
    {
        foreach (Transform children in transform)                               // Iterate through each child of the current block
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);     // Round the child's position to integers
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;                                // Add the child to the grid at the rounded position
        }
    }

    // Method to check if the current move is valid within the game grid
    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);                  // Round the child's position to integers
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)      // Check if the rounded position is within the grid boundaries
            {
                return false;                                                                // The move is invalid if the position is outside the grid
            }

            if (grid[roundedX, roundedY] != null)                                            // Check if the grid cell at the rounded position is already occupied
                return false;                                                                // The move is invalid if the cell is already occupied
        }
        return true;                                                                         // The move is valid if all child positions are within the grid and unoccupied
    }

    // Method to check if the game is over based on the block's position
    void gameOver()
    {
        for (int j = 0; j < width; j++)
        {
            if (ValidMove() == false && grid[j, height - 2] != null)          // Check if the current move is not valid and the second-to-last row is occupied
            {

                SceneManager.LoadScene(2);
                // If conditions are met, reload the scene (indicating game over)

                Audio.Gameover();
            }

        }

    }
}