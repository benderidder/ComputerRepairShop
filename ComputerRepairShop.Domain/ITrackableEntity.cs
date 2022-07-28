namespace ComputerRepairShop.Domain
{
    public interface ITrackableEntity
    {
        string CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }

        string ModifiedBy { get; set; }

        DateTime ModifiedOn { get; set; }
    }
}
