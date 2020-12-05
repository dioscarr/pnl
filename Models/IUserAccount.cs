using pnl.Data.Models;

namespace pnl.Models
{
    public interface IUserAccount
    {
        Person CurrentUser { get; set; }
    }
}