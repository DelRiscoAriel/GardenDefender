using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public bool level1_Complete = false;
    public bool level2A_Complete = false;
    public bool level2B_Complete = false;
    public bool level3A_Complete = false;
    public bool level3B_Complete = false;
    public bool level3C_Complete = false;
    public bool level4_Complete = false;

    public GameData(GameManager manager)
    {
        level1_Complete = manager.level1_Complete;
        level2A_Complete = manager.level2A_Complete;
        level2B_Complete = manager.level2B_Complete;
        level3A_Complete = manager.level3A_Complete;
        level3B_Complete = manager.level3B_Complete;
        level3C_Complete = manager.level3C_Complete;
        level4_Complete = manager.level4_Complete;
    }
}
