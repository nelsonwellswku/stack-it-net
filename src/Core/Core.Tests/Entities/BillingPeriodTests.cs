﻿using System;

using FluentAssertions;

using Ica.StackIt.Core.Entities;

using NUnit.Framework;

namespace Ica.StackIt.Core.Tests.Entities
{
	public class BillingPeriodTests
	{
		// Equality code is largely untested since it was generated by R#.

		[Test]
		public void CreatesCorrectString()
		{
			BillingPeriod.CreatePeriod(3, 9).PeriodId.Should().Be("0003-09");
		}

		[Test]
		public void CastToString()
		{
			// Arrange
			BillingPeriod p = BillingPeriod.CreatePeriod(2015, 04);

			// Act
			string s = p;

			// Assert
			s.Should().Be("2015-04");
		}

		[Test]
		public void CastFromString()
		{
			// Arrange
			string s = "2015-04";

			// Act
			BillingPeriod p = s;

			// Assert
			p.PeriodId.Should().Be("2015-04");
		}

		[Test]
		public void CastFromBadString()
		{
			// Arrange
			const string invalid = "2015-04-12";

			// Act/Assert
			invalid.Invoking(i => { BillingPeriod p = i; }).ShouldThrow<InvalidCastException>();
		}

		[Test]
		public void EqualsOk()
		{
			BillingPeriod.CreatePeriod(2015, 4)
			             .Should().Be(BillingPeriod.CreatePeriod(2015, 04));

			BillingPeriod.CreatePeriod(2015, 3)
			             .Should().NotBe(BillingPeriod.CreatePeriod(2015, 04));
		}
	}
}