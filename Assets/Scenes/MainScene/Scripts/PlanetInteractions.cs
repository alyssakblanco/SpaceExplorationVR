using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PlanetInteractions : MonoBehaviour
{
    public GameObject factsPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI factsText;
    public TextMeshProUGUI funFactsText;
    public TextMeshProUGUI distanceText;
    public GameObject planet;
    public static GameObject current_planet;
    // public string factsDescription;
    public float typingSpeed = 0.05f;
    private Dictionary<string, Planet> planets;

    public void ShowFacts()
    {
        // show the facts canvas
        factsPanel.SetActive(true);

        // set this global variable for the DismissFacts script
        current_planet = planet;


        titleText.text = $"Planet: {planet.name}";
        // StartCoroutine(TypeFacts());
        // Debug.Log(planet.name);
        SetFacts(planet.name);
    }

    IEnumerator TypeFacts(string fact, string funFact, float distance)
    {
        factsText.text = "";
        foreach (char letter in fact.ToCharArray())
        {
            factsText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        funFactsText.text = "";
        foreach (char letter in funFact.ToCharArray())
        {
            funFactsText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        distanceText.text = "";
        string distanceString = "" + distance;
        foreach (char letter in distanceString.ToCharArray())
        {
            distanceText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void SetFacts(string current_planet)
    {
        planets = new Dictionary<string, Planet>{
        { "Mercury", new Planet { 
            Fact = "Mercury is the closest planet to the Sun and the smallest planet in our solar system.", 
            FunFact = "A year on Mercury is just 88 days long!", 
            DistanceFromSun = 57909227 
        } },
        { "Venus", new Planet { 
            Fact = "Venus is very hot and it's the brightest planet in our sky.", 
            FunFact = "Venus spins backwards on its axis compared to most planets.",
            DistanceFromSun = 108209475 
        } },
        { "Earth", new Planet { 
            Fact = "Earth is the only planet where we know there's life.", 
            FunFact = "70% of the Earth’s surface is covered in water.",
            DistanceFromSun = 149597870 
        } },
        { "Mars", new Planet { 
            Fact = "Mars is called the Red Planet because of its reddish color.", 
            FunFact = "Mars has the tallest volcano in the solar system, named Olympus Mons.",
            DistanceFromSun = 227943824 
        } },
        { "Jupiter", new Planet { 
            Fact = "Jupiter is the biggest planet in our solar system.", 
            FunFact = "Jupiter has a giant storm called the Great Red Spot.",
            DistanceFromSun = 778340821 
        } },
        { "Saturn", new Planet { 
            Fact = "Saturn is famous for its beautiful rings.", 
            FunFact = "Saturn is so light, it could float in water!",
            DistanceFromSun = 1426666422 
        } },
        { "Uranus", new Planet { 
            Fact = "Uranus is an ice giant and it spins on its side.", 
            FunFact = "Uranus has faint rings around it.",
            DistanceFromSun = 2870658186
        } },
        { "Neptune", new Planet { 
            Fact = "Neptune is the farthest planet from the Sun in our solar system.", 
            FunFact = "A windy planet, Neptune has the fastest winds in the solar system.",
            DistanceFromSun = 4498396441 
        } }};

        string fact = planets[current_planet].Fact;
        string funFact = planets[current_planet].FunFact;
        float distance = planets[current_planet].DistanceFromSun;

        StartCoroutine(TypeFacts(fact, funFact, distance));

        // Do something with the information
        // Debug.Log("Facts about " + current_planet + ": " + string.Join(", ", fact));
        // Debug.Log("Fun Fact: " + funFact);
        // Debug.Log("Distance from Sun: " + distance + " units");
    }
}

class Planet
{
    public string Fact { get; set; }
    public string FunFact { get; set; }
    public float DistanceFromSun { get; set; }
}
