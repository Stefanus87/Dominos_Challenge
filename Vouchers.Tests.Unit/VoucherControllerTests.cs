using System;
using System.Collections.Generic;
using System.Linq;
using Dominos.OLO.Vouchers.Controllers;
using Dominos.OLO.Vouchers.Models;
using Dominos.OLO.Vouchers.Repository;
using NSubstitute;
using NUnit.Framework;

namespace Dominos.OLO.Vouchers.Tests.Unit
{
    [TestFixture]
    public class VoucherControllerTests
    {
        private  IVoucherRepository _repository = Substitute.For<VoucherRepository>();
        private  VoucherController _controller;

       

        private readonly List<Voucher> _vouchers = new List<Voucher>();

        [SetUp]
        public void Setup()
        {
            _controller = new VoucherController(_repository);
        }

        [Test]
        public void Get_ShouldReturnRequestedNumberOfVouchers()
        {
            for (var i = 0; i < 1000; i++)
            {
                _vouchers.Add(new Voucher
                {
                    Id = new Guid()
                });
            }

            var result = _controller.Get(100);

            Assert.AreEqual(100, result.Length);
        }

        [Test]
        public void Get_ShouldReturnAllVouchersByDefault()
        {
            for (var i = 0; i < 1000; i++)
            {
                _vouchers.Add(new Voucher
                {
                    Id = new Guid()
                });
            }

            var result = _controller.Get(1000);

            Assert.AreEqual(_vouchers.Count, result.Length);
        }

        [Test]
        public void GetVouchersByName_ShouldReturnAllVouchersWithTheGivenName()
        {
            var searchPizzaName = "13 Value, Traditional or Chicken & Prawn Pizzas, 7 x Garlic Bread, 10 x Chicken Sides, 7 x 1.5L Drinks from $229.99";
            var result = _controller.GetVouchersByName(searchPizzaName);
            Assert.AreEqual(result.Count(), 109);
        }

        [Test]
        public void GetVouchersByNameSearch_ShouldReturnAllVouchersWhichMatchTheSearch()
        {
            var searchPizzaName = "13 Value, Traditional or Chicken & Prawn Pizzas, 7 x Garlic Bread, 10 x Chicken Sides, 7 x 1.5L Drinks from $229.99";

            var result = _controller.GetVouchersByNameSearch(searchPizzaName);
            Assert.AreEqual(result.Count(), 109);
        }
    }
}