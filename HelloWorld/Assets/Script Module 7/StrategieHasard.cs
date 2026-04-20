using UnityEngine;
using System.Collections.Generic;

public class StrategieHasard : StrategieChoixRessource
{
    private Transform transformVillageois;
    public override int execute(List<Ressource> ressources)
    {
        // Implementation for random resource choice
        Debug.Log("Stratégie Hasard: Choix aléatoire d'une ressource.");
        return Random.Range(0, ressources.Count);
    }
}
