using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHelper : MonoBehaviour
{
    // Static method to call coroutines and return their associated GameObjects
    public static List<GameObject> Call(params IEnumerator[] coroutines)
    {
        // List to store GameObjects associated with the coroutines
        List<GameObject> goCoroutines = new List<GameObject>();

        // Check if no coroutines are provided
        if (coroutines == null || coroutines.Length == 0)
        {
            return goCoroutines; // Return empty list
        }

        // Loop through provided coroutines
        for (int i = 0; i < coroutines.Length; i++)
        {
            // Get CoroutineHelper instance from the pooling system
            CoroutineHelper helper = CoroutineHelperPooling.Instance.GetCoroutineHelperFromPool();
            // Activate the GameObject associated with the CoroutineHelper
            helper.gameObject.SetActive(true);
            // Start the coroutine and add its associated GameObject to the list
            helper.Do(coroutines[i]);
            goCoroutines.Add(helper.gameObject);
        }

        return goCoroutines; // Return list of GameObjects
    }

    // Method to start coroutine
    private void Do(IEnumerator coroutine)
    {
        StartCoroutine(Wait(coroutine));
    }

    // Method to wait for coroutine to finish
    private IEnumerator Wait(IEnumerator coroutine)
    {
        yield return StartCoroutine(coroutine); // Start the provided coroutine
        gameObject.SetActive(false); // Deactivate the GameObject associated with this coroutine
        CoroutineHelperPooling.Instance.ReturnToPool(this); // Return CoroutineHelper instance to the pooling system
    }
}
