using GlobalMeet.DataAccess.Entities.Main;


namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IPolicyTypeRepository:IGenericRepository<PolicyType>
    {
        Task<PolicyType> GetPolicyType(int id); 
        Task<ICollection<PolicyType>> GetPolicyTypes(); 
    }
}
