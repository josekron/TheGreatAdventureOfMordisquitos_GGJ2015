using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    //Public cariables and constants:
    public int forceHorizontal;
    public int forceVertical;
    public int forceVerticalSecondJump;
    public bool doubleJump;


    private int counterJump;
    private bool jump;
    private bool disable;

    public GameObject hamster;

    //Times:
    public float TICK_JUMP_INITIAL = 2f;
    public float TICK_DOUBLE_JUMP_INITIAL = 0.5f;
    private float tiempoLoad = 0;

	private Vector3 startPosition;

	private GameObject globalscripts;

	// Use this for initialization
	void Start () {
		startPosition = gameObject.transform.position;
		globalscripts = GameObject.Find ("GlobalScripts");
        jump = false;
        disable = false;

        if (doubleJump)
        {
            counterJump = 2;
        }
        else {
            counterJump = 1;
        }
	}
	float onesecond;
	// Update is called once per frame
	void Update () {

        if (!disable) {
            controlKeyboard();
        }
        

        activeJump();

        if (Input.GetKeyDown(KeyCode.G))
        {
            disablePlayer(true);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            disablePlayer(false);
        }

        if (globalscripts != null) {
			onesecond += Time.deltaTime;
			if(onesecond >= 1f){
				Debug.Log ("dieAt: " + globalscripts.GetComponent<GridLoader>().dieAt);
				if(globalscripts.GetComponent<GridLoader>().dieAt > gameObject.transform.position.y){
					activeDead();
				}
				onesecond = 0;
			}
		}else{
			if(gameObject.transform.position.y < -10) {
				activeDead();
			}
		}
	}

    void OnCollisionEnter(Collision collision) {

        if (collision.transform.tag.Equals("Floor")) {
            jump = false;
            counterJump = 2;
        }
        
    }

    /*
     * Read keyboard and move player appliying forces
     */
    private void controlKeyboard() {

        if (Input.GetAxis("Horizontal") > 0)
        {
            rigidbody.AddForce(Vector3.right * forceHorizontal);
            HamsterDentroRueda.leftNew = false;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            rigidbody.AddForce(-Vector3.right * forceHorizontal);
            HamsterDentroRueda.leftNew = true;
        }
        if (Input.GetAxis("Vertical") > 0 || Input.GetKeyDown(KeyCode.Space)) {
            if (!jump) {
                jump = true;
                if (doubleJump && counterJump == 1)
                {
                    rigidbody.AddForce(Vector3.up * forceVerticalSecondJump);
                }
                else {
                    rigidbody.AddForce(Vector3.up * forceVertical);
                }
                
            }  
        }
       


    }

 
    private void activeJump() {
        if (jump) {
            
            if (doubleJump)
            {
                if (counterJump > 1)
                {
                    tiempoLoad += Time.deltaTime;
                    if (tiempoLoad > TICK_DOUBLE_JUMP_INITIAL)
                    {
                        counterJump--;
                        jump = false;
                        tiempoLoad = tiempoLoad - TICK_DOUBLE_JUMP_INITIAL;
                    }
                }            
            }

            
        }
    }

    /**
     * Active the dead (animation, etc)
     */
    public void activeDead()
    {
        Debug.Log("Man matao killo");
        //disablePlayer(true);
        //blackScreen.SetActive(true);
		gameObject.rigidbody.velocity = Vector3.zero;
		gameObject.transform.position = startPosition;
    }

    public void disablePlayer(bool action) {
        jump = false;
        counterJump = 2;
        this.disable = action;
    }
}
