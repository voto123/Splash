﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/********************************************
 * LastMenuController class
 *  Handles showing scores and looping the game
 */
public class LastMenuController : MonoBehaviour, IController{

    /******************/
    /*Member Variables*/
    private List<WinCards> InstatntiatedStats = new List<WinCards>();
    public GameObject visualStatPrefab;
    private StateHandler state;
    public RectTransform canvas;
    public Button firstSelectedGameObject;



    /************************/
    /*MonoBehavior Functions*/
    //Instantiates visual stats and fill them with player data
    public void Finish()
    {
        state = GameObject.FindGameObjectWithTag("State Handler").GetComponent<StateHandler>();
        state.Sort();
        //initiate a card for each stats object
        for(int i = 0; i < state.stats.Count; i++)
        {
            GameObject temp = Instantiate(visualStatPrefab, transform);
            //position it relative to amount of cards total and canvas size
            //temp.GetComponent<RectTransform>().anchoredPosition = new Vector3((canvas.rect.width / state.stats.Count) * (i + 1) - ((canvas.rect.width / state.stats.Count) / 2), -90, 0);
            switch(state.stats.Count)
            {
                case 1:
                    temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 90, 0);
                    break;
                case 2:
                    temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(canvas.rect.width / 4 * -Mathf.Cos(Mathf.PI/1 * i) , 0, 0);
                    break;
                case 3:
                case 4:
                    temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(canvas.rect.width / 4 * -Mathf.Cos(Mathf.PI / 1 * i), canvas.rect.height / 4 * -Mathf.Sign(i-2), 0);
                    break;
            }
            //Gets wincard script and sets the texts
            InstatntiatedStats.Add(temp.GetComponent<WinCards>());
            InstatntiatedStats[i].player.text = "Player: " + (state.stats[i].player + 1);
            InstatntiatedStats[i].kills.text = "Kills: " + state.stats[i].kills;
            InstatntiatedStats[i].deaths.text = "Deaths: " + state.stats[i].deaths;
            switch(i)
            {
                case 0:
                    InstatntiatedStats[i].ToFirstPlace();
                    break;
                case 1:
                    InstatntiatedStats[i].ToSecondPlace();
                    break;
                case 2:
                    InstatntiatedStats[i].ToThirdPlace();
                    break;
                default:
                    break;
            }
        }
    }



    /*****************/
    /*Implementations*/
    //Implements Icontroller, has no actual function
    public void InputHandle(string[] input)
    { }



    #region Public Functions
    /// <summary>
    /// Calls state changes to main menu
    /// </summary>
    public void MainMenu()
    {
        state.ChangeState(State.MainMenu);
        state.stats.Clear();
    }
    /// <summary>
    /// Calls state change to match
    /// </summary>
    public void Restart()
    {
        state.ChangeState(State.Game);
        state.stats.Clear();
    }
    #endregion
}
