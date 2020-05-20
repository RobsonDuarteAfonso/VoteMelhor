using System.Collections.Generic;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class QueryResult : IQueryResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public IEnumerable<object> Datas { get; set; }

        public QueryResult()
        {

        }

        public QueryResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public QueryResult(bool success, string message, IEnumerable<object> datas)
        {
            Success = success;
            Message = message;
            Datas = datas;
        }
    }
}