using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Dominos.OLO.Vouchers.Models;
using Dominos.OLO.Vouchers.Repository;

namespace Dominos.OLO.Vouchers.Controllers
{
    public class VoucherController : ApiController
    {
        private IVoucherRepository _voucherRepository;

        public VoucherController(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        [Route("")]
        public Voucher[] Get(int count = 0)
        {
            var vouchers = _voucherRepository.GetVouchers();
            if (count == 0)
            {
                count = vouchers.Length;
            }

            return vouchers.Take(count).ToArray();
        }

        [Route("getvoucherbyid/{id}")]
        public Voucher GetVoucherById(Guid id)
        {
            var voucher = _voucherRepository.GetVoucherById(id);
            return voucher;
        }

        [Route("getvoucherbyname/{name}")]
        public Voucher[] GetVouchersByName(string name)
        {
            var vouchers = _voucherRepository.GetVouchersByName(name);
            
            var returnVouchers = new List<Voucher>();
            if (vouchers != null)
            {
                returnVouchers.AddRange(vouchers);
            }
            //for (var i = 0; i < vouchers.Count; i++)
            //{
            //    if (vouchers[i].Name == name)
            //    {
            //        returnVouchers.Add(vouchers[i]);
            //    }
            //}

            return returnVouchers.ToArray();
        }

        [Route("getvoucherbynamesearch/{name}")]
        public Voucher[] GetVouchersByNameSearch(string name)
        {
            var vouchers = _voucherRepository.GetVouchersByNameSearch(name);

            var returnVouchers = new List<Voucher>();
            if (vouchers != null)
            {
                returnVouchers.AddRange(vouchers);
            }

            return returnVouchers.ToArray();
        }

        [Route("getcheapestvoucherbyproductcode/{productcode}")]
        public Voucher GetCheapestVoucherByProductCode(string productCode)
        {
            var voucher = _voucherRepository.GetCheapestVoucherByProductCode(productCode);
            return voucher;
        }
    }
}