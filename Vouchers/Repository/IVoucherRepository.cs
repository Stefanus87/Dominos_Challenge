
using Dominos.OLO.Vouchers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos.OLO.Vouchers.Repository
{
    public interface IVoucherRepository
    {
        Voucher[] GetVouchers();
        Voucher[] GetNumberOfVouchers(int number);
        Voucher GetVoucherById(Guid id);
        Voucher[] GetVouchersByNameSearch(string search);
        Voucher[] GetVouchersByName(string name);
        Voucher GetCheapestVoucherByProductCode(string productCode);
        
    }
}
