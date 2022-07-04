using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface ICheckupRepository: IBaseRepository<CheckUp>
    {
     
        public CheckUp GetPreviouscheckUp(int checkupId);
       



    }
}
