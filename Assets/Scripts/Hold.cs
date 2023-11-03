using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Hold : MonoBehaviour
{
    public TMP_Text holdText;
    private static bool hasHeldBlock=false;
    private static bool canHoldNewBlock = true;
    private static int heldIndex;
    public Spawn spawner;

    public void HoldBlock()
    {
        if(canHoldNewBlock)
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
            holdText.text = "Held block:" + heldIndex.ToString();
        }
    }
    public static void SetCanHold()
    {
        canHoldNewBlock = true;
    }

}
