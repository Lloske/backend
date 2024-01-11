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
    public class UserContractInformationRepository : IUserContractInformationRepository
    {
        private readonly DbConnection _DbConnection;

        public UserContractInformationRepository(DbConnection dbConnection)
        {
            _DbConnection = dbConnection;
        }
        public UserContractInformation Mapper(IDataRecord record)
        {
            return new UserContractInformation
            {
                Id = (int)record["Id"],
                Contract_type = (short)record["Contract_type"],
                Employment_type = (short)record["Employment_type"],
                Job_title = (string)record["Job_title"],
                Organization_entry_date = (DateTime)record["Organization_entry_date"],
                Contract_start = (DateTime)record["Contract_start"],
                Probation_end_date = (DateTime)record["Probation_end_date"],
                Contract_end = (DateTime)record["Contract_end"],
                Status = (short)record["Status"],
                Professional_category = (short)record["Professional_category"],
                Last_medical_checkup_date = (DateTime)record["Last_medical_checkup_date"],
                FK_id_user_personnal_information = (int)record["FK_id_user_personnal_information"],
            };
        }
        public IEnumerable<UserContractInformation> GetAll()
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [user_contract_information]";

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
        public UserContractInformation? GetById(int id)
        {
            UserContractInformation? result = null;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [user_contract_information] WHERE [FK_id_user_personnal_information] = @Id";
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
        public UserContractInformation Create(UserContractInformation entity)
        {
            UserContractInformation result;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO [user_contract_information] ([Contract_type], [Employment_type], [Job_title], [Organization_entry_date], [Contract_start], [Probation_end_date], [Contract_end], [Status], [Professional_category], [Last_medical_checkup_date], [FK_id_user_personnal_information])" +
                    " OUTPUT [inserted].*" +
                    " VALUES (@Contract_type, @Employment_type, @Job_title, @Organization_entry_date, @Contract_start, @Probation_end_date, @Contract_end, @Status, @Professional_category, @Last_medical_checkup_date, @FK_id_user_personnal_information)";

                DbParameter paramContract_type = command.CreateParameter();
                paramContract_type.ParameterName = "Contract_type";
                paramContract_type.Value = entity.Contract_type;
                command.Parameters.Add(paramContract_type);

                DbParameter paramEmployment_type = command.CreateParameter();
                paramEmployment_type.ParameterName = "Employment_type";
                paramEmployment_type.Value = entity.Employment_type;
                command.Parameters.Add(paramEmployment_type);

                DbParameter paramJob_title = command.CreateParameter();
                paramJob_title.ParameterName = "Job_title";
                paramJob_title.Value = entity.Job_title;
                command.Parameters.Add(paramJob_title);

                DbParameter paramOrganization_entry_date = command.CreateParameter();
                paramOrganization_entry_date.ParameterName = "Organization_entry_date";
                paramOrganization_entry_date.Value = entity.Organization_entry_date;
                command.Parameters.Add(paramOrganization_entry_date);

                DbParameter paramContract_start = command.CreateParameter();
                paramContract_start.ParameterName = "Contract_start";
                paramContract_start.Value = entity.Contract_start;
                command.Parameters.Add(paramContract_start);

                DbParameter paramProbation_end_date = command.CreateParameter();
                paramProbation_end_date.ParameterName = "Probation_end_date";
                paramProbation_end_date.Value = entity.Probation_end_date;
                command.Parameters.Add(paramProbation_end_date);

                DbParameter paramContract_end = command.CreateParameter();
                paramContract_end.ParameterName = "Contract_end";
                paramContract_end.Value = entity.Contract_end;
                command.Parameters.Add(paramContract_end);

                DbParameter paramStatus = command.CreateParameter();
                paramStatus.ParameterName = "Status";
                paramStatus.Value = entity.Status;
                command.Parameters.Add(paramStatus);

                DbParameter paramProfessional_category = command.CreateParameter();
                paramProfessional_category.ParameterName = "Professional_category";
                paramProfessional_category.Value = entity.Professional_category;
                command.Parameters.Add(paramProfessional_category);

                DbParameter paramLast_medical_checkup_date = command.CreateParameter();
                paramLast_medical_checkup_date.ParameterName = "Last_medical_checkup_date";
                paramLast_medical_checkup_date.Value = entity.Last_medical_checkup_date;
                command.Parameters.Add(paramLast_medical_checkup_date);

                DbParameter paramFK_id_user_personnal_information = command.CreateParameter();
                paramFK_id_user_personnal_information.ParameterName = "FK_id_user_personnal_information";
                paramFK_id_user_personnal_information.Value = entity.FK_id_user_personnal_information;
                command.Parameters.Add(paramFK_id_user_personnal_information);

                _DbConnection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = Mapper(reader);
                    }
                    else
                    {
                        throw new Exception("Erreur lors de la création du contrat de l'utilisateur");
                    }
                }
                _DbConnection.Close(); 

            };
            return result;
        }
        public bool Update(int id, UserContractInformation entity)
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText =
                    "UPDATE FROM [user_contract_information]" +
                    "SET    [Contract_type] = @Contract_type" +
                    "       [Employment_type] = @Employment_type" +
                    "       [Job_title] = @Job_title" +
                    "       [Organization_entry_date] = @Organization_entry_date" +
                    "       [Contract_start] = @Contract_start" +
                    "       [Probation_end_date] = @Probation_end_date" +
                    "       [Contract_end] = @Contract_end" +
                    "       [Status] = @Status" +
                    "       [Professional_category] = @Professional_category" +
                    "       [Last_medical_checkup_date] = @Last_medical_checkup_date" +
                    "       [FK_id_user_personnal_information] = @FK_id_user_personnal_information";

                DbParameter paramContract_type = command.CreateParameter();
                paramContract_type.ParameterName = "Contract_type";
                paramContract_type.Value = entity.Contract_type;
                command.Parameters.Add(paramContract_type);

                DbParameter paramEmployment_type = command.CreateParameter();
                paramEmployment_type.ParameterName = "Employment_type";
                paramEmployment_type.Value = entity.Employment_type;
                command.Parameters.Add(paramEmployment_type);

                DbParameter paramJob_title = command.CreateParameter();
                paramJob_title.ParameterName = "Job_title";
                paramJob_title.Value = entity.Job_title;
                command.Parameters.Add(paramJob_title);

                DbParameter paramOrganization_entry_date = command.CreateParameter();
                paramOrganization_entry_date.ParameterName = "Organization_entry_date";
                paramOrganization_entry_date.Value = entity.Organization_entry_date;
                command.Parameters.Add(paramOrganization_entry_date);

                DbParameter paramContract_start = command.CreateParameter();
                paramContract_start.ParameterName = "Contract_start";
                paramContract_start.Value = entity.Contract_start;
                command.Parameters.Add(paramContract_start);

                DbParameter paramProbation_end_date = command.CreateParameter();
                paramProbation_end_date.ParameterName = "Probation_end_date";
                paramProbation_end_date.Value = entity.Probation_end_date;
                command.Parameters.Add(paramProbation_end_date);

                DbParameter paramContract_end = command.CreateParameter();
                paramContract_end.ParameterName = "Contract_end";
                paramContract_end.Value = entity.Contract_end;
                command.Parameters.Add(paramContract_end);

                DbParameter paramStatus = command.CreateParameter();
                paramStatus.ParameterName = "Status";
                paramStatus.Value = entity.Status;
                command.Parameters.Add(paramStatus);

                DbParameter paramProfessional_category = command.CreateParameter();
                paramProfessional_category.ParameterName = "Professional_category";
                paramProfessional_category.Value = entity.Professional_category;
                command.Parameters.Add(paramProfessional_category);

                DbParameter paramFK_id_user_personnal_information = command.CreateParameter();
                paramFK_id_user_personnal_information.ParameterName = "FK_id_user_personnal_information";
                paramFK_id_user_personnal_information.Value = entity.FK_id_user_personnal_information;
                command.Parameters.Add(paramFK_id_user_personnal_information);

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
                command.CommandText = "DELETE FROM [user_contract_information] WHERE [FK_id_user_personnal_information] = @Id";

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
