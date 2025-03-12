using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    // Start is called before the first frame update
    public int yellow;
    public int purple;
    public int green;

    public int previous;
    
    
    void Start()
    {
        DontDestroyOnLoad(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckWhichTaskYouJustDidIDK(int tasknumber)
    {
        if (previous == tasknumber)
        {
            // Nyt kun ollaan t‰ss‰ sis‰ll‰, niin tiedet‰‰n ett‰ JOTAIN halutaan miinustaa. 
            // Lis‰‰ sekaista if-purkkaa:
            // 1=keltanen palkki, 2 = liila, 3 = vihre‰
            if (tasknumber == 1)
            {
                yellow = yellow - 1;
            }
            else if (tasknumber == 2)
            {
                purple = purple - 1;
            } else if (tasknumber == 3)
            {
                green = green - 1;
            }
        } else {
            if (tasknumber == 1)
            {
                yellow = yellow + 1;
            }
            else if (tasknumber == 2)
            {
                purple = purple + 1;
            }
            else if (tasknumber == 3)
            {
                green = green + 1;
            }
        }
        previous = tasknumber;
    }

}
