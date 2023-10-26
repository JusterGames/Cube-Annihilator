using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Create an integer named cubeSpeed with a random range between 1 and 10 (inclusive)
    int cubeSpeed;
    public int riseSpeed = 0;

     void Start()
    {
       cubeSpeed = Random.Range(1, 10);
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, riseSpeed * Time.deltaTime, 0);
    }

    public void GetCollected()
    {
        // Check the cubeSpeed
        if (cubeSpeed > 6)
        {
            // Turn green (Color.green)
            GetComponent<Renderer>().material.color = Color.green;
            // Disable physics and destroy after 5 seconds
            GetComponent<Rigidbody>().isKinematic = true;
            //  move up by changing riseSpeed to 5
            riseSpeed += 5;
            // destroy self after 5 seconds.
            Destroy(gameObject, 5f);
        }
        else
        {
            // Turn red (Color.red)
            GetComponent<Renderer>().material.color = Color.red;
            // Destroy self after 1 second
            Destroy(gameObject, 1f);
        }
    }
}
