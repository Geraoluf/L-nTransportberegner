namespace LønTransportberegner.Models
{
    public class TransportModel
    {
        public int Id { get; set; }
        public decimal Distance { get; set; }  // Tilføj afstand (km) som input
        public decimal TransportCost { get; set; }  // Beregnet fragtomkostning

    }
}
