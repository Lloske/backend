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
    public class UserPayrollDataRepository : IUserPayrollDataRepository
    {
        private readonly DbConnection _DbConnection;
        public UserPayrollDataRepository(DbConnection dbConnection)
        {
            _DbConnection = dbConnection;
        }
        public UserPayrollData Mapper(IDataRecord record)
        {
            return new UserPayrollData
            {
                Id = (short)record["Id"],
                Work_time_measurement = (short)record["Work_time_measurement"],
                Maximum_contract_hours = (short)record["Maximum_contract_hours"],
                Id_user_personnal_information = (short)record["Id_user_personnal_information"],
            };
        }
        public IEnumerable<UserPayrollData> GetAll()
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [user_payroll_data]";

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
        public UserPayrollData? GetById(int id)
        {
            UserPayrollData? result = null;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [user_payroll_data] WHERE [Id] = @Id";
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
        public UserPayrollData Create(UserPayrollData entity)
        {
            UserPayrollData result;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                // L'id n'est pas ajouté. Voir comment faire avec GUID et si auto incrémentation est ok
                command.CommandText =
                    "INSERT INTO [user_payroll_data] ([Work_time_measurement], [Maximum_contract_hours], [Id_user_personnal_information]" +
                    " OUTPUT [inserted].*" +
                    " VALUES (@Work_time_measurement, @Maximum_contract_hours, @Id_user_personnal_information)";

                DbParameter paramWork_time_measurement = command.CreateParameter();
                paramWork_time_measurement.ParameterName = "Work_time_measurement";
                paramWork_time_measurement.Value = entity.Work_time_measurement;
                command.Parameters.Add(paramWork_time_measurement);

                DbParameter paramMaximum_contract_hours = command.CreateParameter();
                paramMaximum_contract_hours.ParameterName = "Maximum_contract_hours";
                paramMaximum_contract_hours.Value = entity.Maximum_contract_hours;
                command.Parameters.Add(paramMaximum_contract_hours);

                DbParameter paramId_user_personnal_information = command.CreateParameter();
                paramId_user_personnal_information.ParameterName = "Id_user_personnal_information";
                paramId_user_personnal_information.Value = entity.Id_user_personnal_information;
                command.Parameters.Add(paramId_user_personnal_information);

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
        public bool Update(int id, UserPayrollData entity)
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText =
                    "UPDATE FROM [user_payroll_data]" +
                    "SET    [Work_time_measurement] = @Work_time_measurement" +
                    "       [Maximum_contract_hours] = @Maximum_contract_hours" +
                    "       [Id_user_personnal_information] = @Id_user_personnal_information";

                DbParameter paramWork_time_measurement = command.CreateParameter();
                paramWork_time_measurement.ParameterName = "Work_time_measurement";
                paramWork_time_measurement.Value = entity.Work_time_measurement;
                command.Parameters.Add(paramWork_time_measurement);

                DbParameter paramMaximum_contract_hours = command.CreateParameter();
                paramMaximum_contract_hours.ParameterName = "Maximum_contract_hours";
                paramMaximum_contract_hours.Value = entity.Maximum_contract_hours;
                command.Parameters.Add(paramMaximum_contract_hours);

                DbParameter paramId_user_personnal_information = command.CreateParameter();
                paramId_user_personnal_information.ParameterName = "Id_user_personnal_information";
                paramId_user_personnal_information.Value = entity.Id_user_personnal_information;
                command.Parameters.Add(paramId_user_personnal_information);

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
                command.CommandText = "DELETE FROM [user_payroll_data] WHERE [Id] = @Id";

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
