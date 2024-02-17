using Lloske.DAL._2._Entities;
using Lloske.DAL._1._1_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.DAL._1._Repositories
{
    public class UserPersonnalInformationRepository : IUserPersonnalInformationRepository
    {
        private readonly DbConnection _DbConnection;
        public UserPersonnalInformationRepository(DbConnection dbConnection)
        {
            _DbConnection = dbConnection;
        }
        public UserPersonnalInformation Mapper(IDataRecord record)
        {
            return new UserPersonnalInformation
            {
                Id = (int)record["Id"],
                Firstname = (string)record["Firstname"],
                Lastname = (string)record["Lastname"],
                Payroll_identity = (string)record["Payroll_identity"],
                Email = (string)record["Email"],
                Phone = (string)record["Phone"],
                Is_in_employee_registrer = (bool)record["Is_in_employee_registrer"],
                Is_archived = (bool)record["Is_archived"],
                Password_hash = (string)record["Password_hash"],
                Password_salt = (string)record["Password_salt"],
            };
        }

        public IEnumerable<UserPersonnalInformation> GetAll()
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [user_personnal_information]";

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
        public UserPersonnalInformation? GetById(int id)
        {
            UserPersonnalInformation? result = null;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [user_personnal_information] WHERE [Id] = @Id";
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
        public bool Update(int id, UserPersonnalInformation entity)
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText =
                    "UPDATE FROM [user_personnal_information]" +
                    "SET    [Firstname] = @Firstname" +
                    "       [Lastname] = @Lastname" +
                    "       [Payroll_identity] = @Payroll_identity" +
                    "       [Email] = @Email" +
                    "       [Phone] = @Phone" +
                    "       [Is_in_employee_registrer] = @Is_in_employee_registrer" +
                    "       [Is_archived] = @Is_archived" +
                    "       [Password_hash] = @Password_hash" +
                    "       [Password_salt] = @Password_salt";

                DbParameter paramFirstname = command.CreateParameter();
                paramFirstname.ParameterName = "Firstname";
                paramFirstname.Value = entity.Firstname;
                command.Parameters.Add(paramFirstname);

                DbParameter paramLastname = command.CreateParameter();
                paramLastname.ParameterName = "Lastname";
                paramLastname.Value = entity.Lastname;
                command.Parameters.Add(paramLastname);

                DbParameter paramPayroll_identity = command.CreateParameter();
                paramPayroll_identity.ParameterName = "Payroll_identity";
                paramPayroll_identity.Value = entity.Payroll_identity;
                command.Parameters.Add(paramPayroll_identity);

                DbParameter paramEmail = command.CreateParameter();
                paramEmail.ParameterName = "Email";
                paramEmail.Value = entity.Email;
                command.Parameters.Add(paramEmail);

                DbParameter paramPhone = command.CreateParameter();
                paramPhone.ParameterName = "Phone";
                paramPhone.Value = entity.Phone;
                command.Parameters.Add(paramPhone);

                DbParameter paramIs_in_employee_registrer = command.CreateParameter();
                paramIs_in_employee_registrer.ParameterName = "Is_in_employee_registrer";
                paramIs_in_employee_registrer.Value = entity.Is_in_employee_registrer;
                command.Parameters.Add(paramIs_in_employee_registrer);

                DbParameter paramIs_archived = command.CreateParameter();
                paramIs_archived.ParameterName = "Is_archived";
                paramIs_archived.Value = entity.Is_archived;
                command.Parameters.Add(paramIs_archived);

                DbParameter paramPassword_hash = command.CreateParameter();
                paramPassword_hash.ParameterName = "Password_hash";
                paramPassword_hash.Value = entity.Password_hash;
                command.Parameters.Add(paramPassword_hash);

                DbParameter paramPassword_salt = command.CreateParameter();
                paramPassword_salt.ParameterName = "Password_salt";
                paramPassword_salt.Value = entity.Password_salt;
                command.Parameters.Add(paramPassword_salt);

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
                command.CommandText = "DELETE FROM [user_personnal_information] WHERE [Id] = @Id";

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
        public UserPersonnalInformation Create(UserPersonnalInformation entity)
        {
            UserPersonnalInformation result;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO [user_personnal_information] ([Firstname], [Lastname], [Payroll_identity], [Email], [Phone], [Is_in_employee_registrer], [Is_archived], [Password_hash], [Password_salt])" +
                    " OUTPUT [inserted].*" +
                    " VALUES (@Firstname, @Lastname, @Payroll_identity, @Email, @Phone, @Is_in_employee_registrer, @Is_archived, @Password_hash, @Password_salt)";

                DbParameter paramFirstname = command.CreateParameter();
                paramFirstname.ParameterName = "Firstname";
                paramFirstname.Value = entity.Firstname;
                command.Parameters.Add(paramFirstname);

                DbParameter paramLastname = command.CreateParameter();
                paramLastname.ParameterName = "Lastname";
                paramLastname.Value = entity.Lastname;
                command.Parameters.Add(paramLastname);

                DbParameter paramPayroll_identity = command.CreateParameter();
                paramPayroll_identity.ParameterName = "Payroll_identity";
                paramPayroll_identity.Value = entity.Payroll_identity;
                command.Parameters.Add(paramPayroll_identity);

                DbParameter paramEmail = command.CreateParameter();
                paramEmail.ParameterName = "Email";
                paramEmail.Value = entity.Email;
                command.Parameters.Add(paramEmail);

                DbParameter paramPhone = command.CreateParameter();
                paramPhone.ParameterName = "Phone";
                paramPhone.Value = entity.Phone;
                command.Parameters.Add(paramPhone);

                DbParameter paramIs_in_employee_registrer = command.CreateParameter();
                paramIs_in_employee_registrer.ParameterName = "Is_in_employee_registrer";
                paramIs_in_employee_registrer.Value = entity.Is_in_employee_registrer;
                command.Parameters.Add(paramIs_in_employee_registrer);

                DbParameter paramIs_archived = command.CreateParameter();
                paramIs_archived.ParameterName = "Is_archived";
                paramIs_archived.Value = entity.Is_archived;
                command.Parameters.Add(paramIs_archived);

                DbParameter paramPassword_hash = command.CreateParameter();
                paramPassword_hash.ParameterName = "Password_hash";
                paramPassword_hash.Value = entity.Password_hash;
                command.Parameters.Add(paramPassword_hash);

                DbParameter paramPassword_salt = command.CreateParameter();
                paramPassword_salt.ParameterName = "Password_salt";
                paramPassword_salt.Value = entity.Password_salt;
                command.Parameters.Add(paramPassword_salt);

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
    }
}