using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class StrategieProche : StrategieChoixRessource
{
    private float distanceRessource;
    private float distanceMin;
    private int ressourceProche;
    private Transform transformVillageois;

    public StrategieProche(Transform transformVillageois)
    {
        this.transformVillageois = transformVillageois;
    }

    public override int execute(List<Ressource> ressources)
    {
        distanceMin = 100f;
        Debug.Log("Stratégie Proche: Choix de la ressource la plus proche.");
        for (int i = 0; i < ressources.Count; i++)
        {
            distanceRessource = (transformVillageois.position - ressources[i].transform.position).magnitude;
            if (distanceRessource < distanceMin)
            {
                distanceMin = distanceRessource;
                ressourceProche = i;
            }
        }

        return ressourceProche;
    }
}
