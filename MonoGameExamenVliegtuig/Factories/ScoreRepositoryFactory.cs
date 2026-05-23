using MonoGameExamenVliegtuig.Core.Interface;
using MonoGameExamenVliegtuig.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Factories
{
    public class ScoreRepositoryFactory
    {
        public static IScoreRepository CreateScoreRepository(string databaseType, string connectionString)
        {
            switch (databaseType.Trim().ToUpper())
            {
                case "SQL":
                    return new ScoreRepository(connectionString);


                default:
                    throw new Exception($"Database type '{databaseType}' wordt niet ondersteund.");
            }
        }
    }
}
