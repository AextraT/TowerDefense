using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    private Node target;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    public void SetTarget(Node _target)
    {
        if(target != null)
        {
            target.turret.GetComponent<Turret>().rangeCircle.SetActive(false);
        }
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeButton.interactable = true;
            upgradeCost.text = "-" + target.turretBluePrint.upgradeCost;
        }
        else
        {
            upgradeButton.interactable = false;
            upgradeCost.text = "---";
        }

        sellAmount.text = "+" + target.turretBluePrint.GetSellAmount();

        target.turret.GetComponent<Turret>().rangeCircle.SetActive(true);
        UI.SetActive(true);
    }

    public void Hide()
    {
        if(target != null && target.turret != null)
        {
            target.turret.GetComponent<Turret>().rangeCircle.SetActive(false);
        }
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}