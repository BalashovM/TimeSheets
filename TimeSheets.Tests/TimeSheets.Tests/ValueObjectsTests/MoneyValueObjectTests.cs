using FluentAssertions;
using System;
using TimeSheets.Domain.ValueObjects;
using Xunit;

namespace TimeSheets.Tests.ValueObjectsTests
{
    public class MoneyValueObjectTests
	{
		[Fact]
		public void MoneyValueObject_CreatingFromDecimal()
		{
			var amount = (decimal)(new Random().NextDouble());

			var money = Money.FromDecimal(amount);

			money.Amount.Should().Be(amount);
		}

		[Fact]
		public void MoneyValueObject_DontCreateNegativeAmount()
		{
			var amount = -1m;

			Action act = () => Money.FromDecimal(amount);

			act.Should().Throw<ArgumentException>();
		}
	}
}
