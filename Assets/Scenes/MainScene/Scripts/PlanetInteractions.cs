using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetInteractions : MonoBehaviour
{
    public GameObject factsPanel;
    public GameObject planet;
    public static GameObject current_planet;
    private TextMeshProUGUI titleText; 

    public void ShowFacts()
    {
        // show the facts canvas
        factsPanel.SetActive(true);

        // set this global variable for the DismissFacts script
        current_planet = planet;

        // finding & setting each text object
        titleText = factsPanel.GetComponentInChildren<TextMeshProUGUI>();

        titleText.text = $"Planet: {planet.name}"; 
        // Debug.Log(planet.name);
    }
}
