using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeScript : MonoBehaviour
{
    public Text welcomeMessageText_NEW2;
    public Text descriptionText_NEW2;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        // ... existing code ...

        // Set the welcome message and description
        welcomeMessageText_NEW2.text = "Welcome to the Solar System Explorer!";
        descriptionText_NEW2.text = "Interact with any planet to learn more about it. Use the primary button to view details and the secondary button to reset the view.";

        // Optionally, hide the messages after a delay
        StartCoroutine(HideWelcomeMessageAfterDelay(5)); // Hide after 5 seconds, for example


    }
    IEnumerator HideWelcomeMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvas.gameObject.SetActive(false);
        //welcomeMessageText.gameObject.SetActive(false);
        //descriptionText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
