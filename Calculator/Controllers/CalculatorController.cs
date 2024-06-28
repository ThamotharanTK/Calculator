using Calculator.Application.Exceptions;
using Calculator.Application.Services;
using Calculator.Domain.Entities;
using Calculator.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        private readonly ICalculatorHistoryService _calculatorHistoryService;
        public CalculatorController(ICalculatorService calculatorService, ICalculatorHistoryService calculatorHistoryService)
        {
            _calculatorService = calculatorService;
            _calculatorHistoryService = calculatorHistoryService;
        }
        [HttpGet]
        [Route("evaluate")]
        public async Task<IActionResult> Evaluate(string input)
        {
            EvaluateResultModel res = new EvaluateResultModel();
            CalculatorHistory history = new CalculatorHistory();
            try
            {
                //input= HttpUtility.UrlDecode(input);
                var value = await _calculatorService.Evaluate(input);
                history = new CalculatorHistory
                {
                    Succeeded = true,
                    Input = input,
                    Result = value,
                    EvaluateAt = DateTime.Now,
                };
               
                res.Succeeded = true;
                res.Result = value;
                return Ok(res);
            }
            catch (InvalidInputException ex)
            {
                history = new CalculatorHistory
                {
                    Succeeded=false,
                    ErrorMessage = ex.Message,
                    Input = input,
                    Result = 0,
                    EvaluateAt = DateTime.Now,
                };
                res.Succeeded = false;
                res.ErrorMessage = ex.Message;
                return BadRequest(res);
            }
            finally
            {
                await _calculatorHistoryService.Add(history);
            }
        }
        [Authorize]
        [HttpGet]
        [Route("history")]
        public async Task<List<CalculatorHistory>> History(int page, int limit)
        {
            if (page <=0)
            {
                page = 1;
            }
            if (limit <= 0)
            {
                limit = 10;
            }
            return await _calculatorHistoryService.GetHistories(page, limit);
        }
    }
}
