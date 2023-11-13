using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hold : MonoBehaviour
{
    public Image HeldImage;
    private static bool hasHeldBlock=false;
    private static bool canHoldNewBlock = true;
    private static int heldIndex;
    public Spawn spawner;


    public void HoldBlock()
    {
        if(canHoldNewBlock && !spawner.activeBlock.CompareTag("negative"))
        {
            if (hasHeldBlock)
            {
                canHoldNewBlock = false;
                int newheldIndex = spawner.activeBlockIndex;
                Destroy(spawner.activeBlock);
                spawner.NewTetromino(heldIndex);
                heldIndex = newheldIndex;
            }
            else
            {
                canHoldNewBlock = false;
                heldIndex = spawner.activeBlockIndex;
                hasHeldBlock = true;
                Destroy(spawner.activeBlock);
                spawner.NewTetromino();
            }
            HoldImageUpdate();
        }
    }
    public static void SetCanHold()
    {
        canHoldNewBlock = true;
    }

    public void HoldImageUpdate()
    {
        HeldImage.sprite = spawner.previewTetrominos[heldIndex];
        HeldImage.SetNativeSize();
    }

}
