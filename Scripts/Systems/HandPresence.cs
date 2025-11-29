using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    //public bool holdingFlashlight = false;
    public InputDeviceCharacteristics controllerCharacterisitcs;
    //public GameObject flashLightPrefab;
    //public GameObject handModelPrefab;

    public InputDevice targetDevice;
    //public GameObject spawnedFlashLight;
    //public GameObject spawnedHandModel;
    public Animator handAnimator;

    public float handgripping;
    public XRNode inputSource;

    public void Start()
    {
        TryInitialize();
    }

    public void TryInitialize()
    {
        // somthing wrong here with animations
        List<InputDevice> devices = new List<InputDevice>();

                InputDevices.GetDevicesWithCharacteristics(controllerCharacterisitcs, devices);

        foreach (var item in devices)
        {
            print(item.name + item.characteristics);
        }

        targetDevice = devices[0];
        /*        if (devices.Count > 0)
                {
                    targetDevice = devices[0];


        //            spawnedFlashLight = Instantiate(flashLightPrefab, transform);

                    spawnedHandModel = Instantiate(handModelPrefab, transform);
        */         //   handAnimator = spawnedHandModel.GetComponent<Animator>();
                   // }

    }

    public void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
/*        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
*/
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
            handgripping = gripValue;
        }
/*        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
*/    }

    public void Update()
    {
        //spawnedHandModel.SetActive(true);
        UpdateHandAnimation();
        /*UpdateHandAnimation();
        /*        if (!targetDevice.isValid)
                {
                    TryInitialize();
                }
                else
                {
        
        if (holdingFlashlight == true)
            {
                spawnedFlashLight.SetActive(true);
                spawnedHandModel.SetActive(false);
            }
            else
            {
                spawnedFlashLight.SetActive(false);
                spawnedHandModel.SetActive(true);
                UpdateHandAnimation();
            }
//        }
*/    }
}
