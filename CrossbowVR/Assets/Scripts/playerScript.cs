
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{

    //declare GameObjects and create isShooting boolean.
    public GameObject gun;
    public GameObject spawnPoint;
    private bool isShooting;
   
    


    // Use this for initialization
    void Start()
    {

        //only needed for IOS
        Application.targetFrameRate = 60;

        //create references to gun and bullet spawnPoint objects
        //gun = gameObject.transform.GetChild(0).gameObject;
        //spawnPoint = gun.transform.GetChild(0).gameObject;

        //set isShooting bool to default of false
        isShooting = false;


    }

    //Shoot function is IEnumerator so we can delay for seconds
    IEnumerator Shoot(Transform target)
    {
        //set is shooting to true so we can't shoot continuosly
        isShooting = true;
        //instantiate the bullet
        GameObject bullet = Instantiate(Resources.Load("Bolt", typeof(GameObject))) as GameObject;
        bullet.transform.localScale= new Vector3(0.1f,0.1f,0.07f);
        BoltCtrl bc = bullet.GetComponent<BoltCtrl>();
        var boltSound = bullet.GetComponent<AudioSource>();
        boltSound.Play();
       // Debug.Log("Debug: Arrow Spawned");
        //Get the bullet's rigid body component and set its position and rotation equal to that of the spawnPoint
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = spawnPoint.transform.rotation;
        bullet.transform.position = spawnPoint.transform.position;
        bc.destination = target.position;
        //add force to the bullet in the direction of the spawnPoint's forward vector
        //rb.AddForce(spawnPoint.transform.forward * 1f);
        //play the gun shot sound and gun animation
        //destroy the bullet after 1 second
        Destroy(bullet, 3);
        //wait for 1 second and set isShooting to false so we can shoot again
        yield return new WaitForSeconds(1f);
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {

        //declare a new RayCastHit
        RaycastHit hit;
        //draw the ray for debuging purposes (will only show up in scene view)
        Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.green);


     
        //cast a ray from the spawnpoint in the direction of its forward vector
        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, 100))
        {

            //if the raycast hits any game object where its name contains "zombie" and we aren't already shooting we will start the shooting coroutine
            if (hit.collider.name.Contains("Goblin"))
            {
                Debug.Log("Debug: HIT! : "+ hit.collider.name);
                if (!isShooting)
                {
                    StartCoroutine(Shoot(hit.transform));
                }

            }
            if (hit.collider.name.Contains("Pointer"))
            {
                Debug.Log("Debug: Teleporting XD! : " + hit.collider.name);
                

                this.transform.position = hit.transform.position;

           



            }
            if (hit.collider.name.Contains("ExitButton"))
            {
                Debug.Log("Debug: Exiting XD! : " + hit.collider.name);



    
                SceneManager.LoadScene(0);

            }
          




        }

    }
}
