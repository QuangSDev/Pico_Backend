using Dapper;
using MySqlConnector;
using Pico_Backend.Interface;
using Pico_Backend.Models;
using System;
using System.Data;
using System.Data.Common;

namespace Pico_Backend.Repository
{
    public class GroupConfigRepository : IGroupConfigRepository
    {
        #region Field
        private readonly DbConnection _connection;
        private string GetGroupConfigCommandText = "select gfc.GroupFieldConfigID, gfc.Label,gfc.FieldName,gfc.FieldType,gfc.IsRequired,gfc.Placeholder,gfc.`Column`,gfc.ErrorText,gfc.DropdownListID,gc.GroupConfigID,gc.GroupName,gc.GroupType, (SELECT JSON_ARRAYAGG(JSON_OBJECT('ID', ID, 'Name', Name)) FROM group_field_config gfc2 INNER JOIN dropdown_options do ON gfc2.DropdownListID = do.DropdownListID) AS DropDownList FROM group_field_config gfc INNER JOIN group_config gc ON gc.GroupConfigID = gfc.GroupConfigID WHERE gc.GroupConfigID = @id;";
        #endregion
        public GroupConfigRepository(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public async Task<IEnumerable<GroupConfig>> GetGroupConfig(int groupConfigID)
        {
             _connection.Open();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("id", groupConfigID);
            var result = await _connection.QueryAsync<GroupConfig>(GetGroupConfigCommandText, param: dynamicParameters);
            await _connection.CloseAsync();
            return result;      
        }

    }

}
