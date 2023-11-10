using UnityEngine;
using UnityEngine.UI; // Make sure to include this if you're using UI elements like Text or Button

public class PlanetInteractions : MonoBehaviour
{
    public GameObject factsPanel; // Assign this in the inspector with your UI panel that contains the facts
    // public Button dismissButton; // Assign a button to dismiss the facts

    private void Start()
    {
        // Hide the facts panel initially
        factsPanel.SetActive(false);
        // dismissButton.SetActive(false);

        // Add a listener to your dismiss button
        // dismissButton.onClick.AddListener(DismissFacts);
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     // Assuming 'other' is the user's interaction component, like a hand or a pointer
    //     if (other.CompareTag("Player")) // Make sure your player has the tag "Player"
    //     {
    //         // Show the facts panel
    //         factsPanel.SetActive(true);
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     // Optionally, you can automatically hide the facts when the user backs away
    //     if (other.CompareTag("Player"))
    //     {
    //         DismissFacts();
    //     }
    // }
    public void ShowFacts()
    {
        // Hide the facts panel
        factsPanel.SetActive(true);
        // dismissButton.SetActive(true);

        // Here you can also restart any motion or interaction that was paused
    }

    public void DismissFacts()
    {
        // Hide the facts panel
        factsPanel.SetActive(false);
        // dismissButton.SetActive(false);

        // Here you can also restart any motion or interaction that was paused
    }
}

