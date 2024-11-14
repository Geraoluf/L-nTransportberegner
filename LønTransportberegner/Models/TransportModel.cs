namespace LønTransportberegner.Models
{
    public class TransportModel
    {
        
            public int Id { get; set; }
            public string? Transportmetode { get; set; } // Sørg for, at navnet matcher
            public decimal Distance { get; set; }
            public decimal TransportCost { get; set; }
        

    }
}
