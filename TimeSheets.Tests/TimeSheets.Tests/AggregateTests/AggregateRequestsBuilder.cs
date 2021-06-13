using System;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Tests.AggregateTests
{
    public class AggregateRequestsBuilder
    {
		/// <summary>Запрос на создание случайной карточки учета</summary>
		public static SheetRequest CreateRandomSheetRequest()
		{
			var request = new SheetRequest()
			{
				Amount = 8,
				ContractId = Guid.NewGuid(),
				Date = DateTime.Now,
				EmployeeId = Guid.NewGuid(),
				ServiceId = Guid.NewGuid(),
			};
			return request;
		}

		/// <summary>Запрос на создание случайного счета</summary>
		public static InvoiceRequest CreateRandomInvoiceRequest()
		{
			var request = new InvoiceRequest()
			{
				ContractId = Guid.NewGuid(),
				DateStart = DateTime.MinValue,
				DateEnd = DateTime.Now,
			};
			return request;
		}

		/// <summary>Запрос на создание случайного клиента</summary>
		public static ClientRequest CreateRandomClientRequest()
		{
			var request = new ClientRequest()
			{
				UserId = Guid.NewGuid(),
			};
			return request;
		}

		/// <summary>Запрос на создание случайного контракта</summary>
		public static ContractRequest CreateRandomContractRequest()
		{
			var request = new ContractRequest()
			{
				Title = "Contract Title",
				DateStart = DateTime.MinValue,
				DateEnd = DateTime.Now,
				Description = "Contract Description",
			};
			return request;
		}

		/// <summary>Запрос на обновление контракта</summary>
		public static ContractRequest CreateRandomContractUpdateRequest()
		{
			var request = new ContractRequest()
			{
				Title = "Contract Title",
				Description = "Contract Description",
			};
			return request;

		}

		/// <summary>Запрос на создание случайного работника</summary>
		public static EmployeeRequest CreateRandomEmployeeRequest()
		{
			var request = new EmployeeRequest()
			{
				UserId = Guid.NewGuid(),
			};
			return request;
		}

		/// <summary>Запрос на создание случайного сервера</summary>
		public static ServiceRequest CreateRandomServiceRequest()
		{
			var request = new ServiceRequest()
			{
				ServiceName = "Service Name",
			};
			return request;
		}

		/// <summary>Запрос на создание случайного пользователя</summary>
		public static UserRequest CreateRandomUserRequest()
		{
			var request = new UserRequest()
			{
				UserName = "UserName",
				Password = "Password",
				Role = "Role",
			};
			return request;
		}
	}
}
