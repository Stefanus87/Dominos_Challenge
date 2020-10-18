using System;
using System.IO;
using System.Linq;
using Dominos.OLO.Vouchers.Models;
using Newtonsoft.Json;

namespace Dominos.OLO.Vouchers.Repository
{
    public class VoucherRepository: IVoucherRepository
    {
        internal string DataFilename = $"{AppDomain.CurrentDomain.BaseDirectory}data.json";

        private Voucher[] _vouchers;
  
   
        public Voucher GetCheapestVoucherByProductCode(string productCode)
        {
            if (_vouchers == null)
            {
                _vouchers = ReadDataFromFile();
            }
            var productResults = _vouchers.Where(x => x.ProductCodes == productCode);
            var resultOrdered = productResults.OrderBy(c => c.Price).AsEnumerable();                   

            return resultOrdered.FirstOrDefault();
        }

        public Voucher[] GetNumberOfVouchers(int number)
        {
            if (_vouchers == null)
            {
                _vouchers = ReadDataFromFile();
            }
            var result = _vouchers.Take(number).ToList();
            return result.ToArray();
        }

        public Voucher GetVoucherById(Guid id)
        {
            if (_vouchers == null)
            {
                _vouchers = ReadDataFromFile();
            }
            var result =_vouchers.FirstOrDefault(x=>x.Id == id);
            return result;
        }

        public Voucher[] GetVouchersByNameSearch(string search)
        {
            if (_vouchers == null)
            {
                _vouchers = ReadDataFromFile();
            }
            var searchResults = _vouchers.Where(x => x.Name.Contains(search));
            return searchResults.ToArray();
        }

        public Voucher[] GetVouchers()
        {
            if (_vouchers == null)
            {
                _vouchers = ReadDataFromFile();
            }
            return _vouchers;
        }

        public Voucher[] ReadDataFromFile()
        {
            var text = File.ReadAllText(DataFilename);
            _vouchers = JsonConvert.DeserializeObject<Voucher[]>(text);
            return _vouchers;
        }

        public Voucher[] GetVouchersByName(string name)
        {
            if (_vouchers == null)
            {
                _vouchers = ReadDataFromFile();
            }
            var searchResults = _vouchers.Where(x => x.Name == name);
            return searchResults.ToArray();
        }

        
    }
}