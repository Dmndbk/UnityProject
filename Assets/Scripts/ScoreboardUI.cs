using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardUI : MonoBehaviour
{
    public GameObject panel;
    public GameObject scoreboardUIElementPrefab;
    public Transform elementWrapper;
    List<GameObject> uiElements = new List<GameObject>();

    private void OnEnable()
    {
        ScoreboardHandler.onScoreboardListChanged += UpdateUI;
    }
    private void OnDisable()
    {
        ScoreboardHandler.onScoreboardListChanged -= UpdateUI;
    }
    
    private void UpdateUI(List<ScoreboardElement> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            ScoreboardElement el = list[i];

            if(el.points > 0)
            {
                if (i >= uiElements.Count)
                {
                    var inst = Instantiate(scoreboardUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false);

                    uiElements.Add(inst);
                }
                var texts = uiElements[i].GetComponentsInChildren<Text>();
                texts[0].text = el.playerName;
                texts[1].text = el.points.ToString();
            }
        }
    }
}
