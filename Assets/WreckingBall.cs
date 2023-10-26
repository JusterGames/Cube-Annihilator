using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    [SerializeField]
    private float returnDelay = 1;
    [SerializeField]
    private float launchForce = 30;
    [SerializeField]
    private float returnIntervalInSeconds = 2;
    [SerializeField]
    AnimationCurve curve;


    private Rigidbody rb;
    private Transform ballStart;
    private bool readyToLaunch = true;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ballStart = GameObject.Find("BallStart").transform;
    }

    //remove this when attaching to player ship
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && readyToLaunch)
        {
            Launch();
        }
        if( readyToLaunch)
        {
            this.transform.position = ballStart.position;
            this.transform.rotation = ballStart.rotation;
        }
    }

    public bool IsReadyToLaunch()
    {
        return readyToLaunch;
    }

    public Transform GetBallStartTransform()
    {
        return ballStart;
    }
    
    public void Launch()
    {
        Debug.Log("Launching");
        readyToLaunch = false;
        StartCoroutine(Return());
        rb.isKinematic = false;
        rb.AddForce(ballStart.forward * launchForce, ForceMode.Impulse);
    }

    private IEnumerator Return()
    {
        yield return new WaitForSeconds(returnDelay);
        rb.isKinematic = true;
        // lerp back to start position
        //this.transform.localPosition = new Vector3(0, 0, 0);
       // this.transform.localRotation = Quaternion.identity;

        float counter = 0;
        Vector3 startPosition = this.transform.position;
        //Vector3 endPosition = ballStart.position;

        Quaternion startRotation = this.transform.rotation;

        while(counter < 1)
        {
            counter += Time.deltaTime / returnIntervalInSeconds;
            this.transform.position = Vector3.Lerp(startPosition, ballStart.position, curve.Evaluate(counter));
            this.transform.rotation = Quaternion.Lerp(startRotation, ballStart.rotation, curve.Evaluate(counter));

            yield return new WaitForEndOfFrame();
        }

        readyToLaunch = true;
    }
}
