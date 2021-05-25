using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;

namespace BlockChainAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockChainApiRetriever : ControllerBase
    {
        private readonly ILogger<BlockChainApiRetriever> _logger;

        public BlockChainApiRetriever(ILogger<BlockChainApiRetriever> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetCurrentBlock")]
        public object Get()
        {
            try
            {
                var connectionString = "Server=blockchainclientSQLdb;Initial Catalog=BlockChainProject;User Id=sa;Password=ForzaInterSempre69!;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String sql = "SELECT * " +
                        "FROM [BlockChainProject].dbo.[Block_Values] " +
                        "WHERE [Current] = 1 ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new Block()
                                {
                                    BlockValueString = reader["BlockValueString"].ToString(),
                                    Current = Convert.ToBoolean(reader["Current"]),
                                    Generated = Convert.ToBoolean(reader["Generated"])
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }
    }
}
