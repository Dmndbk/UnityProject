using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class TextAnim : MonoBehaviour
{
    public Text currDistText;
    public Text highDistText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        currDistText.text = "0";
        highDistText.text = "0";

        int currDist = 0;
        int highDist = 0;


        yield return new WaitForSeconds(.7f);

        while (currDist < PlayerStats.Distance)
        {
            currDist++;
            currDistText.text = currDist.ToString();

            yield return new WaitForSeconds(.03f);
        }

        while (highDist < PlayerPrefs.GetFloat("HighDistance"))
        {
            highDist++;
            highDistText.text = highDist.ToString();

            yield return new WaitForSeconds(.03f);
        }

    }
}
