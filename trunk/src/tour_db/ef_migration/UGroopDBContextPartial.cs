using Microsoft.EntityFrameworkCore;

namespace UGroopData.Sql.Repository2.Data {
    public partial class UGroopDBContext  {

        public UGroopDBContext() {

        }

        public UGroopDBContext(DbContextOptions<UGroopDBContext> options)
            : base(options) {

        }

    }
}
