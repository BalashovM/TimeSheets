using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementations
{
    public class SheetRepo : ISheetRepo
    {
        private List<Sheet> sheets { get; set; } = new List<Sheet>() { }
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Sheet GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sheet> GetItems()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
