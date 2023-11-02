using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Hold : MonoBehaviour
{
    public TMP_Text holdText;
    private bool hasHeldBlock=false;
    private bool canHoldNewBlock = true;
    private int heldIndex;
    public Spawn spawner;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C) && canHoldNewBlock)
        {
            if (hasHeldBlock)
            {
                canHoldNewBlock = false;
                int newheldIndex = spawner.activeBlockIndex;
                Destroy(spawner.activeBlock);
                spawner.NewTetromino(heldIndex);
                heldIndex = newheldIndex;
            } else
            {
                canHoldNewBlock = false;
                heldIndex = spawner.activeBlockIndex;
                hasHeldBlock = true;
                Destroy(spawner.activeBlock);
                spawner.NewTetromino();
                
            }
            holdText.text ="Held block:"+ heldIndex.ToString();
        }
        if (Input.GetKey(KeyCode.V))
        {
            SetCanHold();
        }
    }
    public void SetCanHold()
    {
        canHoldNewBlock = true;
    }

}
