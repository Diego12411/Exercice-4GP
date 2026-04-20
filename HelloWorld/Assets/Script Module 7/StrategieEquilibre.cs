using UnityEngine;
using System.Collections.Generic;

public class StrategieEquilibre : StrategieChoixRessource
{
    private float distanceRessource;
    private float meilleurValeur;
    private float choixValeur;
    private int choixFinal;
    private Transform transformVillageois;
    public StrategieEquilibre(Transform transformVillageois)
    {
        this.transformVillageois = transformVillageois;
    }
    public override int execute(List<Ressource> ressources)
    {
        meilleurValeur = 0f;

        Debug.Log("Stratégie Equilibre: Choix de la ressource la plus équilibrée.");

        for (int i = 0; i < ressources.Count; i++)
        {
            distanceRessource = (transformVillageois.position - ressources[i].transform.position).magnitude;

            choixValeur = ressources[i].valeur / Mathf.Pow(distanceRessource, 2);
            if (choixValeur > meilleurValeur)
            {
                meilleurValeur = choixValeur;
                choixFinal = i;
            }
        }
        return choixFinal;
    }
}
