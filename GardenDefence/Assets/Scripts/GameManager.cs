using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 0)]
public class GameManager : ScriptableObject
{
    public bool level1_Complete = false;
    public bool level2A_Complete = false;
    public bool level2B_Complete = false;
    public bool level3A_Complete = false;
    public bool level3B_Complete = false;
    public bool level3C_Complete = false;
    public bool level4_Complete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CompleteLevel(string level)
    {
        if (level == "level1_Complete")
        {
            level1_Complete = true;
        }
        else if (level == "level2A_Complete")
        {
            level2A_Complete = true;
        }
        else if (level == "level2B_Complete")
        {
            level2B_Complete = true;
        }
        else if (level == "level3A_Complete")
        {
            level3A_Complete = true;
        }
        else if (level == "level3B_Complete")
        {
            level3B_Complete = true;
        }
        else if (level == "level3C_Complete")
        {
            level3C_Complete = true;
        }
        else if (level == "level4_Complete")
        {
            level4_Complete = true;
        }
        else
        {
            Debug.Log("Wrong level input");
        }
    }
}
