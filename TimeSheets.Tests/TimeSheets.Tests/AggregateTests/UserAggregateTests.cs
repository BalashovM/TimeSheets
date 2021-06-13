using FluentAssertions;
using System.Security.Cryptography;
using System.Text;
using TimeSheets.Domain.Aggregates.UserAggregate;
using Xunit;

namespace TimeSheets.Tests.AggregateTests
{
    public class UserAggregateTests
	{
		[Fact]
		public void UserAggregate_CreateRandomFromRequest()
		{
			var request = AggregateRequestsBuilder.CreateRandomUserRequest();
			
			var user = UserAggregate.CreateFromRequest(request);

			user.UserName.Should().Be(request.UserName);
			user.RefreshToken.Should().Be(string.Empty);
			user.IsDeleted.Should().BeFalse();

			PasswordHashCompare(user.PasswordHash, GetPasswordHash(request.Password)).Should().BeTrue();
		}

		[Fact]
		public void UserAggregate_UpdateRandomFromRequest()
		{
			var createRequest = AggregateRequestsBuilder.CreateRandomUserRequest();
			var user = UserAggregate.CreateFromRequest(createRequest);
			var updateRequest = AggregateRequestsBuilder.CreateRandomUserRequest();

			user.UpdateFromRequest(updateRequest);

			user.UserName.Should().Be(updateRequest.UserName);
			user.RefreshToken.Should().Be(string.Empty);
			user.IsDeleted.Should().BeFalse();

			PasswordHashCompare(user.PasswordHash, GetPasswordHash(updateRequest.Password)).Should().BeTrue();
		}


		[Fact]
		public void UserAggregate_ShouldBeDeleted()
		{
			var request = AggregateRequestsBuilder.CreateRandomUserRequest();
			var user = UserAggregate.CreateFromRequest(request);

			user.DeleteUser();

			user.IsDeleted.Should().BeTrue();
		}

		[Fact]
		public void UserAggregate_ShouldBeRefreshTokenUpdated()
		{
			var request = AggregateRequestsBuilder.CreateRandomUserRequest();
			var user = UserAggregate.CreateFromRequest(request);
			var newRefreshToken = "New Refresh Token";

			user.UpdateRefreshToken(newRefreshToken);

			user.RefreshToken.Should().Be(newRefreshToken);
		}

		///<summary>Сравнение хэшей паролей</summary>
		private bool PasswordHashCompare(byte[] hash1, byte[] hash2)
		{
			bool isEqual = true;

			if (hash1.Length == hash2.Length)
			{
				for (int i = 0; i < hash1.Length; i++)
				{
					isEqual = (hash1[i] == hash2[i]) ? isEqual : false;
				}
			}
			else
			{
				isEqual = false;
			}

			return isEqual;
		}

		/// <summary> Генерация хэш пароля
		private static byte[] GetPasswordHash(string password)
		{
			using (var sha1 = new SHA1CryptoServiceProvider())
			{
				return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
			}
		}
	}
}

