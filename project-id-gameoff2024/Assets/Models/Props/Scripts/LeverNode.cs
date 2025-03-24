using UnityEngine;

public class LeverNode
{
    public LeverActives lever;
    public LeverNode next;

    public LeverNode(LeverActives lever)
    {
        this.lever = lever;
        this.next = null;
    }
}
