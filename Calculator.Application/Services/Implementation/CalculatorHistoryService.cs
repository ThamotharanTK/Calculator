using Calculator.Domain.Entities;
using Calculator.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Application.Services.Implementation
{
    public class CalculatorHistoryService : ICalculatorHistoryService
    {
        private readonly AppDBContext _appDbContext;
        public CalculatorHistoryService(AppDBContext context)
        {
            _appDbContext = context;
        }
        public async Task Add(CalculatorHistory history)
        {
            _appDbContext.CalculatorHistories.Add(history);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<CalculatorHistory>> GetHistories(int page,int limit)
        {
            int offset = (page - 1) * limit;
            return _appDbContext.CalculatorHistories.OrderByDescending(ch => ch.EvaluateAt).Skip(offset).Take(limit).ToList();
        }
    }
}
