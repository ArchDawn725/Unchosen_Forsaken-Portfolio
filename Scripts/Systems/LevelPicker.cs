using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Steamworks;

public class LevelPicker : MonoBehaviour
{
    public Player player;
    public int levelsWon;

    public GameObject basementPass;
    public GameObject OutsidePass;
    public GameObject EndPass;

    [Header("Levels")]
    public int introLevels;
    public int secondFloorLevels;
    public int basementLevels;
    public int outsideLevels;

    [Header("Random Numbers")]
    public int introNumber;
    public int secondFloorNumber;
    public int basementNumber;
    public int outsideNumber;

    public GameObject basementSounds;
    public GameObject outsideSounds;
    public GameObject endSounds;

    // Start is called before the first frame update
    void Start()
    {
        //before build do this
        //PlayerPrefs.SetInt("levelsWon", 0); // test
        introNumber = Random.Range(1, (introLevels + 1));
        secondFloorNumber = Random.Range(1, (secondFloorLevels + 1));
        basementNumber = Random.Range(1, (basementLevels + 1));
        outsideNumber = Random.Range(1, (outsideLevels + 1));

        player.introNumber = introNumber;
        player.secondFloorNumber = secondFloorNumber;
        player.basementNumber = basementNumber;
        player.outsideNumber = outsideNumber;

        levelsWon = PlayerPrefs.GetInt("levelsWon");

        //0 == secondfloor, 1 == basement, 2 == outside
        if (levelsWon > 0)
        {
            basementPass.SetActive(false);
            basementSounds.SetActive(true);
        }
        if (levelsWon > 1)
        {
            OutsidePass.SetActive(false);
            outsideSounds.SetActive(true);
        }
        if (levelsWon > 2)
        {
            EndPass.SetActive(false);
            endSounds.SetActive(true);
        }

        //Steamworks.SteamUserStats.GetAchievement("tutorial", out tutorialCompleted);
        //Steamworks.SteamUserStats.SetAchievement("tutorial");
    }

    public void IntroTeleport()
    {
        SceneManager.LoadScene("Intro" + introNumber);
    }

    public void SecondFloorTeleport()
    {
        SceneManager.LoadScene("SecondFloor" + secondFloorNumber);
    }

    public void BasementTeleport()
    {
        SceneManager.LoadScene("Basement" + basementNumber);
    }

    public void OutsideTeleport()
    {
        player.leverPulled = true;
        SceneManager.LoadScene("Outside" + outsideNumber);
    }
}
