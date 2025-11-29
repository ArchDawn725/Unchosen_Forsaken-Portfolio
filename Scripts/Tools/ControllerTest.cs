using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerTest : MonoBehaviour
{
    public enum ControllerSide
    {
        Left_Controller,
        Right_Controller,
    }

    public ControllerSide m_Controller;
    private InputDeviceCharacteristics m_Characteristics;
    public Player player;
    public Flashlight flashlight;

    public void Start()
    {
        if (m_Controller == ControllerSide.Left_Controller)
        {
            m_Characteristics = InputDeviceCharacteristics.Left;
        }
        else
        {
            m_Characteristics = InputDeviceCharacteristics.Right;
        }
    }

    void Update()
    {
        List<InputDevice> m_device = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(m_Characteristics, m_device);
        if(m_device.Count == 1)
        {
            CheckController(m_device[0]);
        }
        else
        {
            //print("Controller not found");
        }
    }

    private void CheckController(InputDevice d)
    {
        
        bool primaryButtonDown = false;
        d.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonDown);
        if (primaryButtonDown)
        {
            Activate();
        }

        
        if (m_Controller == ControllerSide.Left_Controller)
        {
            bool primary2DAxisClickDown = false;
            d.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out primary2DAxisClickDown);
            if (primary2DAxisClickDown)
            {
                //print("Primary Button Down-chez2");
                player.sprinting = true;
            }
            else
            {
                //print("Primary Button Up - chez2");
                player.sprinting = false;
            }
        }

    }

    public void Activate()
    {
        if (flashlight != null)
        {
            flashlight.StrobeLight();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Flashlight>() != null)
        {
            flashlight = other.GetComponent<Flashlight>();
        }
    }
}
