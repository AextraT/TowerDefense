using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    private GameObject turretPreview;

    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Color startColor;
    private Renderer rend;

    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void UpgradeTurret()
    {
        if (isUpgraded)
        {
            Debug.Log("Tourelle déjà améliorée");
            return;
        }

        if (PlayerStats.money < turretBluePrint.upgradeCost)
        {
            Debug.Log("Pas assez d'argent pour cela");
            return;
        }

        PlayerStats.money -= turretBluePrint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isUpgraded = true;

        Debug.Log("Tourelle améliorée");
    }

    private void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStats.money < bluePrint.cost)
        {
            Debug.Log("Pas assez d'argent pour cela");
            return;
        }

        PlayerStats.money -= bluePrint.cost;

        turretBluePrint = bluePrint;

        GameObject _turret = (GameObject)Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        Debug.Log("Objet acheté");
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBluePrint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        Destroy(turret);
        turretBluePrint = null;
        isUpgraded = false;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
        Destroy(turretPreview);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            rend.material.color = hoverColor;
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
            turretPreview = (GameObject)Instantiate(buildManager.GetTurretToBuild().prefab, transform.position + positionOffset, transform.rotation);
            Turret turretScript = turretPreview.GetComponent<Turret>();
            if(turretScript.lineRenderer != null)
            {
                turretPreview.GetComponent<LineRenderer>().enabled = false;
                turretScript.impactEffect.gameObject.SetActive(false);
            }
            turretScript.rangeCircle.transform.localScale = new Vector3(2 * turretScript.range, 2 * turretScript.range, 1);
            turretScript.rangeCircle.SetActive(true);
            turretScript.enabled = false;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
        Destroy(turretPreview);
    }
}
