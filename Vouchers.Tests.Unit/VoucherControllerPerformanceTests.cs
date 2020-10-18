using System;
using System.Collections.Generic;
using Dominos.OLO.Vouchers.Controllers;
using Dominos.OLO.Vouchers.Models;
using Dominos.OLO.Vouchers.Repository;
using NSubstitute;
using NUnit.Framework;

namespace Dominos.OLO.Vouchers.Tests.Unit
{
    [TestFixture]
    public class VoucherControllerPerformanceTests
    {
        
        private IVoucherRepository _repository = Substitute.For<VoucherRepository>();
        private VoucherController _controller;
        private List<Voucher> _vouchers = new List<Voucher>();



        [SetUp]
        public void Setup()
        {
             //_repository.GetVouchers().Returns(info => _vouchers);
            _controller = new VoucherController(_repository);
            // This is to pre-load the vouchers.
           // repository.GetVouchers();
        }

        [Test]
        public void Get_ShouldBePerformant()
        {
            var startTime = DateTime.Now;

            for (var i = 0; i < 1000; i++)
            {
                _controller.Get();
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 15000);
        }

        [Test]
        public void Get_ShouldBePerformantWhenReturningASubset()
        {
            var startTime = DateTime.Now;

            for (var i = 0; i < 100000; i++)
            {
                _controller.Get(1000);
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 5000);
        }

        [Test]
        public void GetCheapestVoucherByProductCode_ShouldBePerformant()
        {
            var startTime = DateTime.Now;

            for (var i = 0; i < 100; i++)
            {
                _controller.GetCheapestVoucherByProductCode("P007D");
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 15000);
        }
    }
}