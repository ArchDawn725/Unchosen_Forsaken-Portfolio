using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdster : MonoBehaviour
{
    public bool filled;
    public GameObject item;
    public Holder holder;
    public Renderer rend;

    public bool isBackpack;
    public bool isBackpackHoldster;

    public GameObject anchor;
    public float rotationSpeed = 50;

    public bool matchHolder;
    public Fire fire;

    public void OnTriggerEnter(Collider other)
    {
        if (!filled)
        {
            if (!isBackpack)
            {
                if (!matchHolder)
                {
                    if (other.gameObject.tag == "Oil" || other.gameObject.tag == "Item" || other.gameObject.tag == "Battery" || other.gameObject.tag == "Lantern" || other.gameObject.tag == "Fire")
                    {
                        holder = other.GetComponent("Holder") as Holder;
                        if (holder.isHeld == false)
                        {
                            holder.holdster = this.gameObject;
                            item = other.gameObject;
                            filled = true;
                            rend.enabled = false;
                            holder.isHeld = true;
                        }
                    }
                }
                else
                {
                    fire = other.GetComponent("Fire") as Fire;
                    {
                        if (fire.isMatch == true)
                        {
                            holder = other.GetComponent("Holder") as Holder;
                            if (holder.isHeld == false)
                            {
                                holder.holdster = this.gameObject;
                                item = other.gameObject;
                                filled = true;
                                rend.enabled = false;
                                holder.isHeld = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (other.gameObject.tag == "Backpack")
                {
                    holder = other.GetComponent("Holder") as Holder;
                    holder.holdster = this.gameObject;
                    holder.isHeld = true;
                    item = other.gameObject;
                    filled = true;
                    rend.enabled = false;
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == item)
        {
            filled = false;
            rend.enabled = true;
            holder.isHeld = false;
        }
    }

    public void Update()
    {
        if (!isBackpackHoldster || !matchHolder)
        {
            var rotationDifference = Math.Abs(anchor.transform.eulerAngles.y - transform.eulerAngles.y);
            var finalRotationSpeed = rotationSpeed;

            if (rotationDifference > 60)
            {
                finalRotationSpeed = rotationSpeed * 2;
            }
            else if (rotationDifference > 40 && rotationDifference < 60)
            {
                finalRotationSpeed = rotationSpeed;
            }
            else if (rotationDifference < 40 && rotationDifference > 20)
            {
                finalRotationSpeed = rotationSpeed / 2;
            }
            else if (rotationDifference < 20 && rotationDifference > 0)
            {
                finalRotationSpeed = rotationSpeed / 4;
            }

            var step = finalRotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, anchor.transform.eulerAngles.y, 0), step);
        }

    }

}