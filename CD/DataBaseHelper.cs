﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CD
{
    public static class DataBaseHelper
    {
        #region "FILL DATA TABLE"
#if DEBUG
        static string _connectionString = "";
#else
        static string _connectionString = ConfigurationManager.ConnectionStrings["conexionRelease"].ToString();
#endif

        public static void Fill(DataTable dataTable, String procedureName)
        {
            SqlConnection oConnection = new SqlConnection(_connectionString);
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
            oCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oAdapter.SelectCommand = oCommand;
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oAdapter.SelectCommand.Transaction = oTransaction;
                    oAdapter.Fill(dataTable);
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                        oConnection.Close();
                    oConnection.Dispose();
                    oAdapter.Dispose();
                }
            }
        }

        public static void Fill(DataTable dataTable, String procedureName, Dictionary<string, object> dictionary)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var par in dictionary)
            {
                parameters.Add(new SqlParameter(par.Key, par.Value));
            }

            Fill(dataTable, procedureName, parameters.ToArray());
        }

        public static void Fill(DataTable dataTable, String procedureName, SqlParameter[] parameters)
        {
            SqlConnection oConnection = new SqlConnection(_connectionString);
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
            oCommand.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
                oCommand.Parameters.AddRange(parameters);

            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oAdapter.SelectCommand = oCommand;
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oAdapter.SelectCommand.Transaction = oTransaction;
                    oAdapter.Fill(dataTable);
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                        oConnection.Close();
                    oConnection.Dispose();
                    oAdapter.Dispose();
                }
            }
        }

        #endregion

        #region "FILL DATASET"

        public static void Fill(DataSet dataSet, String procedureName)
        {
            SqlConnection oConnection = new SqlConnection(_connectionString);
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
            oCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oAdapter.SelectCommand = oCommand;
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oAdapter.SelectCommand.Transaction = oTransaction;
                    oAdapter.Fill(dataSet);
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                        oConnection.Close();
                    oConnection.Dispose();
                    oAdapter.Dispose();
                }
            }
        }

        public static void Fill(DataSet dataSet, String procedureName, SqlParameter[] parameters)
        {
            SqlConnection oConnection = new SqlConnection(_connectionString);
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
            oCommand.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
                oCommand.Parameters.AddRange(parameters);

            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oAdapter.SelectCommand = oCommand;
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oAdapter.SelectCommand.Transaction = oTransaction;
                    oAdapter.Fill(dataSet);
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                        oConnection.Close();
                    oConnection.Dispose();
                    oAdapter.Dispose();
                }
            }
        }

        #endregion

        #region "EXECUTE SCALAR"

        public static object ExecuteScalar(String procedureName)
        {
            SqlConnection oConnection = new SqlConnection(_connectionString);
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);

            oCommand.CommandType = CommandType.StoredProcedure;
            object oReturnValue;
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oCommand.Transaction = oTransaction;
                    oReturnValue = oCommand.ExecuteScalar();
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                        oConnection.Close();
                    oConnection.Dispose();
                    oCommand.Dispose();
                }
            }
            return oReturnValue;
        }

        public static object ExecuteScalar(string procedureName, Dictionary<string, object> dictionary)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var par in dictionary)
            {
                parameters.Add(new SqlParameter(par.Key, par.Value));
            }

            return ExecuteScalar(procedureName, parameters.ToArray());
        }

        public static object ExecuteScalar(String procedureName, SqlParameter[] parameters)
        {
            SqlConnection oConnection = new SqlConnection(_connectionString);
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);

            oCommand.CommandType = CommandType.StoredProcedure;
            object oReturnValue;
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    if (parameters != null)
                        oCommand.Parameters.AddRange(parameters);

                    oCommand.Transaction = oTransaction;
                    oReturnValue = oCommand.ExecuteScalar();
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                        oConnection.Close();
                    oConnection.Dispose();
                    oCommand.Dispose();
                }
            }
            return oReturnValue;
        }

        #endregion

        #region "EXECUTE NON QUERY"

        public static int ExecuteNonQuery(string query)
        {
            SqlConnection oConnection = new SqlConnection(_connectionString);
            SqlCommand oCommand = new SqlCommand(query, oConnection);

            oCommand.CommandType = CommandType.Text;
            int iReturnValue;
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oCommand.Transaction = oTransaction;
                    iReturnValue = oCommand.ExecuteNonQuery();
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                        oConnection.Close();
                    oConnection.Dispose();
                    oCommand.Dispose();
                }
            }
            return iReturnValue;
        }

        public static int ExecuteProcedureNonQuery(string procedureName)
        {
            SqlConnection oConnection = new SqlConnection(_connectionString);
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);

            oCommand.CommandType = CommandType.StoredProcedure;
            int iReturnValue;
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oCommand.Transaction = oTransaction;
                    iReturnValue = oCommand.ExecuteNonQuery();
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                        oConnection.Close();
                    oConnection.Dispose();
                    oCommand.Dispose();
                }
            }
            return iReturnValue;
        }

        public static int ExecuteNonQuery(string procedureName, Dictionary<string, object> dictionary)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var par in dictionary)
            {
                parameters.Add(new SqlParameter(par.Key, par.Value));
            }

            return ExecuteNonQuery(procedureName, parameters.ToArray());
        }

        public static int ExecuteNonQuery(string procedureName, SqlParameter[] parameters)
        {
            SqlConnection oConnection = new SqlConnection(_connectionString);
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);

            oCommand.CommandType = CommandType.StoredProcedure;
            int iReturnValue;
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    if (parameters != null)
                        oCommand.Parameters.AddRange(parameters);

                    oCommand.Transaction = oTransaction;
                    iReturnValue = oCommand.ExecuteNonQuery();
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                        oConnection.Close();
                    oConnection.Dispose();
                    oCommand.Dispose();
                }
            }
            return iReturnValue;
        }

        #endregion

        
    }
}