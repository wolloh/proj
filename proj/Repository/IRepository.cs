using proj.EF;
namespace proj.Repository
{
   public  interface IOrderRepository 
    {
        IEnumerable<EF.Order> GetOrdersList(); 
        EF.Order GetOrder(int id); 
        void Create(EF.Order item); 
        void Update(EF.Order item); 
        void Delete(int id); 
        void Save();  
    }
}
