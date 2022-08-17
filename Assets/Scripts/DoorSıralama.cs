using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSıralama : MonoBehaviour
{
    public GameObject[] door;

    public int maxIndex;

    bool doorCheck = false, lengthCheck = true;

    public static int index = -1;

    // Start is called before the first frame update
    void Start()
    {
        index = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyControl.lockIsOpen && index <= maxIndex - 1)
        {
            StartCoroutine(IndexCount());
            

        }
        
    }

    IEnumerator IndexCount()
    {
        yield return new WaitForSeconds(4);
        KeyControl.lockIsOpen = false;
        door[index].SetActive(true);
        
    }

}
