using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementDelay;
    private float previousMoveTime=0;
    private TetrisBlock tetrisBlock; // Reference to the TetrisBlock script
    private Hold holdAction; // Reference to the Hold script
    // assign the actions asset to this field in the inspector:
    public InputActionAsset actions;
    // private field to store move action reference
    private InputAction moveAction;

    void Awake()
    {
        holdAction = GetComponent<Hold>();
        // find the "move" action, and keep the reference to it, for use in Update
        moveAction = actions.FindActionMap("gameplay").FindAction("Move");
        //  Add a callback method for when different actions are performed
        actions.FindActionMap("gameplay").FindAction("RotateRight").performed += OnRotateRight;
        actions.FindActionMap("gameplay").FindAction("RotateLeft").performed += OnRotateLeft;
        actions.FindActionMap("gameplay").FindAction("Drop").performed += OnDrop;
        actions.FindActionMap("gameplay").FindAction("Hold").performed += OnHold;
    }
    void Update()
    {

        GetBlock();
        // Read the "move" action value each frame
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        // move block according the value read in moveVector, only if enough time has passed since last movement.
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
        // set a bool value to move block down faster if our value is -1.
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
        // get the currently active blocks TetrisBlock script
        tetrisBlock = FindObjectOfType<Spawn>().activeBlock.GetComponent<TetrisBlock>();
    }
    // enable and disable the actionmap.
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

