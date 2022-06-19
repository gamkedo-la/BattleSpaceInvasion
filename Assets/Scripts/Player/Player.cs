using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject[] robotShootFrame;

    public GameObject jetEngineParticle;
    public GameObject robotEngineParticle;

    public ParticleSystem shieldEffect;

    private int robotShootFrameNumber = 0;
    private SpriteRenderer spriteRenderer;

    private bool debugSpeedOn = false;
    private float debugSpeed = 10.0f;
    private float speed = 2.5f;
    private float speed_modifier = 1.0f;

   

    [SerializeField]
    private GameObject _laserPrefab;
    private GameObject _originalLaserPrefab;

    [SerializeField]
    private float _fireRate = 0.4f;
    //private float _fireRateBot = 0.1f;
    //private float _recoilTime = 0.059f;
    private float _recoilTime = 0.005f;
    private float nextFire = -1f;

    [SerializeField]
    private AudioClip laser1Sound;
    //[SerializeField]
    private AudioSource audioSource;
    [SerializeField] GameObject audioManagerGO;
    private AudioManager audioManager;

    [SerializeField]
    private int playerLives = 5;
    public delegate void PlayerLivesChanged(int newLivesValue);
    public PlayerLivesChanged playerLivesChanged;

    // screen markers
    public Transform leftMarker;
    public Transform rightMarker;
    public Transform topMarker;
    public Transform bottomMarker;

    // derive boundary values
    private float leftEdge;
    private float rightEdge;
    private float topEdge;
    private float bottomEdge;

    // shield flag
    static public bool shieldActive = false;
    private bool shieldCoolDownDone = true;
    private float shieldActiveTimer = 0.0f;
    private float shieldActiveTimerMax = 2.0f; // this can be tweaked, will try to have it visible to the editor

    private float shieldCoolDownTimer = 0.0f;

    private float shieldCoolDownTimerMax = 1.0f;

    //animation to midbot
    private Animator anim;
    private bool isBotMode = false;
    public bool robotWalkLevel = false; // check box if its a walking level

    //public static bool robotMode = false;

    static public Vector3 currentPos;


    //ROBOT energy variable
    [SerializeField]
    private float robotEnergy = 20.0f;

    [SerializeField]
    private float fireMissileEnergyConsumption = 15f;

    //SPAWN MANAGER
    private SpawnManager spawnManager;


    //DRONE1 
    private bool isDrone1Active = false;
    public GameObject drone1;
    public GameObject drone2;

    // Start is called before the first frame update
    void Start()
    {
        audioManagerGO = GameObject.FindGameObjectWithTag("SceneManager");
        audioManager = audioManagerGO.GetComponent<AudioManager>();
        for (int i = 0; i< robotShootFrame.Length; i++)
        {
            robotShootFrame[i].SetActive(false);
        }
        robotShootFrameNumber = robotShootFrame.Length;

        spriteRenderer = gameObject.GetComponent <SpriteRenderer>();

        leftEdge = leftMarker.position.x;
        rightEdge = rightMarker.position.x;
        topEdge = topMarker.position.y;
        bottomEdge = bottomMarker.position.y;

        audioSource = GetComponent<AudioSource>();
        transform.position = new Vector3(-7f, 2.25f, 0);

        /*
        if(audioSource == null)
        {
            Debug.LogError("AudioSource on JETSPACESHIP is NULL");
        }
        else
        {
            audioSource.clip = laser1Sound;
        }
        */

        anim = GetComponent<Animator>();

        ChangeToRobotMode(isBotMode, true);

       //spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        //if (spawnManager == null)
        //{
          //  Debug.LogError("The Spawn Manager is NULL.");

//        }


    }

    public void PlayAudioClip(string sound)
    {
        audioManager.Play(sound);
    }


    //

    void ChangeToRobotMode(bool toRobot, bool skipAnimation = false)
    {
        isBotMode = toRobot;
        if (toRobot)
        {
            jetEngineParticle.SetActive(false);
            robotEngineParticle.SetActive(true);
            if(skipAnimation == false)
            {
                anim.Play("JetToRobot");
            }
            //robotMode = true;

        }
        else
        {
            jetEngineParticle.SetActive(true);
            robotEngineParticle.SetActive(false);
            if(skipAnimation == false)
            {
                anim.Play("RobotToJet");
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            PlayerDamage();
        }

        currentPos = transform.position;
        if (isBotMode && robotWalkLevel)
        {
            transform.Translate(Vector3.up * -2.0f * Time.deltaTime);
        }
        jetMovement();
        if (Input.GetKeyDown(KeyCode.Space)  && Time.time > nextFire && isBotMode == false)
        {
            nextFire = Time.time + _fireRate;          
            fireLaser();
            
        }

        
        // check if shield button is pressed
        
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            if (shieldCoolDownDone) {
                shieldActive = true;
            }
        } else 
        {
            shieldActive = false;
        }

        if (Input.GetKey(KeyCode.Tab)) {
            debugSpeedOn = !debugSpeedOn;
        }

        if (shieldActive)
        {
            shieldActiveTimer += Time.deltaTime;
            if (shieldActiveTimer >= shieldActiveTimerMax) {
                shieldActiveTimer = 0.0f;
                shieldActive = false;
                shieldCoolDownDone = false;
            }
            
        }

        if (!shieldCoolDownDone) {
            shieldCoolDownTimer += Time.deltaTime;
            if (shieldCoolDownTimer >= shieldCoolDownTimerMax) {
                shieldCoolDownDone = true;
                shieldCoolDownTimer = 0.0f;
            }
        }
        var shieldEmitter = shieldEffect.emission;
        if (shieldEmitter.enabled != shieldActive) {
            shieldEmitter.enabled = shieldActive;
        }

        //Below are our test keys for jumping scenes for test cases. 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Reminder: Making this call requires using "using UnityEngine.SceneManagement;"
            SceneManager.LoadScene("IntroStory");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("GalaxyNebula");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("MotherShip");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("JungleLevel");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("CaveLevel");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("CharacterScene");
        }



        if (Input.GetKeyDown("q") && isBotMode == false)
        {
            ChangeToRobotMode(true);
            //anim.Play("JetMidBot");
           

        }
        

        else if (Input.GetKeyDown("e") && isBotMode)
        {
            ChangeToRobotMode(false);
            //  anim.Play("MidBotJet");
           
        }

        if (Input.GetKeyDown("r") && isBotMode == true)
        {
            ChangeToRobotMode(true);

            if (robotEnergy > fireMissileEnergyConsumption && robotEnergy != 15)
            {
               robotEnergy = robotEnergy - fireMissileEnergyConsumption;

                anim.Play("RobotFireMissile");
            }
            else if (robotEnergy >= fireMissileEnergyConsumption)
            {
                anim.Play("RobotFireMissile");
                //robotEnergy = robotEnergy;
                //anim.Play("RobotToJet");

            }
           
        }



        if (Time.time > nextFire && robotShootFrameNumber < robotShootFrame.Length)
        {
            
            robotShootFrame[robotShootFrameNumber].SetActive(false);
            robotShootFrameNumber++;
            if(robotShootFrameNumber < robotShootFrame.Length)
            {
                robotShootFrame[robotShootFrameNumber].SetActive(true);
                nextFire = Time.time + _recoilTime;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isBotMode == true)
        {

            //isBotMode = true;
           
            fireLaser();
            robotEnergy--;
            spriteRenderer.color = Color.clear;
            robotShootFrameNumber = 0;
            robotShootFrame[robotShootFrameNumber].SetActive(true);

            nextFire = Time.time + _recoilTime;
            //nextFire = Time.time + _fireRateBot;
            // anim.Play("RobotFlightLaser");           
        }
        else
        {
            if(robotEnergy <= 0)
            {
                //Debug.Log("Out of energy go back to jet");
                ChangeToRobotMode(false);
            }

        }

    }

    void jetMovement()
    {
       
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * moveX * getTotalSpeed() * Time.deltaTime);
        transform.Translate(Vector3.up * moveY * getTotalSpeed() * Time.deltaTime);

        if(moveX < 0.0f && isBotMode)
        {
            Vector3 newScale = transform.localScale;
            if(newScale.x > 0.0f)
            {
                newScale.x *= -1.0f;
                transform.localScale = newScale;
            }
        }
        if (moveX > 0.0f || isBotMode == false)
        {
            Vector3 newScale = transform.localScale;
            if (newScale.x < 0.0f)
            {
                newScale.x *= -1.0f;
                transform.localScale = newScale;
            }
        }

        if ( transform.position.x >= rightEdge)
        {
            transform.position = new Vector3(rightEdge, transform.position.y, 0);
        } else if ( transform.position.x <= leftEdge)
        {
            transform.position = new Vector3(leftEdge, transform.position.y, 0);
        }
        if ( transform.position.y >= topEdge )
        {
            transform.position = new Vector3(transform.position.x, topEdge, 0);
        } else if(transform.position.y <= bottomEdge)
        {
            transform.position = new Vector3(transform.position.x, bottomEdge, 0);
        }

        
    }

    void fireLaser()
    {
        Vector3 rotationVector = new Vector3(0, 0, 180);
        GameObject laser = (GameObject)Instantiate(_laserPrefab, transform.position + new Vector3(0.0f, 0, 0), Quaternion.Euler(rotationVector)); //2.21 new vector
        if(transform.localScale.x < 0.0f)
        {
           
            Laser laserScript = laser.GetComponent<Laser>();
            laserScript.moveLeft = true;
            //if (laserScript.moveLeft)
            //{
            //   Instantiate(_laserPrefab, transform.position + new Vector3(-2.20f, 0, 0), Quaternion.Euler(rotationVector));
            //}

            
            
        }

        PlayAudioClip("laser1");
        //audioSource.Play();


    }

    float getTotalSpeed()
    {
        if (debugSpeedOn) {
            return debugSpeed * speed_modifier;
        }
        return speed * speed_modifier;
    }

    void resetSpeedModifier()
    {
        speed_modifier = 1.0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "power_up")
        {
            Power_Up power_up = other.gameObject.GetComponent<Power_Up_Display>().power_up;
            if (power_up != null)
            {
                if (power_up.category == Power_Up.PowerUpCategory.Speed)
                {
                    this.speed_modifier = power_up.multiplier; 
                }
                else if (power_up.category == Power_Up.PowerUpCategory.Weapon && power_up.weapon_prefab != null)
                {
                    this._originalLaserPrefab = this._laserPrefab;
                    this._laserPrefab = power_up.weapon_prefab;
                }
            }

            Destroy(other.gameObject);
        }
    }

    public void Drone1Active()
    {
        isDrone1Active = true;
        drone1.SetActive(true);
        drone2.SetActive(true);
        Drone1 droneScript = drone1.GetComponent<Drone1>();
        droneScript.StartFiring();
        droneScript = drone2.GetComponent<Drone1>();
        droneScript.StartFiring();
        StartCoroutine(Drone1PowerDown());
    }


    IEnumerator Drone1PowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        drone1.SetActive(false);
        drone2.SetActive(false);
        isDrone1Active = false;
    }



    public void PlayerDamage()
    {
        if (!shieldActive) // only take damage if shield is down...this is a bit broad right now
        {
            playerLives--;
            playerLivesChanged?.Invoke(playerLives);
            //Debug.Log("lost a life! now have " + playerLives + "lives");
            if (playerLives < 1)
            {
                //spawnManager.PlayerDies();
                // Destroy(this.gameObject);
                SpriteRenderer[] allRenderers = GetComponentsInChildren<SpriteRenderer>();
                foreach(SpriteRenderer renderer in allRenderers)
                {
                    renderer.enabled = false;
                }
                jetEngineParticle.SetActive(false);
                robotEngineParticle.SetActive(false);
                BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
                collider2D.enabled = false;
                this.enabled = false;
                StartCoroutine(ResetAfterDelay());
            }
        }
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("MainMenu");
        //Debug.Log("Resetting game");
    }

    public int GetPlayerLives()
    {
        return playerLives;
    }
}

