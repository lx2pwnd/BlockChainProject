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
        [Route("currentblock")]
        public object Get()
        {
            try
            {
                var connectionString = "Server=blockchainclientSQLdb;Initial Catalog=BlockChainProject;User Id=sa;Password=ForzaInterSempre69!;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String sql = "SELECT TOP 1 * " +
                        "FROM [BlockChainProject].dbo.[Block_Values] " +
                        "WHERE IsGenerated = 0 " +
                        "ORDER BY BlockNumberID ASC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new Block()
                                {
                                    BlockValueString = reader["BlockValueString"].ToString(),
                                    BlockNumberID = Convert.ToInt32(reader["BlockNumberID"]),
                                    SaltUsing = Convert.ToInt32(reader["SaltUsing"]),
                                    IsGenerated = Convert.ToBoolean(reader["IsGenerated"])
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
