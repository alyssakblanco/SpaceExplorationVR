using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlanetInteractions : MonoBehaviour
{
    public GameObject factsPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI factsText;
    public GameObject planet;
    public static GameObject current_planet;
    [TextArea]
    public string factsDescription;
    public float typingSpeed = 0.05f;

    public void ShowFacts()
    {
        // show the facts canvas
        factsPanel.SetActive(true);

        // set this global variable for the DismissFacts script
        current_planet = planet;


        titleText.text = $"Planet: {planet.name}";
        StartCoroutine(TypeFacts());
        // Debug.Log(planet.name);
    }

    IEnumerator TypeFacts()
    {
        factsText.text = "";
        foreach (char letter in factsDescription.ToCharArray())
        {
            factsText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
