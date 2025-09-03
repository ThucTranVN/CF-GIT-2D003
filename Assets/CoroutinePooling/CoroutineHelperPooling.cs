using System.Collections.Generic;
using UnityEngine;

public class CoroutineHelperPooling : MonoBehaviour
{
    #region Singleton
    // Singleton instance of CoroutineHelperPooling
    private static CoroutineHelperPooling m_instance;
    public static CoroutineHelperPooling Instance
    {
        get
        {
            // If instance is null, create a new GameObject to hold CoroutineHelperPooling
            if (m_instance == null)
            {
                GameObject clone = new GameObject("Coroutine Helper Pooling");
                m_instance = clone.AddComponent<CoroutineHelperPooling>();
            }

            return m_instance;
        }
    }
    #endregion

    // Queue to hold CoroutineHelper instances
    private Queue<CoroutineHelper> m_coroutineHelperPooling = new Queue<CoroutineHelper>();

    // Method to get CoroutineHelper instance from the pool
    public CoroutineHelper GetCoroutineHelperFromPool()
    {
        // If the pool is empty, create a new CoroutineHelper instance
        if (m_coroutineHelperPooling.Count == 0)
        {
            GameObject clone = new GameObject("coroutine");
            clone.transform.SetParent(transform);
            CoroutineHelper coroutineHelper = clone.AddComponent<CoroutineHelper>();
            return coroutineHelper;
        }

        // Otherwise, return an instance from the pool
        return m_coroutineHelperPooling.Dequeue();
    }

    // Method to return CoroutineHelper instance to the pool
    public void ReturnToPool(CoroutineHelper coroutineHelper)
    {
        m_coroutineHelperPooling.Enqueue(coroutineHelper); // Add CoroutineHelper instance back to the pool
    }
}
