using System.Collections.Generic;
public abstract class StrategieChoixRessource
{
    public abstract int execute(List<Ressource> ressources);
}

public enum TypeStrategie
{
    Hasard,
    Proche,
    Equilibre
}