using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFS.WebApi.Repositories
{
    public interface IUnitOfWork
    {
       // IContentRepo ContentRepo { get; }
        void Save();
    }
}
