using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leveler : MonoBehaviour
{
    [SerializeField] private List<Transform> level_part;
    [SerializeField] private Transform player;

    private Vector3 lastEndPosition;

    private int counter = 0;

    public float Player_distance;

    private void Awake() {
        lastEndPosition = level_part[0].Find("End").position;
        setLevels();
    }

    private void setLevels()
    {
        for(int i=1; i<5; i++)
        {
            level_part[i].transform.position = lastEndPosition;
            lastEndPosition = level_part[i].Find("End").position;
        }
    }

    private void Update() 
    {
        if (Vector3.Distance(player.position, lastEndPosition) < Player_distance)
        {
            reposition();
        }
    }

    private void reposition() 
    {
        level_part[counter].transform.position = lastEndPosition;
        lastEndPosition = level_part[counter].Find("End").position;
        if (counter == 4) counter = 0;
        else counter++;
    }
    
}
