using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using CoffeeMachine.DataAccess;
using CoffeeMachine.Model;
using CoffeeMachine.Operations;
using ServiceStack;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class CoffeeTests
    {
        [Theory]
        [InlineData(.35, "{\"Quarter\":1,\"Dime\":1}")]
        [InlineData(1, "{\"Dollar Bill\":1}")]
        [InlineData(.01, "{\"Nickel\":1}")]
        [InlineData(.15, "{\"Dime\":1,\"Nickel\":1}")]
        [InlineData(107.85, "{\"20 Dollar Bill\":5,\"5 Dollar Bill\":1,\"Dollar Bill\":2,\"Quarter\":3,\"Dime\":1}")]
        public void TestChangeResults(decimal change, string expectedResultJSON)
        {
            Assert.NotEmpty(expectedResultJSON);
            var data = new MockPersistence();
            var results = data.ChangeOptions().ToImmutableList().GetChange(change);
            var output = results.ToJson();
            Assert.NotEmpty(output);
            Assert.Equal(output, expectedResultJSON);
        }

        [Fact]
        public void TestPlainCoffeeOrder()
        {
            var rnd = new Random((int) DateTime.UtcNow.Ticks);
            var order = new CoffeeOrder();
            Assert.NotNull(order.Cups);
            Assert.NotNull(order.AvailableSizes());
            Assert.NotEmpty(order.AvailableSizes());
            var coffee = new Coffee
            {
                Name = order.AvailableSizes().ElementAt(rnd.Next(order.AvailableSizes().Count - 1))
            };
            order.Cups.Add(coffee);
            Assert.NotEmpty(order.Cups);
            foreach (var cup in order.Cups)
            {
                Assert.NotNull(cup);
            }
            Assert.True(order.IsValid());
            var cupPrice = order.Sizes().CupPrice(coffee.Name);
            Assert.NotNull(cupPrice);
            Assert.Equal(cupPrice.Price.GetValueOrDefault(), order.Price().Price.GetValueOrDefault());
            order.Payments.Add(cupPrice.Price.GetValueOrDefault());
            AddRandomPayments(order, order.Price().Price.GetValueOrDefault());
            Assert.True(order.CanDispense());
            var receipt = order.End();
            Assert.NotNull(receipt);
            Assert.NotEmpty(receipt.Cups);
            Assert.Equal(receipt.Started, order.Initiated);
            Assert.Equal(receipt.Payments, order.Payments);
            Assert.True(receipt.Sold.HasValue);
            Assert.True(receipt.Sold.GetValueOrDefault() > order.Initiated);
            Assert.Equal(receipt.ChangeDispensed.ToJson(),
                order.Data.AvailableDenominations()
                    .GetChange(order.Payments.Sum() - order.Price().Price.GetValueOrDefault()).ToJson());

        }

        [Fact]
        public void TestCoffeeOrderWithTooManyExtras()
        {
            var rnd = new Random((int)DateTime.UtcNow.Ticks);
            var order = new CoffeeOrder();
            Assert.NotNull(order.Cups);
            Assert.NotNull(order.AvailableAddIns());
            Assert.NotEmpty(order.AvailableAddIns());
            Assert.NotNull(order.AvailableSizes());
            Assert.NotEmpty(order.AvailableSizes());

            var extra = order.AvailableAddIns().ElementAt(rnd.Next(order.AvailableSizes().Count - 1));
            Assert.NotNull(extra);
            var addinRule = order.Data.Addins().FirstOrDefault(z => z.Name == extra);
            Assert.NotNull(addinRule);
            var maxTestTime = DateTime.UtcNow.AddMinutes(1);
            while (addinRule.Maximum.GetValueOrDefault() == 0 && maxTestTime > DateTime.UtcNow)
            {
                extra = order.AvailableAddIns().ElementAt(rnd.Next(order.AvailableSizes().Count - 1));
                Assert.NotNull(extra);
                addinRule = order.Data.Addins().FirstOrDefault(z => z.Name == extra);
                Assert.NotNull(addinRule);
            }
            var coffee = new Coffee
            {
                Extras = Enumerable.Repeat(extra, addinRule.Maximum.GetValueOrDefault() + 1).ToList(),
                Name = order.AvailableSizes().ElementAt(rnd.Next(order.AvailableSizes().Count - 1))
            };
            order.Cups.Add(coffee);
            Assert.NotEmpty(order.Cups);
            foreach (var cup in order.Cups)
            {
                Assert.NotNull(cup);
            }
            Assert.False(order.IsValid());
            var result = order.Price();
            Assert.NotNull(result);
            Assert.NotEmpty(result.Message);
            Assert.False(order.CanDispense());
            AddRandomPayments(order);
            var receipt = order.End();
            Assert.NotNull(receipt);
            Assert.Empty(receipt.Cups);
            Assert.Equal(receipt.Started, order.Initiated);
            Assert.Equal(receipt.Payments, order.Payments);
            Assert.False(receipt.Sold.HasValue);
            Assert.Equal(receipt.ChangeDispensed.ToJson(), order.Data.AvailableDenominations().GetChange(order.Payments.Sum()).ToJson());
        }

        private static void AddRandomPayments(CoffeeOrder order, decimal? minimumAmountToAdd = null)
        {
            var rnd = new Random((int)DateTime.UtcNow.Ticks);
            var availableChangeOptions = order.Data.AvailableDenominations();
            var toAdd = minimumAmountToAdd ?? (decimal) (rnd.NextDouble() * 20);
            while (toAdd > 0)
            {
                var payment = availableChangeOptions.ElementAt(rnd.Next(0, availableChangeOptions.Count() - 1)).Value *
                              rnd.Next(1, 2);
                order.Payments.Add(payment);
                toAdd -= payment;
            }
        }

        [Fact]
        public void TestCoffeeOrderWithExtras()
        {
            var rnd = new Random((int) DateTime.UtcNow.Ticks);
            var order = new CoffeeOrder();
            Assert.NotNull(order.Cups);
            Assert.NotNull(order.AvailableAddIns());
            Assert.NotEmpty(order.AvailableAddIns());
            Assert.NotNull(order.AvailableSizes());
            Assert.NotEmpty(order.AvailableSizes());

            var extra = order.AvailableAddIns().ElementAt(rnd.Next(order.AvailableSizes().Count - 1));
            Assert.NotNull(extra);
            var addinRule = order.Data.Addins().FirstOrDefault(z => z.Name == extra);
            Assert.NotNull(addinRule);
            var maxTestTime = DateTime.UtcNow.AddMinutes(1);
            while (addinRule.Maximum.GetValueOrDefault() == 0 && maxTestTime > DateTime.UtcNow)
            {
                extra = order.AvailableAddIns().ElementAt(rnd.Next(order.AvailableSizes().Count - 1));
                Assert.NotNull(extra);
                addinRule = order.Data.Addins().FirstOrDefault(z => z.Name == extra);
                Assert.NotNull(addinRule);
            }

            var coffee = new Coffee
            {
                Extras = new List<string>
                {
                    order.AvailableAddIns().ElementAt(rnd.Next(order.AvailableSizes().Count - 1))
                },
                Name = order.AvailableSizes().ElementAt(rnd.Next(order.AvailableSizes().Count - 1))
            };
            order.Cups.Add(coffee);
            Assert.NotEmpty(order.Cups);
            foreach (var cup in order.Cups)
            {
                Assert.NotNull(cup);
            }

            Assert.True(order.IsValid());
            var cupPrice = order.Sizes().CupPrice(coffee.Name);
            var extrasPrices = order.Addins().ExtraPrice(coffee.Extras);
            Assert.NotNull(cupPrice);
            Assert.NotNull(extrasPrices);
            Assert.Equal(cupPrice.Price.GetValueOrDefault() + extrasPrices.Price.GetValueOrDefault(),
                order.Price().Price.GetValueOrDefault());

            AddRandomPayments(order, order.Price().Price.GetValueOrDefault());
            Assert.True(order.CanDispense());
            var receipt = order.End();
            Assert.NotNull(receipt);
            Assert.NotEmpty(receipt.Cups);
            Assert.Equal(receipt.Started, order.Initiated);
            Assert.Equal(receipt.Payments, order.Payments);
            Assert.True(receipt.Sold.HasValue);
            Assert.True(receipt.Sold.GetValueOrDefault() > order.Initiated);
            Assert.Equal(receipt.ChangeDispensed.ToJson(),
                order.Data.AvailableDenominations()
                    .GetChange(order.Payments.Sum() - order.Price().Price.GetValueOrDefault()).ToJson());
        }
    }
}
