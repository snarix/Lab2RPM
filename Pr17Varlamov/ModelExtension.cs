using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr17Varlamov
{
    public partial class ObuvvEntities : DbContext
    {
        private static ObuvvEntities context;

        public static ObuvvEntities GetContext()
        {
            if (context == null) context = new ObuvvEntities();
            return context;
        }
    }
}
