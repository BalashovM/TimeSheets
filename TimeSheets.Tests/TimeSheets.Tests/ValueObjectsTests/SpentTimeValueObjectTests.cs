using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Domain.ValueObjects;
using Xunit;

namespace TimeSheets.Tests.ValueObjectsTests
{
	public class SpentTimeValueObjectTests
	{
		/// <summary>Набор данных для теста которые должны вызывать нормальное поведение</summary>
		/// <returns>Набор данных</returns>
		public static IEnumerable<object[]> GoodData()
		{
			yield return new object[] { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 } };
		}

		[Theory]
		[MemberData(nameof(GoodData))]
		public void SpentTimeValueObject_CreatingFromInt(int[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				var spentTime = SpentTime.FromInt(data[i]);
				spentTime.Amount.Should().Be(data[i]);
			}

		}

		/// <summary>Набор данных для теста которые должны вызывать исключение</summary>
		/// <returns>Набор данных</returns>
		public static IEnumerable<object[]> BadData()
		{
			yield return new object[] { new int[] { -1, 9, 20, 30 } };
		}

		[Theory]
		[MemberData(nameof(BadData))]
		public void SpentTimeValueObject_DontCreateWrongAmount(int[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				Action act = () => SpentTime.FromInt(data[i]);
				act.Should().Throw<ArgumentException>();
			}

		}

	}
}
