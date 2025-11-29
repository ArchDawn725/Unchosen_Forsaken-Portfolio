using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    public int monstersFar;
    public int monstersMid;
    public int monstersClose;

    public GameObject noneHeart;
    public GameObject farHeart;
    public GameObject midHeart;
    public GameObject closeHeart;
    public GameObject deathHeart;
    public GameObject startHeart;

    public bool inDeath;
    public bool inStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inDeath)
        {
            noneHeart.SetActive(false);
            farHeart.SetActive(false);
            midHeart.SetActive(false);
            closeHeart.SetActive(false);
            deathHeart.SetActive(true);
            startHeart.SetActive(false);
        }
        else if (inStart)
        {
            noneHeart.SetActive(false);
            farHeart.SetActive(false);
            midHeart.SetActive(false);
            closeHeart.SetActive(false);
            deathHeart.SetActive(false);
            startHeart.SetActive(true);
        }
        else
        {
            if (monstersClose > 0)
            {
                noneHeart.SetActive(false);
                farHeart.SetActive(false);
                midHeart.SetActive(false);
                closeHeart.SetActive(true);
                deathHeart.SetActive(false);
                startHeart.SetActive(false);
            }
            else
            {
                if (monstersMid > 0)
                {
                    noneHeart.SetActive(false);
                    farHeart.SetActive(false);
                    midHeart.SetActive(true);
                    closeHeart.SetActive(false);
                    deathHeart.SetActive(false);
                    startHeart.SetActive(false);
                }
                else
                {
                    if (monstersFar > 0)
                    {
                        noneHeart.SetActive(false);
                        farHeart.SetActive(true);
                        midHeart.SetActive(false);
                        closeHeart.SetActive(false);
                        deathHeart.SetActive(false);
                        startHeart.SetActive(false);
                    }
                    else
                    {
                        noneHeart.SetActive(true);
                        farHeart.SetActive(false);
                        midHeart.SetActive(false);
                        closeHeart.SetActive(false);
                        deathHeart.SetActive(false);
                        startHeart.SetActive(false);
                    }
                }
            }
        }

        if (monstersClose < 0)
        {
            monstersClose = 0;
        }

        if (monstersMid < 0)
        {
            monstersMid = 0;
        }

        if (monstersFar < 0)
        {
            monstersFar = 0;
        }
    }
}
