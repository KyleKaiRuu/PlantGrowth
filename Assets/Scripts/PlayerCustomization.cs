using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCustomization : MonoBehaviour
{
    public GameObject head;
    public GameObject leftEye;
    public GameObject rightEye;
    public GameObject body;

    public GameObject headSphere;
    public GameObject headCube;
    public GameObject capsule;

    public GameObject leftEyeCube;
    public GameObject leftEyeSphere;

    public Dropdown leftEyeDropdown;
    public Dropdown rightEyeDropdown;

    public void UpdateHeadShape(int option)
    {
        switch (option)
        {
            case 0:
                Destroy(head);
                head = Instantiate(headCube, new Vector3(0, 1.137f, 0), Quaternion.identity);
                break;
            case 1:
                Destroy(head);
                head = Instantiate(headSphere, new Vector3(0, 1.137f, 0), Quaternion.identity);
                break;
        }
    }

    public void UpdateLeftEyeShape(int option)
    {
        switch (option)
        {
            case 0:
                Destroy(leftEye);
                leftEye = Instantiate(leftEyeCube, new Vector3(-0.283f, 1.137f, -0.549f), Quaternion.identity);
                break;
            case 1:
                Destroy(leftEye);
                leftEye = Instantiate(leftEyeSphere, new Vector3(-0.283f, 1.137f, -0.549f), Quaternion.identity);
                break;
        }
    }
    
    public void UpdateRightEyeShape(int option)
    {
        switch (option)
        {
            case 0:
                Destroy(rightEye);
                rightEye = Instantiate(leftEyeCube, new Vector3(0.283f, 1.137f, -0.549f), Quaternion.identity);
                break;
            case 1:
                Destroy(rightEye);
                rightEye = Instantiate(leftEyeSphere, new Vector3(0.283f, 1.137f, -0.549f), Quaternion.identity);
                break;
        }
    }

    public void UpdateBothEyeShapes(int option)
    {
        leftEyeDropdown.value = option;
        rightEyeDropdown.value = option;
        switch (option)
        {
            case 0:
                Destroy(rightEye);
                Destroy(leftEye);
                rightEye = Instantiate(leftEyeCube, new Vector3(0.283f, 1.137f, -0.549f), Quaternion.identity);
                leftEye = Instantiate(leftEyeCube, new Vector3(-0.283f, 1.137f, -0.549f), Quaternion.identity);
                break;
            case 1:
                Destroy(rightEye);
                Destroy(leftEye);
                rightEye = Instantiate(leftEyeSphere, new Vector3(0.283f, 1.137f, -0.549f), Quaternion.identity);
                leftEye = Instantiate(leftEyeSphere, new Vector3(-0.283f, 1.137f, -0.549f), Quaternion.identity);
                break;
        }
    }


    public void UpdateBodyShape(int option)
    {
        switch (option)
        {
            case 0:
                Destroy(body);
                body = Instantiate(capsule, new Vector3(0, -0.203f, 0), Quaternion.identity);
                break;
            case 1:
                Destroy(body);
                body = Instantiate(headSphere, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case 2:
                Destroy(body);
                body = Instantiate(headCube, new Vector3(0, 0, 0), Quaternion.identity);
                break;
        }
    }
}
