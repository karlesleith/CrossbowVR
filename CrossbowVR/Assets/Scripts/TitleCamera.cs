using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleCamera : MonoBehaviour
{
    public Transform cameraOrbit;
    public Transform target;
    public GameObject rayCaster;
    public float rotateSpeed = 8f;

    private int playTime = 0;
    private int quitTime = 0;

    void Start()
    {
        cameraOrbit.position = target.position;
        //only needed for IOS
        Application.targetFrameRate = 60;

        //create references to gun and bullet spawnPoint objects
        //gun = gameObject.transform.GetChild(0).gameObject;
        //spawnPoint = gun.transform.GetChild(0).gameObject;

    }

    void Update()
    {


        float h = +rotateSpeed * 1;
        float v = +rotateSpeed * 1;

        if (cameraOrbit.transform.eulerAngles.z + v <= 0.1f || cameraOrbit.transform.eulerAngles.z + v >= 179.9f)
            v = 0;

        cameraOrbit.transform.eulerAngles = new Vector3(cameraOrbit.transform.eulerAngles.x, cameraOrbit.transform.eulerAngles.y + h, cameraOrbit.transform.eulerAngles.z + v);


        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);

        transform.LookAt(target.position);



        //declare a new RayCastHit
        RaycastHit hit;
        //draw the ray for debuging purposes (will only show up in scene view)
        Debug.DrawRay(rayCaster.transform.position, rayCaster.transform.forward, Color.green);



        //cast a ray from the spawnpoint in the direction of its forward vector
        if (Physics.Raycast(rayCaster.transform.position, rayCaster.transform.forward, out hit, 200))
        {

            if (hit.collider.name.Contains("PlayBox"))
            {
                if (playTime > 20)
                {
                    Debug.Log("Debug: Playing XD! : " + hit.collider.name);
                    SceneManager.LoadScene(1);
                }
                playTime++;
            }
            else if (hit.collider.name.Contains("QuitBox"))
            {

                if (quitTime > 20)
                {
                    Debug.Log("Debug: Quitting XD! : " + hit.collider.name);

                    Application.Quit();
                }
                quitTime++;
            } 
        }
        else
        {
            playTime = 0;
            quitTime = 0;
        }
    }
}
