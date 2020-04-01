using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BoxCollider[] places = new BoxCollider[10];

    private GameObject activeObject;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DisplayDialogue(int placeID)
    {
        //other.gameObject = activeObject;
    }
}
