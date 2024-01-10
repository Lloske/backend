using Lloske.DAL._1._1_Interfaces;
using Lloske.DAL._2._Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.DAL._1._Repositories
{
    public class UserHumanRessourcesInformationRepository : IUserHumanRessourcesInformationRepository
    {
        private readonly DbConnection _DbConnection;

        public UserHumanRessourcesInformationRepository(DbConnection dbConnection)
        {
            _DbConnection = dbConnection;
        }
        public UserHumanRessourcesInformation Mapper(IDataRecord record)
        {
            return new UserHumanRessourcesInformation
            {
                Id = (int)record["Id"],
                Birthdate = (DateTime)record["Birthdate"],
                Birthplace = (string)record["Birthplace"],
                Birthland = (short)record["Birthland"],
                Nationality = (short)record["short"],
                Gender = (short)record["Gender"],
                Address_street = (string)record["Address_street"],
                Adress_postal_code = (string)record["Adress_postal_code"],
                Adress_city = (string)record["Adress_city"],
                Adress_country = (short)record["Adress_country"],
                Iban = (string)record["Iban"],
                Bic = (string)record["Bic"],
                Social_security_number = (string)record["Social_security_number"],
                User_note = (string)record["User_note"],
            };
        }
        public IEnumerable<UserHumanRessourcesInformation> GetAll()
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [user_human_ressources_information]";

                _DbConnection.Open();

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return Mapper(reader);
                    }
                };

                _DbConnection.Close();
            }
        }

        public UserHumanRessourcesInformation? GetById(int id)
        {
            UserHumanRessourcesInformation? result = null;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [user_human_ressources_information] WHERE [Id] = @Id";
                DbParameter paramId = command.CreateParameter();
                paramId.ParameterName = "Id";
                paramId.Value = id;
                command.Parameters.Add(paramId);

                _DbConnection.Open();

                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = Mapper(reader);
                    }
                };
                _DbConnection.Close();
            }

            return result;
        }
        public UserHumanRessourcesInformation Create(UserHumanRessourcesInformation entity)
        {
            UserHumanRessourcesInformation result;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO [user_human_ressources_information] ([Birthdate], [Birthplace], [Birthland], [Nationality], [Gender], [Address_street], [Adress_postal_code], [Adress_city], [Adress_country], [Iban], [Bic], [Social_security_number], [User_note])" +
                    " OUTPUT [inserted].*" +
                    " VALUES (@Birthdate, @Birthplace, @Birthland, @Nationality, @Gender, @Address_street, @Adress_postal_code, @Adress_city, @Adress_country, @Iban, @Bic, @Social_security_number, @User_note)";

                DbParameter paramBirthdate = command.CreateParameter();
                paramBirthdate.ParameterName = "Birthdate";
                paramBirthdate.Value = entity.Birthdate;
                command.Parameters.Add(paramBirthdate);

                DbParameter paramBirthplace = command.CreateParameter();
                paramBirthplace.ParameterName = "Birthplace";
                paramBirthplace.Value = entity.Birthplace;
                command.Parameters.Add(paramBirthplace);

                DbParameter paramBirthland = command.CreateParameter();
                paramBirthland.ParameterName = "Birthland";
                paramBirthland.Value = entity.Birthland;
                command.Parameters.Add(paramBirthland);

                DbParameter paramNationality = command.CreateParameter();
                paramNationality.ParameterName = "Nationality";
                paramNationality.Value = entity.Nationality;
                command.Parameters.Add(paramNationality);

                DbParameter paramGender = command.CreateParameter();
                paramGender.ParameterName = "Gender";
                paramGender.Value = entity.Gender;
                command.Parameters.Add(paramGender);

                DbParameter paramAddress_street = command.CreateParameter();
                paramAddress_street.ParameterName = "Address_street";
                paramAddress_street.Value = entity.Address_street;
                command.Parameters.Add(paramAddress_street);

                DbParameter paramAdress_postal_code = command.CreateParameter();
                paramAdress_postal_code.ParameterName = "Adress_postal_code";
                paramAdress_postal_code.Value = entity.Adress_postal_code;
                command.Parameters.Add(paramAdress_postal_code);

                DbParameter paramAdress_city = command.CreateParameter();
                paramAdress_city.ParameterName = "Adress_city";
                paramAdress_city.Value = entity.Adress_city;
                command.Parameters.Add(paramAdress_city);

                DbParameter paramAdress_country = command.CreateParameter();
                paramAdress_country.ParameterName = "Adress_country";
                paramAdress_country.Value = entity.Adress_country;
                command.Parameters.Add(paramAdress_country);

                DbParameter paramIban = command.CreateParameter();
                paramIban.ParameterName = "Iban";
                paramIban.Value = entity.Iban;
                command.Parameters.Add(paramIban);

                DbParameter paramBic = command.CreateParameter();
                paramBic.ParameterName = "Bic";
                paramBic.Value = entity.Bic;
                command.Parameters.Add(paramBic);

                DbParameter paramSocial_security_number = command.CreateParameter();
                paramSocial_security_number.ParameterName = "Social_security_number";
                paramSocial_security_number.Value = entity.Social_security_number;
                command.Parameters.Add(paramSocial_security_number);

                _DbConnection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = Mapper(reader);
                    }
                    else
                    {
                        throw new Exception("Erreur lors de la création de l'utilisateur");
                    }
                }
                _DbConnection.Close();

            };
            return result;
        }

        public bool Update(int id, UserHumanRessourcesInformation entity)
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText =
                    "UPDATE FROM [user_human_ressources_information]" +
                    "SET    [Birthdate] = @Birthdate" +
                    "       [Birthplace] = @Birthplace" +
                    "       [Birthland] = @Birthland" +
                    "       [Nationality] = @Nationality" +
                    "       [Gender] = @Gender" +
                    "       [Address_street] = @Address_street" +
                    "       [Adress_postal_code] = @Adress_postal_code" +
                    "       [Adress_city] = @Adress_city" +
                    "       [Adress_country] = @Adress_country" +
                    "       [Iban] = @Iban" +
                    "       [Bic] = @Bic" +
                    "       [Social_security_number] = @Social_security_number" +
                    "       [User_note] = @User_note";

                DbParameter paramBirthdate = command.CreateParameter();
                paramBirthdate.ParameterName = "Birthdate";
                paramBirthdate.Value = entity.Birthdate;
                command.Parameters.Add(paramBirthdate);

                DbParameter paramBirthplace = command.CreateParameter();
                paramBirthplace.ParameterName = "Birthplace";
                paramBirthplace.Value = entity.Birthplace;
                command.Parameters.Add(paramBirthplace);

                DbParameter paramBirthland = command.CreateParameter();
                paramBirthland.ParameterName = "Birthland";
                paramBirthland.Value = entity.Birthland;
                command.Parameters.Add(paramBirthland);

                DbParameter paramNationality = command.CreateParameter();
                paramNationality.ParameterName = "Nationality";
                paramNationality.Value = entity.Nationality;
                command.Parameters.Add(paramNationality);

                DbParameter paramGender = command.CreateParameter();
                paramGender.ParameterName = "Gender";
                paramGender.Value = entity.Gender;
                command.Parameters.Add(paramGender);

                DbParameter paramAddress_street = command.CreateParameter();
                paramAddress_street.ParameterName = "Address_street";
                paramAddress_street.Value = entity.Address_street;
                command.Parameters.Add(paramAddress_street);

                DbParameter paramAdress_postal_code = command.CreateParameter();
                paramAdress_postal_code.ParameterName = "Adress_postal_code";
                paramAdress_postal_code.Value = entity.Adress_postal_code;
                command.Parameters.Add(paramAdress_postal_code);

                DbParameter paramAdress_city = command.CreateParameter();
                paramAdress_city.ParameterName = "Adress_city";
                paramAdress_city.Value = entity.Adress_city;
                command.Parameters.Add(paramAdress_city);

                DbParameter paramAdress_country = command.CreateParameter();
                paramAdress_country.ParameterName = "Adress_country";
                paramAdress_country.Value = entity.Adress_country;
                command.Parameters.Add(paramAdress_country);

                DbParameter paramIban = command.CreateParameter();
                paramIban.ParameterName = "Iban";
                paramIban.Value = entity.Iban;
                command.Parameters.Add(paramIban);

                DbParameter paramBic = command.CreateParameter();
                paramBic.ParameterName = "Bic";
                paramBic.Value = entity.Bic;
                command.Parameters.Add(paramBic);

                DbParameter paramSocial_security_number = command.CreateParameter();
                paramSocial_security_number.ParameterName = "Social_security_number";
                paramSocial_security_number.Value = entity.Social_security_number;
                command.Parameters.Add(paramSocial_security_number);

                _DbConnection.Open();
                int nbRowUpdated = command.ExecuteNonQuery();
                _DbConnection.Close();

                return nbRowUpdated == 1;
            }
        }

        public bool Delete(int id)
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "DELETE FROM [user_human_ressources_information] WHERE [Id] = @Id";

                DbParameter paramId = command.CreateParameter();
                paramId.ParameterName = "Id";
                paramId.Value = id;
                command.Parameters.Add(paramId);

                _DbConnection.Open();
                int nbRowDeleted = command.ExecuteNonQuery();
                _DbConnection.Close();

                return nbRowDeleted == 1; // Retourne true si exactement 1 ligne à été supprimée, retourne false sinon
            }
        }

        
    }
}
