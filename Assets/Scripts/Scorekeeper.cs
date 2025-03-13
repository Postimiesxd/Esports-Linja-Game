using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    public static Scorekeeper Instance;

    // Start is called before the first frame update
    public int yellow;
    public int purple;
    public int green;

    public int previous;


    
    
    void Start()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject.transform);
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
  
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
        if (yellow == 1 && purple == 1 && green == 1)
        {
            // Victory condition met, load victory scene
            SceneManager.LoadScene("VictoryScene"); // Change "VictoryScene" to your scene name
        }
        else
        {
            SceneManager.LoadScene("MainGameScene");
        }

    }

}
