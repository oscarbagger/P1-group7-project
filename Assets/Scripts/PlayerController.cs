using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementDelay;
    private float previousMoveTime=0;
    private TetrisBlock tetrisBlock; // Reference to the TetrisBlock script
    private Hold holdAction;

    // assign the actions asset to this field in the inspector:
    public InputActionAsset actions;

    // private field to store move action reference
    private InputAction moveAction;

    void Awake()
    {
        holdAction = GetComponent<Hold>();
        // find the "move" action, and keep the reference to it, for use in Update
        moveAction = actions.FindActionMap("gameplay").FindAction("Move");

        // for the "jump" action, we add a callback method for when it is performed
        actions.FindActionMap("gameplay").FindAction("RotateRight").performed += OnRotateRight;
        actions.FindActionMap("gameplay").FindAction("RotateLeft").performed += OnRotateLeft;

        actions.FindActionMap("gameplay").FindAction("Drop").performed += OnDrop;
        actions.FindActionMap("gameplay").FindAction("Hold").performed += OnHold;


    }
    void Update()
    {
        GetBlock();
        // our update loop polls the "move" action value each frame
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        //Debug.Log(moveVector);
        if (moveVector.x==1 && Time.time-previousMoveTime>movementDelay)
        {
            tetrisBlock.MoveBlockHorizontal(1);
            previousMoveTime = Time.time;
        }
        if (moveVector.x ==-1 && Time.time - previousMoveTime > movementDelay)
        {
            tetrisBlock.MoveBlockHorizontal(-1);
            previousMoveTime = Time.time;
        }
        if (moveVector.y==-1)
        {
            tetrisBlock.moveDown = true;
        } else
        {
            tetrisBlock.moveDown = false;
        }
    }

    private void OnRotateRight(InputAction.CallbackContext context)
    {
        tetrisBlock.Rotate(-90);
    }
    private void OnRotateLeft(InputAction.CallbackContext context)
    {
        tetrisBlock.Rotate(90);
    }
    private void OnHold(InputAction.CallbackContext context)
    {
        holdAction.HoldBlock();
    }
    private void OnDrop(InputAction.CallbackContext context)
    {
        tetrisBlock.HardDrop();
    }
    private void GetBlock()
    {
        tetrisBlock = FindObjectOfType<Spawn>().activeBlock.GetComponent<TetrisBlock>();
    }
    void OnEnable()
    {
        actions.FindActionMap("gameplay").Enable();
    }
    void OnDisable()
    {
        actions.FindActionMap("gameplay").Disable();
    }
    /*  Kode virker ikke endnu, men er gemt her for nu

    private TetrisBlock tetrisBlock; // Reference to the TetrisBlock script

    private void Update()
    {
        if (tetrisBlock == null)
        {
            // Find the TetrisBlock script if it's not set
            tetrisBlock = FindObjectOfType<TetrisBlock>();
        }

        if (tetrisBlock == null)
        {
            Debug.LogError("TetrisBlock script not found.");
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tetrisBlock.MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            tetrisBlock.MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            tetrisBlock.HardDrop();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tetrisBlock.Rotate();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            tetrisBlock.MoveDown();
        }
    }
    */
}

