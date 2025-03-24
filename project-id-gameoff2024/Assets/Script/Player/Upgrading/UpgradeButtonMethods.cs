//swapped unn.inv.Item[i] to uun.inv.InventorySlots[i] because otherwise it wouldn't work properly.
//changed unn to uiUpgradeNeeds for better readability (for me at least)
using UnityEngine;

public class UpgradeButtonMethods : MonoBehaviour
{
    private UiUpgradingNeeds uiUpgradeNeeds;
    public PlayerCombat playerCombat;
    public PlayerProfile playerProfile;

    public string NeededItem, ExtraNeededItem;
    private int NeededItemCost, ExtraNeededItemCost;

    private void Awake()
    {
        uiUpgradeNeeds = gameObject.GetComponent<UiUpgradingNeeds>();
    }

    private void Update()
    {
        NeededItemCost = uiUpgradeNeeds.cost;
        ExtraNeededItemCost = uiUpgradeNeeds.Extracost;

    }
    
    public void IncreaseDammage(int addingDammage)
    {
        bool NeedExtra = uiUpgradeNeeds.IsExtra;

        for (int i = 0; i < uiUpgradeNeeds.inv.InventorySlots.Count; i++)
        {
            if (!NeedExtra)
            {
                if(uiUpgradeNeeds.inv.InventorySlots[i] != null)
                {
                    if (uiUpgradeNeeds.inv.InventorySlots[i].Objname == NeededItem)
                    {
                        if(uiUpgradeNeeds.inv.InventorySlots[i].amount >= NeededItemCost)
                        {
                            uiUpgradeNeeds.lvl += 1;
                            playerCombat.CurrentWeaponHolder.weapon.weaponData.WeaponBasicDamage += addingDammage;
                            uiUpgradeNeeds.inv.InventorySlots[i].amount -= NeededItemCost;
                        }
                    }
                }
            }

            if(NeedExtra)
            {
                if (uiUpgradeNeeds.inv.InventorySlots[i] != null)
                {
                    for(int j = 0; j < uiUpgradeNeeds.inv.InventorySlots.Count; i++)
                    {
                        if(uiUpgradeNeeds.inv.InventorySlots[j] != null && uiUpgradeNeeds.inv.InventorySlots[j] != uiUpgradeNeeds.inv.InventorySlots[i])
                        {
                            if (uiUpgradeNeeds.inv.InventorySlots[i].Objname == NeededItem && uiUpgradeNeeds.inv.InventorySlots[j].Objname == ExtraNeededItem)
                            {
                                if (uiUpgradeNeeds.inv.InventorySlots[i].amount >= NeededItemCost && uiUpgradeNeeds.inv.InventorySlots[j].amount >= ExtraNeededItemCost)
                                {
                                    uiUpgradeNeeds.lvl += 1;
                                    playerCombat.CurrentWeaponHolder.weapon.weaponData.WeaponBasicDamage += addingDammage;
                                    uiUpgradeNeeds.inv.InventorySlots[i].amount -= NeededItemCost;
                                    uiUpgradeNeeds.inv.InventorySlots[j].amount -= ExtraNeededItemCost;
                                }
                            }
                        }
                    }

                }
            }
        }
    }

    public void DecreaseStaminaDrain(int decreasingStamina)
    {
        bool NeedExtra = uiUpgradeNeeds.IsExtra;
        for (int i = 0; i < uiUpgradeNeeds.inv.InventorySlots.Count; i++)
        {
            if (!NeedExtra)
            {
                if (uiUpgradeNeeds.inv.InventorySlots[i] != null)
                {
                    if (uiUpgradeNeeds.inv.InventorySlots[i].Objname == NeededItem)
                    {
                        if (uiUpgradeNeeds.inv.InventorySlots[i].amount >= NeededItemCost)
                        {
                            uiUpgradeNeeds.lvl += 1;
                            playerCombat.CurrentWeaponHolder.weapon.weaponData.WeaponStaminaCost -= decreasingStamina;
                            uiUpgradeNeeds.inv.InventorySlots[i].amount -= NeededItemCost;
                        }
                    }
                }
            }

            if (NeedExtra)
            {
                if (uiUpgradeNeeds.inv.InventorySlots[i] != null)
                {
                    for (int j = 0; j < uiUpgradeNeeds.inv.InventorySlots.Count; i++)
                    {
                        if (uiUpgradeNeeds.inv.InventorySlots[j] != null)
                        {
                            if (uiUpgradeNeeds.inv.InventorySlots[i].Objname == NeededItem && uiUpgradeNeeds.inv.InventorySlots[j].Objname == ExtraNeededItem)
                            {
                                if (uiUpgradeNeeds.inv.InventorySlots[i].amount >= NeededItemCost && uiUpgradeNeeds.inv.InventorySlots[j].amount >= ExtraNeededItemCost)
                                {
                                    uiUpgradeNeeds.lvl += 1;
                                    playerCombat.CurrentWeaponHolder.weapon.weaponData.WeaponStaminaCost -= decreasingStamina;
                                    uiUpgradeNeeds.inv.InventorySlots[i].amount -= NeededItemCost;
                                    uiUpgradeNeeds.inv.InventorySlots[j].amount -= ExtraNeededItemCost;
                                }
                            }
                        }
                    }

                }
            }
        }
    }

    public void IncreaseSuperAttack(int increaseDammage)
    {
        bool NeedExtra = uiUpgradeNeeds.IsExtra;
        for (int i = 0; i < uiUpgradeNeeds.inv.InventorySlots.Count; i++)
        {
            if (!NeedExtra)
            {
                if (uiUpgradeNeeds.inv.InventorySlots[i] != null)
                {
                    if (uiUpgradeNeeds.inv.InventorySlots[i].Objname == NeededItem)
                    {
                        if (uiUpgradeNeeds.inv.InventorySlots[i].amount >= NeededItemCost)
                        {
                            uiUpgradeNeeds.lvl += 1;
                            playerCombat.CurrentWeaponHolder.weapon.weaponData.WeaponSuperAttackDamage += increaseDammage;
                            uiUpgradeNeeds.inv.InventorySlots[i].amount -= NeededItemCost;
                        }
                    }
                }
            }

            if (NeedExtra)
            {
                if (uiUpgradeNeeds.inv.Items[i] != null)
                {
                    for (int j = 0; j < uiUpgradeNeeds.inv.InventorySlots.Count; i++)
                    {
                        if (uiUpgradeNeeds.inv.InventorySlots[j] != null)
                        {
                            if (uiUpgradeNeeds.inv.Items[i].Objname == NeededItem && uiUpgradeNeeds.inv.InventorySlots[j].Objname == ExtraNeededItem)
                            {
                                if (uiUpgradeNeeds.inv.InventorySlots[i].amount >= NeededItemCost && uiUpgradeNeeds.inv.InventorySlots[j].amount >= ExtraNeededItemCost)
                                {
                                    uiUpgradeNeeds.lvl += 1;
                                    playerCombat.CurrentWeaponHolder.weapon.weaponData.WeaponSuperAttackDamage += increaseDammage;
                                    uiUpgradeNeeds.inv.InventorySlots[i].amount -= NeededItemCost;
                                    uiUpgradeNeeds.inv.InventorySlots[j].amount -= ExtraNeededItemCost;
                                }
                            }
                        }
                    }

                }
            }
        }
    }

    public void IncreaseHealth(int increaseHealth)
    {
        bool NeedExtra = uiUpgradeNeeds.IsExtra;
        for (int i = 0; i < uiUpgradeNeeds.inv.InventorySlots.Count; i++)
        {
            if (!NeedExtra)
            {
                if (uiUpgradeNeeds.inv.InventorySlots[i] != null)
                {
                    if (uiUpgradeNeeds.inv.InventorySlots[i].Objname == NeededItem)
                    {
                        if (uiUpgradeNeeds.inv.InventorySlots[i].amount >= NeededItemCost)
                        {
                            uiUpgradeNeeds.lvl += 1;
                            playerProfile.profile.PlayerHealth += increaseHealth;
                            uiUpgradeNeeds.inv.InventorySlots[i].amount -= NeededItemCost;
                        }
                    }
                }
            }

            if (NeedExtra)
            {
                if (uiUpgradeNeeds.inv.InventorySlots[i] != null)
                {
                    for (int j = 0; j < uiUpgradeNeeds.inv.InventorySlots.Count; i++)
                    {
                        if (uiUpgradeNeeds.inv.InventorySlots[j] != null)
                        {
                            if (uiUpgradeNeeds.inv.InventorySlots[i].Objname == NeededItem && uiUpgradeNeeds.inv.InventorySlots[j].Objname == ExtraNeededItem)
                            {
                                if (uiUpgradeNeeds.inv.InventorySlots[i].amount >= NeededItemCost && uiUpgradeNeeds.inv.InventorySlots[j].amount >= ExtraNeededItemCost)
                                {
                                    uiUpgradeNeeds.lvl += 1;
                                    playerProfile.profile.PlayerHealth += increaseHealth;
                                    uiUpgradeNeeds.inv.InventorySlots[i].amount -= NeededItemCost;
                                    uiUpgradeNeeds.inv.InventorySlots[j].amount -= ExtraNeededItemCost;
                                }
                            }
                        }
                    }

                }
            }
        }
    }

    public void IncreaseStamina(int increaseStamina)
    {
        bool NeedExtra = uiUpgradeNeeds.IsExtra;
        for (int i = 0; i < uiUpgradeNeeds.inv.InventorySlots.Count; i++)
        {
            if (!NeedExtra)
            {
                if (uiUpgradeNeeds.inv.InventorySlots[i] != null)
                {
                    if (uiUpgradeNeeds.inv.InventorySlots[i].Objname == NeededItem)
                    {
                        if (uiUpgradeNeeds.inv.InventorySlots[i].amount >= NeededItemCost)
                        {
                            uiUpgradeNeeds.lvl += 1;
                            playerProfile.profile.PlayerStamina += increaseStamina;
                            uiUpgradeNeeds.inv.InventorySlots[i].amount -= NeededItemCost;
                        }
                    }
                }
            }

            if (NeedExtra)
            {
                if (uiUpgradeNeeds.inv.InventorySlots[i] != null)
                {
                    for (int j = 0; j < uiUpgradeNeeds.inv.InventorySlots.Count; i++)
                    {
                        if (uiUpgradeNeeds.inv.InventorySlots[j] != null)
                        {
                            if (uiUpgradeNeeds.inv.InventorySlots[i].Objname == NeededItem && uiUpgradeNeeds.inv.InventorySlots[j].Objname == ExtraNeededItem)
                            {
                                if (uiUpgradeNeeds.inv.InventorySlots[i].amount >= NeededItemCost && uiUpgradeNeeds.inv.InventorySlots[j].amount >= ExtraNeededItemCost)
                                {
                                    uiUpgradeNeeds.lvl += 1;
                                    playerProfile.profile.PlayerStamina += increaseStamina;
                                    uiUpgradeNeeds.inv.InventorySlots[i].amount -= NeededItemCost;
                                    uiUpgradeNeeds.inv.InventorySlots[j].amount -= ExtraNeededItemCost;
                                }
                            }
                        }
                    }

                }
            }
        }
    }
}
