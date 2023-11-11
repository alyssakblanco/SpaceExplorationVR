using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeScript : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        // Show welcome message for 5 seconds
        StartCoroutine(HideWelcomeMessageAfterDelay(5)); 
    }
    IEnumerator HideWelcomeMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvas.gameObject.SetActive(false);
    }
}
