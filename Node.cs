using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Renderer rend;
    private Color startColor;
    public GameObject turret;
    public Vector3 positionOffset;
    BuildManager buildManager;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {

            return;
        }
        buildManager.BuildTurretOn(this);
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}