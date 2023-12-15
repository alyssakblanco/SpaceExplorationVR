using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PlanetInteractions : MonoBehaviour
{
    public GameObject factsPanel;
    public GameObject planet;
    
    public TextMeshProUGUI planetName;
    public TextMeshProUGUI distanceFromSun;
    public TextMeshProUGUI lengthOfYear;
    public TextMeshProUGUI lengthOfDay;
    public TextMeshProUGUI fact;

    public static GameObject current_planet;
    private float typingSpeed = 0.05f;
    private Dictionary<string, Planet> planets = new Dictionary<string, Planet>{
        { "Mercury", new Planet { 
            Fact = "Mercury’s craters are named after famous artists, musicians and authors.", 
            DistanceFromSun = "57,909,227", 
            LengthOfYear = "~ 87.97 days", 
            LengthOfDay = "58.6 Earth days"
        } },
        { "Venus", new Planet { 
            Fact = "Venus is very hot and it's the brightest planet in our sky.", 
            DistanceFromSun = "108,209,475",
            LengthOfYear = "~ 224.7 days",
            LengthOfDay = "243 Earth days"
        } },
        { "Earth", new Planet { 
            Fact = "70% of the Earth’s surface is covered in water.",
            DistanceFromSun = "149,597,870",
            LengthOfYear = "~ 365.25 days", 
            LengthOfDay = "23 hours, 56 minutes"
        } },
        { "Mars", new Planet { 
            Fact = "Mars has the tallest volcano in the solar system, named Olympus Mons.",
            DistanceFromSun = "227,943,824",
            LengthOfYear = "~ 686.93 days", 
            LengthOfDay = "24 hours, 37 minutes"
        } },
        { "Jupiter", new Planet { 
            Fact = "Jupiter has a giant storm called the Great Red Spot.",
            DistanceFromSun = "778,340,821",
            LengthOfYear = "~ 11.86 years", 
            LengthOfDay = "9 hours, 55 minutes"
        } },
        { "Saturn", new Planet { 
            Fact = "Saturn is so light, it could float in water!",
            DistanceFromSun = "1,426,666,422",
            LengthOfYear = "~ 29.42 years", 
            LengthOfDay = "10 hours, 33 minutes"
        } },
        { "Uranus", new Planet { 
            Fact = "Uranus is an ice giant and it spins on its side.", 
            DistanceFromSun = "2,870,658,186",
            LengthOfYear = "~ 83.75 years",
            LengthOfDay = "17 hours, 14 minutes"
        } },
        { "Neptune", new Planet {  
            Fact = "A windy planet, Neptune has the fastest winds in the solar system.",
            DistanceFromSun = "4,498,396,441",
            LengthOfYear = "~ 163.72 years", 
            LengthOfDay = "15 hours, 57 minutes"
        } }
    };

    public void ShowFacts()
    {
        // show the facts canvas
        factsPanel.SetActive(true);

        // set this global variable for the DismissFacts script
        current_planet = planet;

        TextMeshProUGUI[] textObjects = {planetName, fact, distanceFromSun, lengthOfYear, lengthOfDay};
        foreach (TextMeshProUGUI textMesh in textObjects){textMesh.text = "";}

        StartCoroutine(TypeFacts(textObjects));
    }

    IEnumerator TypeFacts(TextMeshProUGUI[] textObjects)
    {
        for (int i = 0; i < 5; ++i) {
            string currentString = "";
            // Perform different tasks based on the value of i
            switch (i) {
                case 0:
                    currentString = planet.name;
                    break;

                case 1:
                    currentString = planets[current_planet.name].DistanceFromSun;
                    break;

                case 2:
                    currentString = planets[current_planet.name].LengthOfYear;
                    break;

                case 3:
                    currentString = planets[current_planet.name].LengthOfDay;
                    break;
                
                case 4:
                    currentString = planets[current_planet.name].Fact;
                    break;
            }

            foreach (char letter in currentString.ToCharArray())
            {
                textObjects[i].text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    
    }
}

class Planet
{
    public string Fact { get; set; }
    public string DistanceFromSun { get; set; }
    public string LengthOfYear { get; set; }
    public string LengthOfDay { get; set; }
}
