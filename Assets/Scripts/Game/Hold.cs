using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this script handles the hold mechanic of the tetris gameplay.
public class Hold : MonoBehaviour
{
    public Image HeldImage; // image to show the held block
    private static bool hasHeldBlock=false;
    private static bool canHoldNewBlock = true;
    private static int heldIndex; // index of currently held block
    public Spawn spawner;

    public void HoldBlock()
    {
        // check if player is able to hold a new block, and make sure the block player is trying to hold is not a negative block
        if (canHoldNewBlock && !spawner.activeBlock.CompareTag("negative")) 
        {
            canHoldNewBlock = false;

            if (hasHeldBlock)
            {
                int newheldIndex = spawner.activeBlockIndex; // save the index of currently active block
                Destroy(spawner.activeBlock); // destroy cuurently active block that player is controlling
                spawner.NewTetromino(heldIndex); // spawn new block with the index of the held block
                heldIndex = newheldIndex; // update index of block player is holding
            }
            else
            {
                heldIndex = spawner.activeBlockIndex; // update index of block player is holding
                hasHeldBlock = true;
                Destroy(spawner.activeBlock);
                spawner.NewTetromino();
            }
            HoldImageUpdate(); // update the held image
        }
    }
    // call this method to set the player able to hold a new block
    public static void SetCanHold()
    { 
        canHoldNewBlock = true;
    }

    public void HoldImageUpdate()
    { // change image to match the block being held and set it's size and color
        HeldImage.sprite = spawner.previewTetrominos[heldIndex];
        HeldImage.SetNativeSize();
        HeldImage.color = new Color(1, 1, 1, 1);
    }

}
