﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimesWebService.Services
{
    public interface IPrimesService
    {
        public Task<bool> IsPrime(int x);

        public Task<IEnumerable<int>> GetPrimes(int from, int to);
    }
}
