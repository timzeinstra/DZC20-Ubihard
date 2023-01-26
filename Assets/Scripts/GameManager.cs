using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CircuitsHolder;
    public GameObject[] Circuits;

    [SerializeField]
    int totalCiruits = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalCiruits = CircuitsHolder.transform.childCount;

        Circuits = new GameObject[totalCiruits];

        for (int i = 0; i < Circuits.Length; i++)
        {
            Circuits[i] = CircuitsHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
