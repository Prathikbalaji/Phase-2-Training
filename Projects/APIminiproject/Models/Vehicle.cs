namespace APIminiproject.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public string? NumberPlate { get; set; }
        public string? VehicleType { get; set; }
        public string? MaintaneneceStatus { get; set; } 
        public bool IsAvailable { get; set; }
        public ICollection<Trip>? Trips { get; set; }
    }
}

    /*Pending,
    Completed,
    Overdue,
    InProgress*/