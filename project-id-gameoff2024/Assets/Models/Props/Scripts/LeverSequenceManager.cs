using UnityEngine;

public class LeverSequenceManager : MonoBehaviour
{
    public LeverActives[] leverOrder; 
    private LeverNode head;
    private LeverNode currentNode;

    public GameObject gate; 

    void Start()
    {
        if (leverOrder.Length > 0)
        {
            head = new LeverNode(leverOrder[0]);
            LeverNode current = head;
            for (int i = 1; i < leverOrder.Length; i++)
            {
                current.next = new LeverNode(leverOrder[i]);
                current = current.next;
            }
        }
        currentNode = head; 
    }

    public void CheckLever(LeverActives lever)
    {
        if (currentNode == null) return; 

        if (lever == currentNode.lever)
        {
            currentNode = currentNode.next; 

            if (currentNode == null) 
            {
                UnlockGate();
            }
        }
        else
        {
            ResetLevers();
        }
    }

    private void ResetLevers()
    {
        foreach (LeverActives lever in leverOrder)
        {
            lever.GetComponent<Animator>().SetBool("On", false);
        }
        currentNode = head;
    }

    private void UnlockGate()
    {
        Debug.Log("Gate Unlocked!");
        if (gate) gate.SetActive(false);
    }
}
