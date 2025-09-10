using System.Collections;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public int xIndex;
    public int yIndex;

    private bool isMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move((int)transform.position.x + 1, (int)transform.position.y, 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move((int)transform.position.x - 1, (int)transform.position.y, 0.5f);
        }
    }

    public void SetCoord(int x, int y)
    {
        xIndex = x;
        yIndex = y;
    }

    public void Move(int destinationX, int destinationY, float timeToMove)
    {
        if (!isMoving)
        {
            StartCoroutine(MoveRoutine(new Vector3(destinationX, destinationY, 0), timeToMove));
        }
    }

    private IEnumerator MoveRoutine(Vector3 destination, float timeToMove)
    {
        Vector3 startPosition = transform.position;

        bool reachedDestionation = false;

        float elapsedTime = 0f;

        isMoving = true;

        while (!reachedDestionation)
        {
            if(Vector3.Distance(transform.position, destination) < Mathf.Epsilon)
            {
                reachedDestionation = true;
                transform.position = destination;
                SetCoord((int)destination.x, (int)destination.y);
            }

            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp(elapsedTime / timeToMove, 0f, 1f);

            //t = Mathf.Sin(t * Mathf.PI * 0.5f); //Ease out

            //t = 1 - Mathf.Cos(t * Mathf.PI * 0.5f); //Ease in

            //t = t * t * (3 - 2 * t); //SmoothStep

            t = t * t * t * (t * (t * 6 - 15f) + 10f); //Smoother Step

            transform.position = Vector3.Lerp(startPosition, destination, t);

            yield return null;
        }

        isMoving = false;
    }
}
