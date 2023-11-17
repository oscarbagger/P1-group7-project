using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementDelay;
    private float previousMoveTime = 0;
    private TetrisBlock tetrisBlock; // Reference to the TetrisBlock script
    private Hold holdAction; // Reference to the Hold script
    // assign the actions asset to this field in the inspector:
    public InputActionAsset actions;
    // private field to store move action reference
    private InputAction moveAction;
    private AudioManager Playsound;
    private bool Audiodelay = true;

    void Awake()
    {
        holdAction = GetComponent<Hold>();
        // find the "move" action, and keep the reference to it, for use in Update

        Playsound = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

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
        if (moveVector.x == 1 && Time.time - previousMoveTime > movementDelay)
        {
            tetrisBlock.MoveBlockHorizontal(1); // move one position to the right
            previousMoveTime = Time.time;
            Playsound.PlaySFX(Playsound.Move_Block);
        }
        if (moveVector.x == -1 && Time.time - previousMoveTime > movementDelay)
        {
            tetrisBlock.MoveBlockHorizontal(-1); // move one position to the left
            previousMoveTime = Time.time;
            Playsound.PlaySFX(Playsound.Move_Block);
        }
        // set a bool value to move block down faster if our value is -1.
        if (moveVector.y == -1)
        {
            tetrisBlock.moveDown = true;
            
            if (Audiodelay)
            {
                StartCoroutine(SoundDelay());
            }
            
        }
        else
        {
            tetrisBlock.moveDown = false;
        }
    }

    private IEnumerator SoundDelay()
    {
        Playsound.PlaySFX(Playsound.Move_Block);
        Audiodelay = false;

        yield return new WaitForSeconds(0.1f); 
        Audiodelay = true;

    }

    private void OnRotateRight(InputAction.CallbackContext context)
    {
        if (!tetrisBlock.CompareTag("negative"))
        {
            tetrisBlock.Rotate(-90);
            Playsound.PlaySFX(Playsound.Rotate_Block);
        }

    }
    private void OnRotateLeft(InputAction.CallbackContext context)
    {
        if (!tetrisBlock.CompareTag("negative"))
        {
            tetrisBlock.Rotate(90);
            Playsound.PlaySFX(Playsound.Rotate_Block);
        }
    }
    private void OnHold(InputAction.CallbackContext context)
    {
        holdAction.HoldBlock();
        Playsound.PlaySFX(Playsound.sfx4);
    }
    private void OnDrop(InputAction.CallbackContext context)
    {
        tetrisBlock.HardDrop();
        Playsound.PlaySFX(Playsound.HardDrop_Block);
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

