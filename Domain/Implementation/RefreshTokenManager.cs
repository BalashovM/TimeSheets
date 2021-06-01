using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
    public class RefreshTokenManager : IRefreshTokenManager // IRefreshTokenManager
    {
        private readonly IRefreshTokenRepo _refreshTokenRepo;

        public RefreshTokenManager(IRefreshTokenRepo refreshTokenRepo)
        {
            _refreshTokenRepo = refreshTokenRepo;
        }

        public async Task<RefreshToken> GetItem(RefreshTokenRequest request)
        {
            return await _refreshTokenRepo.GetItem(id);
        }

        public async void CreateOrUpdate(RefreshTokenRequest request)
        {
            var tokenFromBase = await _refreshTokenRepo.GetItem(request. .UserId);
            if (tokenFromBase.Token == null)
            {
                await _refreshTokenRepo.Add(token);
            }
            else
            {
                await _refreshTokenRepo.Update(token);
            }
        }

        public void CreateOrUpdate(RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RefreshToken>> GetItems(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Create(RefreshTokenRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, RefreshTokenRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}