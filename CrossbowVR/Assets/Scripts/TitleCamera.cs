using UnityEngine;
using UnityEngine;
using System.Collections;

public class TitleCamera : MonoBehaviour
{
    public Transform cameraOrbit;
    public Transform target;
    public float rotateSpeed = 8f;


    void Start()
    {
        cameraOrbit.position = target.position;
    }

    void Update()
    {


        float h =+ rotateSpeed * 1;
        float v =+ rotateSpeed * 1;

        if (cameraOrbit.transform.eulerAngles.z + v <= 0.1f || cameraOrbit.transform.eulerAngles.z + v >= 179.9f)
            v = 0;

        cameraOrbit.transform.eulerAngles = new Vector3(cameraOrbit.transform.eulerAngles.x, cameraOrbit.transform.eulerAngles.y + h, cameraOrbit.transform.eulerAngles.z + v);


        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);

        transform.LookAt(target.position);
    }
}