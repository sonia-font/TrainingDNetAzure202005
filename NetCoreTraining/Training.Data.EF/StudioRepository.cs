using System;
using Training.Data.Domain;

namespace Training.Data.EF
{
    public class StudioRepository : Repository<Studio, Guid>, IStudioRepository
    {
        public StudioRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}