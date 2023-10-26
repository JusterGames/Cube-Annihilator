using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipInput : MonoBehaviour
{
    [SerializeField] 
    private ShipCamera shipCam;
    [SerializeField]
    private WreckingBall wreckingBall;

    private ShipMovement shipMove;
     // Start is called before the first frame update
    void Start()
    {
        if(shipCam == null) shipCam = this.gameObject.GetComponent<ShipCamera>();
        shipMove = this.GetComponent<ShipMovement>();
        if(wreckingBall == null) wreckingBall = this.gameObject.GetComponent<WreckingBall>();

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)) shipCam.ZoomOut();
        if(Input.GetKeyUp(KeyCode.Mouse1)) shipCam.DefaultZoom();

        if(Input.GetKeyDown(KeyCode.Mouse0) && wreckingBall.IsReadyToLaunch())
        {
            wreckingBall.Launch();
        }
        if(wreckingBall.IsReadyToLaunch())
        {
            wreckingBall.transform.position = wreckingBall.GetBallStartTransform().position;
            wreckingBall.transform.rotation = wreckingBall.GetBallStartTransform().rotation;
        }
    }
     
    void FixedUpdate()
    {
        shipMove.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
