using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DismissFacts : MonoBehaviour
{
    public GameObject factsPanel;
    private GameObject planet;

    public void HidePanel()
    {
        // hide the facts canvas
        factsPanel.SetActive(false);
    }

    public void StartMotion()
    {
        planet = GameObject.Find(PlanetInteractions.current_planet.name);
        Orbits orbitsScript = planet.GetComponent<Orbits>();
        orbitsScript.enabled = true;
    }
}
