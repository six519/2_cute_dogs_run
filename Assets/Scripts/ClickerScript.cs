using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        BidaScript bs = GameObject.Find("bida").GetComponent<BidaScript>();
        bs.Jump();
    }
}
