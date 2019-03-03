namespace EDGM
{
    public class StarInfo
    {
        public string name { get; set; }
        public Coords coords { get; set; }
        public Information information { get; set; }
        public PrimaryStar primaryStar { get; set; }
    }
    public class Coords
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }
    public class Information
    {
        public string allegiance { get; set; }
        public string government { get; set; }
        public string faction { get; set; }
        public string factionState { get; set; }
        public string population { get; set; }
        public string security { get; set; }
        public string economy { get; set; }
    }
    public class PrimaryStar
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool isScoopable { get; set; }
    }
}
