namespace LønTransportberegner.Models
{
    public class TransportModel
    {
        
            public int Id { get; set; }
            public string? Transportmetode { get; set; } 
            public decimal Distance { get; set; }
            public decimal TransportCost { get; set; }
        

    }
}
