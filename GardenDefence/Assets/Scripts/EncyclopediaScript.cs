using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaScript : MonoBehaviour
{
    public GameObject benefits;
    public GameObject stats;

    bool change = true;

    public void Switch()
    {
        if (change)
        {
            benefits.SetActive(true);
            stats.SetActive(false);
            change = !change;
        }
        else
        {
            benefits.SetActive(false);
            stats.SetActive(true);
            change = !change;
        }
    }
}
