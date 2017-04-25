//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Common;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Collections.Concurrent;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Reflection;

namespace Gravitybox.LocationService.EFDAL
{
	#region DBHelper
	internal static partial class DBHelper
	{
		internal static IDbConnection GetConnection()
		{
			return GetConnection(Gravitybox.LocationService.EFDAL.LocationServiceEntities.GetConnectionString());
		}

		internal static IDbConnection GetConnection(string connectionString)
		{
			return new SqlConnection(connectionString);
		}

		internal static IDbCommand GetCommand(string commandText, CommandType commandType, IDbConnection connection)
		{
			var cmd = new SqlCommand(commandText);
			cmd.CommandType = commandType;
			cmd.Connection = (SqlConnection)connection;
			return cmd;
		}

		internal static void AddParameter(IDbCommand cmd, string parameterName, object value)
		{
			var sqlParam = new SqlParameter(parameterName, value);
			cmd.Parameters.Add(sqlParam);
		}

		internal static void AddReturnParameter(IDbCommand cmd)
		{
			var sqlParam = new SqlParameter();
			sqlParam.ParameterName = "@RETURN_VALUE";
			sqlParam.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(sqlParam);
		}
	}
	#endregion

	#region Util
	internal static partial class Util
	{
		public static string HashPK(params object[] p)
		{
			var retval = string.Empty;
			for (var ii = 0; ii < p.Length; ii++)
			{
				retval += p[ii] + "|" + ii + "|";
			}
			return retval;
		}

		public static UInt64 HashFast(string read)
		{
			UInt64 hashedValue = 3074457345618258791ul;
			for (int i = 0; i < read.Length; i++)
			{
				hashedValue += read[i];
				hashedValue *= 3074457345618258799ul;
			}
			return hashedValue;
		}

		internal static string ConvertNormalCS2EFFromConfig(string configSettings)
		{
			return ConvertNormalCS2EFFromConfig(configSettings, new ContextStartup(string.Empty, false));
		}

		private static Dictionary<string, string> _csConvertCache = new Dictionary<string, string>();
		internal static string ConvertNormalCS2EFFromConfig(string configSettings, ContextStartup contextStartup)
		{
			if (string.IsNullOrEmpty(configSettings)) return configSettings;
			var arr = configSettings.Split('=');
			if (arr.Length != 2) return configSettings;
			if (arr[0] != "name") return configSettings;
			try
			{
				var cs = System.Configuration.ConfigurationManager.ConnectionStrings[arr[1]].ConnectionString;
				if (!cs.StartsWith("metadata=")) return ConvertNormalCS2EF(cs, contextStartup);
				return configSettings;
			}
			catch
			{
				return configSettings;
			}
		}

		internal static string ConvertNormalCS2EF(string connectionString)
		{
			return ConvertNormalCS2EF(connectionString, new ContextStartup(string.Empty, false));
		}

		internal static string ConvertNormalCS2EF(string connectionString, ContextStartup contextStartup)
		{
			return ConvertNormalCS2EFFromConfig(connectionString, contextStartup);
		}

		internal static string StripEFCS2Normal(string connectionString)
		{
			const string PROVIDER = "provider connection string";
			if (connectionString.StartsWith("metadata="))
			{
				var retval = string.Empty;
				var index = connectionString.IndexOf(PROVIDER);

				var index1 = -1;
				var index2 = -1;
				if (index == -1) return connectionString;

				var foundEQ = false;
				for (var ii = index + PROVIDER.Length; ii < connectionString.Length; ii++)
				{
					if (connectionString[ii] == '=')
					{
						foundEQ = true;
					}
					else if (foundEQ)
					{
						connectionString = connectionString.Substring(ii, connectionString.Length - ii);
						index1 = connectionString.IndexOf('"');
						index2 = connectionString.LastIndexOf('"');
					}

					if (index1 != -1 && index2 != -1)
					{
						return connectionString.Substring(index1 + 1, index2 - index1 - 1);
					}

				}

			}
			return connectionString;
		}

	}
	#endregion

	#region AuditTypeConstants Enumeration

	/// <summary>
	/// A set of values for the types of audits
	/// </summary>
	public enum AuditTypeConstants
	{
		/// <summary>
		/// Represents a row insert
		/// </summary>
		Insert = 1,
		/// <summary>
		/// Represents a row update
		/// </summary>
		Update = 2,
		/// <summary>
		/// Represents a row delete
		/// </summary>
		Delete = 3,
	}

	#endregion

	#region IAudit
	/// <summary>
	/// The base interface for all audit objects
	/// </summary>
	public interface IAudit
	{
		/// <summary>
		/// The type of audit
		/// </summary>
		AuditTypeConstants AuditType { get; }

		/// <summary>
		/// The date of the audit
		/// </summary>
		DateTime AuditDate { get; }

		/// <summary>
		/// The modifier value of the audit
		/// </summary>
		string ModifiedBy { get; }
	}
	#endregion

	#region ICreatable
	/// <summary />
	public partial interface ICreatable
	{
	}
	#endregion

	#region IAuditable
	/// <summary />
	internal partial interface IAuditableSet
	{
		DateTime? CreatedDate { get; set; }
		DateTime? ModifiedDate { get; set; }
		string ModifiedBy { get; set; }
		string CreatedBy { get; set; }
		void ResetCreatedBy(string modifier);
		void ResetModifiedBy(string modifier);
	}

	/// <summary />
	public partial interface IAuditable
	{
		/// <summary />
		bool IsCreateAuditImplemented { get; }
		/// <summary />
		bool IsModifyAuditImplemented { get; }
		/// <summary />
		bool IsTimestampAuditImplemented { get; }

		/// <summary />
		string CreatedBy { get; }
		/// <summary />
		DateTime? CreatedDate { get; }
		/// <summary />
		string ModifiedBy { get; }
		/// <summary />
		DateTime? ModifiedDate { get; }
		/// <summary />
		byte[] TimeStamp { get; }
	}
	#endregion

	#region CustomMetadata
	/// <summary />
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true)]
	public class CustomMetadata : System.Attribute
	{
		/// <summary />
		public string Key { get; set; }
		/// <summary />
		public string Value { get; set; }
	}
	#endregion

	#region EntityFieldMetadata
	/// <summary />
	[AttributeUsage(AttributeTargets.Property)]
	public partial class EntityFieldMetadata : System.Attribute
	{
		/// <summary />
		public EntityFieldMetadata(
			string name,
			int sortOrder,
			bool uiVisible,
			int maxLength,
			string mask,
			string friendlyName,
			string defaultValue,
			bool allowNull,
			string description,
			bool isComputed,
			bool isUnique,
			double min,
			double max,
			bool isPrimaryKey
		)
		{
			this.Name = name;
			this.SortOrder = sortOrder;
			this.UIVisible = uiVisible;
			this.MaxLength = maxLength;
			this.Mask = mask;
			this.FriendlyName = friendlyName;
			this.Default = defaultValue;
			this.AllowNull = allowNull;
			this.Description = description;
			this.IsComputed = isComputed;
			this.IsUnique = isUnique;
			this.Min = min;
			this.Max = max;
			this.IsPrimaryKey = isPrimaryKey;
		}

		/// <summary />
		public string Name { get; set; }
		/// <summary />
		public int SortOrder { get; set; }
		/// <summary />
		public bool UIVisible { get; set; }
		/// <summary />
		public int MaxLength { get; set; }
		/// <summary />
		public string Mask { get; set; }
		/// <summary />
		public string FriendlyName { get; set; }
		/// <summary />
		public object Default { get; set; }
		/// <summary />
		public bool AllowNull { get; set; }
		/// <summary />
		public string Description { get; set; }
		/// <summary />
		public bool IsComputed { get; set; }
		/// <summary />
		public bool IsUnique { get; set; }
		/// <summary />
		public double Min { get; set; }
		/// <summary />
		public double Max { get; set; }
		/// <summary />
		public bool IsPrimaryKey { get; set; }
	}
	#endregion

	#region EntityHistory
	/// <summary>
	/// Identities an entity class as having an audit history
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class EntityHistory : System.Attribute
	{
		/// <summary />
		public EntityHistory(System.Type auditType) { this.AuditType = auditType; }
		/// <summary />
		public System.Type AuditType { get; private set; }
	}
	#endregion

	#region EntityMetadata
	/// <summary />
	[AttributeUsage(AttributeTargets.Class)]
	public partial class EntityMetadata : System.Attribute
	{
		/// <summary />
		public EntityMetadata(
			string name,
			bool allowAuditTracking,
			bool allowCreateAudit,
			bool allowModifiedAudit,
			bool allowConcurrencyAudit,
			string description,
			bool enforcePrimaryKey,
			bool immutable,
			bool isTypeTable,
			string dbSchema
		)
		{
			this.Name = name;
			this.AllowAuditTracking = allowAuditTracking;
			this.AllowCreateAudit = allowCreateAudit;
			this.AllowModifiedAudit = allowModifiedAudit;
			this.AllowConcurrencyAudit = allowConcurrencyAudit;
			this.Description = description;
			this.EnforcePrimaryKey = enforcePrimaryKey;
			this.Immutable = immutable;
			this.IsTypeTable = isTypeTable;
			this.DBSchema = dbSchema;
		}

		/// <summary />
		public string Name { get; set; }
		/// <summary />
		public bool AllowAuditTracking { get; set; }
		/// <summary />
		public bool AllowCreateAudit { get; set; }
		/// <summary />
		public bool AllowModifiedAudit { get; set; }
		/// <summary />
		public bool AllowConcurrencyAudit { get; set; }
		/// <summary />
		public string Description { get; set; }
		/// <summary />
		public bool EnforcePrimaryKey { get; set; }
		/// <summary />
		public bool Immutable { get; set; }
		/// <summary />
		public bool IsTypeTable { get; set; }
		/// <summary />
		public string DBSchema { get; set; }
	}
	#endregion

	#region FieldNameConstantsAttribute
	/// <summary>
	/// Identities the type of IBusinessObject for an enumeration
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class FieldNameConstantsAttribute : System.Attribute
	{
		/// <summary />
		public FieldNameConstantsAttribute(System.Type targetType) { this.TargetType = targetType; }
		/// <summary />
		public System.Type TargetType { get; private set; }
	}
	#endregion

	#region PrimaryKeyAttribute
	/// <summary>
	/// Identities the primary key of an IBusinessObject enumeration
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class PrimaryKeyAttribute : System.Attribute
	{
	}
	#endregion

	#region IContextInclude
	/// <summary />
	public partial interface IContextInclude
	{
	}
	#endregion

	#region IContext
	/// <summary>
	/// The interface for a context object
	/// </summary>
	public partial interface IContext
	{
		/// <summary />
		string GetDBVersion(string connectionString = null);

		/// <summary />
		ContextStartup ContextStartup { get; }

		/// <summary>
		/// Gets the object context.
		/// </summary>
		System.Data.Entity.Core.Objects.ObjectContext ObjectContext { get; }

		/// <summary>
		/// A unique key for this object instance
		/// </summary>
		Guid InstanceKey { get; }

		/// <summary>
		/// Determines the key of the model that created this library.
		/// </summary>
		string ModelKey { get; }

		/// <summary>
		/// Determines the version of the model that created this library.
		/// </summary>
		string Version { get; }

		/// <summary>
		/// Determines if the API matches the database connection
		/// </summary>
		bool IsValidConnection();

		/// <summary>
		/// Determines if the API matches the database connection
		/// </summary>
		/// <param name="checkVersion">Determines if the check also includes the exact version of the model</param>
		bool IsValidConnection(bool checkVersion);

		/// <summary>
		/// Given a field enumeration value, returns an entity enumeration value designating the source entity of the field
		/// </summary>
		Enum GetEntityFromField(Enum field);

		/// <summary>
		/// Given an entity enumeration value, returns a metadata object for the entity
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		object GetMetaData(Enum entity);

		/// <summary>
		/// Given a field enumeration value, returns the system type of the associated property
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		System.Type GetFieldType(Enum field);
	}
	#endregion

	#region BaseEntity
	/// <summary>
	/// The base class for all entity objects using EF 6
	/// </summary>
	[Serializable]
	[System.Runtime.Serialization.DataContract(IsReference = true)]
	public abstract partial class BaseEntity
	{
		/// <summary />
		[field:NonSerialized]
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		/// <summary />
		[field:NonSerialized]
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

		/// <summary />
		protected virtual void OnPropertyChanging(System.ComponentModel.PropertyChangingEventArgs e)
		{
			if (this.PropertyChanging != null)
				this.PropertyChanging(this, e);
		}

		/// <summary />
		protected virtual void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, e);
		}
	}
	#endregion

	#region IBusinessObject
	/// <summary>
	/// The interface for all entities
	/// </summary>
	public partial interface IBusinessObject : Gravitybox.LocationService.EFDAL.IReadOnlyBusinessObject
	{
		/// <summary>
		/// Sets the value of a field
		/// </summary>
		/// <param name="field">The field to set</param>
		/// <param name="newValue">The new value to set</param>
		/// <returns></returns>
		void SetValue(Enum field, object newValue);

		/// <summary>
		/// Sets the value of a field
		/// </summary>
		/// <param name="field">The field to set</param>
		/// <param name="newValue">The new value to set</param>
		/// <param name="fixLength">Determines if the length should be truncated if too long. When false, an error will be raised if data is too large to be assigned to the field.</param>
		/// <returns></returns>
		void SetValue(Enum field, object newValue, bool fixLength);

	}
	#endregion

	#region QueryOptimizer
	/// <summary>
	/// This class can be used to optimize queries or report information about the operations
	/// </summary>
	public partial class QueryOptimizer
	{
		/// <summary>
		/// Determines if the query use select locks
		/// </summary>
		public bool NoLocking { get; set; }

		/// <summary>
		/// Determines the total time a query took to run
		/// </summary>
		public long TotalMilliseconds { get; set; }

		/// <summary>
		/// The maximum number of rows to affect with a query. 0 is no limit.
		/// </summary>
		public int ChunkSize { get; set; }

		/// <summary>
		/// Default constructor
		/// </summary>
		public QueryOptimizer()
		{
			this.NoLocking = false;
		}

		/// <summary>
		/// Initializes a new instance of this object using the specified NoLocking property
		/// </summary>
		/// <param name="noLocking">Determines if the query use select locks</param>
		public QueryOptimizer(bool noLocking)
			: this()
		{
			this.NoLocking = noLocking;
		}
	}
	#endregion

	#region BusinessEntityQuery
	/// <summary />
	internal class BusinessEntityQuery
	{
		/// <summary>
		/// Gets the DbCommand from the Dynamic Query but ensures that CAS Rules are taken to consideration
		/// </summary>
		/// <typeparam name="TEntity">The Type of Entity</typeparam>
		/// <param name="dataContext">Linq Data Context</param>
		/// <param name="template">Table </param>
		/// <param name="where">The Dynamic Linq</param>
		/// <returns></returns>
		public static DbCommand GetCommand<TEntity>(
				DataContext dataContext,
				Table<TEntity> template,
				Expression<Func<TEntity, bool>> where)
				where TEntity : class
		{
			//FileIOPermission permission = new FileIOPermission(PermissionState.Unrestricted);
			//permission.AllFiles = FileIOPermissionAccess.Write;
			//permission.Deny();

			return dataContext.GetCommand(template
					.Where(where)
					.Select(x => x));
		}

		/// <summary>
		/// Gets the DbCommand from the Dynamic Query but ensures that CAS Rules are taken to consideration
		/// </summary>
		/// <typeparam name="TEntity">The Type of Entity</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="dataContext">Linq Data Context</param>
		/// <param name="template">Table</param>
		/// <param name="select">The select criteria</param>
		/// <param name="where">The Dynamic Linq</param>
		/// <returns></returns>
		public static DbCommand GetCommand<TEntity, TResult>(
				DataContext dataContext,
				Table<TEntity> template,
				Expression<Func<TEntity, TResult>> select,
				Expression<Func<TEntity, bool>> where)
				where TEntity : class
		{
			//FileIOPermission permission = new FileIOPermission(PermissionState.Unrestricted);
			//permission.AllFiles = FileIOPermissionAccess.Write;
			//permission.Deny();

			return dataContext.GetCommand(template
					.Where(where)
					.Select(select));
		}
	}
	#endregion

	#region IPrimaryKey
	/// <summary />
	public partial interface IPrimaryKey
	{
		/// <summary />
		long Hash { get; }
	}

	/// <summary />
	public partial class PrimaryKey : IPrimaryKey
	{
		internal PrimaryKey(string key)
		{
			this.Hash = (long)Util.HashFast(key);
		}

		/// <summary />
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is PrimaryKey)) return false;
				return (((PrimaryKey)obj).Hash == this.Hash);
		}

		/// <summary />
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary />
		public static bool operator ==(PrimaryKey a, PrimaryKey b)
		{
			if (System.Object.ReferenceEquals(a, b))
			{
				return true;
			}
			// If one is null, but not both, return false.
			if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
			{
				return false;
			}

			return a.Hash == b.Hash;
		}

		/// <summary />
		public static bool operator !=(PrimaryKey a, PrimaryKey b)
		{
			return !(a == b);
		}

		/// <summary />
		public long Hash { get; private set; }
	}
	#endregion

	#region IReadOnlyBusinessObject
	/// <summary />
	public partial interface IReadOnlyBusinessObject
	{
		/// <summary>
		/// If applicable, returns the maximum number of characters the specified field can hold
		/// </summary>
		/// <param name="field"></param>
		/// <returns>If not applicable, the return value is 0</returns>
		int GetMaxLength(Enum field);

		/// <summary>
		/// Returns the primary key for this object
		/// </summary>
		IPrimaryKey PrimaryKey { get; }

		/// <summary />
		System.Type GetFieldNameConstants();

		/// <summary>
		/// Gets the value of a field specified by the enumeration
		/// </summary>
		/// <param name="field">The field from which to get the value</param>
		/// <returns></returns>
		object GetValue(Enum field);

		/// <summary>
		/// Gets the value of a field specified by the enumeration
		/// </summary>
		/// <param name="field">The field from which to get the value</param>
		/// <param name="defaultValue">The default value to return if the value is null</param>
		/// <returns></returns>
		object GetValue(Enum field, object defaultValue);

		/// <summary>
		/// Returns the system type of the specified field
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		System.Type GetFieldType(Enum field);
	}
	#endregion

	#region IBusinessObjectLINQQuery
	/// <summary />
	public partial interface IBusinessObjectLINQQuery
	{
	}
	#endregion

	#region AuditPaging
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T">An audit object</typeparam>
	public partial class AuditPaging<T>
	{
		/// <summary />
		public AuditPaging() { }
		/// <summary />
		public int PageOffset { get; set; }
		/// <summary />
		public int RecordsPerPage { get; set; }
		/// <summary />
		public IEnumerable<T> InnerList { get; set; }
		/// <summary />
		public int TotalRecordCount { get; set; }
	}
	#endregion

	#region AuditResult
	/// <summary>
	/// A result structure for audit records
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class AuditResult<T>
	{
		/// <summary />
		public AuditResult(T item1, T item2)
		{
			this.Item1 = item1;
			this.Item2 = item2;
		}

		/// <summary />
		public IEnumerable<IAuditResultFieldCompare> Differences { get; set; }
		/// <summary />
		public T Item1 { get; internal set; }
		/// <summary />
		public T Item2 { get; internal set; }
	}
	#endregion

	#region IAuditResultFieldCompare
		/// <summary />
	public interface IAuditResultFieldCompare
	{
		/// <summary />
		System.Enum Field { get; }
		/// <summary />
		object Value1 { get; }
		/// <summary />
		object Value2 { get; }
		/// <summary />
		System.Type DataType { get; }
	}
	#endregion

	#region AuditResultFieldCompare
	/// <summary />
	public class AuditResultFieldCompare<R, E> : IAuditResultFieldCompare
	{
		/// <summary />
		public AuditResultFieldCompare(R value1, R value2, E field, System.Type dataType)
		{
			this.Field = field;
			this.Value1 = value1;
			this.Value2 = value2;
			this.DataType = dataType;
		}

		/// <summary />
		public E Field { get; internal set; }
		/// <summary />
		public R Value1 { get; internal set; }
		/// <summary />
		public R Value2 { get; internal set; }

		/// <summary />
		public System.Type DataType { get; internal set; }

		#region IAuditResultFieldCompare

		System.Enum IAuditResultFieldCompare.Field
		{
			get { return (System.Enum)Enum.Parse(typeof(E), this.Field.ToString()); }
		}

		object IAuditResultFieldCompare.Value1
		{
			get { return this.Value1; }
		}

		object IAuditResultFieldCompare.Value2
		{
			get { return this.Value2; }
		}

		#endregion

	}
	#endregion

	#region QueryPreCache
	internal static class QueryPreCache
	{
		private static ConcurrentDictionary<Guid, List<PreCacheItem>> _queryDeleteCache = new ConcurrentDictionary<Guid, List<PreCacheItem>>();
		private static ConcurrentDictionary<Guid, List<PreCacheItem>> _queryUpdateCache = new ConcurrentDictionary<Guid, List<PreCacheItem>>();

		internal static void AddDelete(Guid instanceKey, string sql, List<System.Data.SqlClient.SqlParameter> parameters, QueryOptimizer optimizer)
		{
			try
			{
				var newItem = new PreCacheItem
				{
					SQL = sql,
					Parameters = parameters,
					Optimizer = optimizer,
				};

				if (!_queryDeleteCache.ContainsKey(instanceKey))
					_queryDeleteCache.TryAdd(instanceKey, new List<PreCacheItem>());
				_queryDeleteCache[instanceKey].Add(newItem);
			}
			catch
			{
				throw;
			}
		}

		internal static void AddUpdate(Guid instanceKey, string sql, List<System.Data.SqlClient.SqlParameter> parameters, QueryOptimizer optimizer)
		{
			try
			{
				var newItem = new PreCacheItem
				{
					SQL = sql,
					Parameters = parameters,
					Optimizer = optimizer,
				};

				if (!_queryUpdateCache.ContainsKey(instanceKey))
					_queryUpdateCache.TryAdd(instanceKey, new List<PreCacheItem>());
				_queryUpdateCache[instanceKey].Add(newItem);
			}
			catch
			{
				throw;
			}
		}

		internal static int ExecuteDeletes(IContext context)
		{
				if (!_queryDeleteCache.ContainsKey(context.InstanceKey))
					return 0;
				List<PreCacheItem> list;
				if (!_queryDeleteCache.TryRemove(context.InstanceKey, out list))
					return 0;
				var retval = Execute(context, list);
				RemoveDeletes(context.InstanceKey);
				return retval;
		}

		internal static int ExecuteUpdates(IContext context)
		{
				if (!_queryUpdateCache.ContainsKey(context.InstanceKey))
					return 0;
				List<PreCacheItem> list;
				if (!_queryUpdateCache.TryRemove(context.InstanceKey, out list))
					return 0;
				var retval = Execute(context, list);
				RemoveUpdates(context.InstanceKey);
				return retval;
		}

		private static int Execute(IContext context, List<PreCacheItem> list)
		{
			try
			{
				var count = 0;
				foreach (var cacheItem in list)
				{
					if (cacheItem.Optimizer == null) cacheItem.Optimizer = new QueryOptimizer();
					var affected = 0;
					var connection = (SqlConnection)(context.ObjectContext.Connection as EntityConnection).StoreConnection;
					{
						if (connection.State == System.Data.ConnectionState.Closed)
							connection.Open();

						using (var cmd = connection.CreateCommand())
						{
							if (!context.ContextStartup.DefaultTimeout && context.ContextStartup.CommandTimeout > 0) cmd.CommandTimeout = context.ContextStartup.CommandTimeout;
							else if (context.ObjectContext.CommandTimeout != null) cmd.CommandTimeout = context.ObjectContext.CommandTimeout.Value;
							cmd.CommandText = cacheItem.SQL;
							cmd.Transaction = FetchTransaction(connection);
							if (cacheItem.Parameters != null)
							{
								cmd.Parameters.AddRange(cacheItem.Parameters.ToArray());
							}
							do
							{
								count = (int)cmd.ExecuteNonQuery();
								affected += count;
							} while (count > 0 && cacheItem.Optimizer.ChunkSize > 0);
						}
					}
				}
				return count;
			}
			catch
			{
				throw;
			}
		}

		internal static void RemoveDeletes(Guid instanceKey)
		{
			try
			{
				List<PreCacheItem> v;
				_queryDeleteCache.TryRemove(instanceKey, out v);
			}
			catch
			{
				throw;
			}
		}

		internal static void RemoveUpdates(Guid instanceKey)
		{
			try
			{
				List<PreCacheItem> v;
				_queryUpdateCache.TryRemove(instanceKey, out v);
			}
			catch
			{
				throw;
			}
		}

		internal static void RemoveAll(Guid instanceKey)
		{
			try
			{
				RemoveDeletes(instanceKey);
				RemoveUpdates(instanceKey);
			}
			catch
			{
				throw;
			}
		}

		private static SqlTransaction FetchTransaction(SqlConnection conn)
		{
			try
			{
				Type sqlConnectionType = conn.GetType();
				object innerConnection = sqlConnectionType.GetProperty("InnerConnection", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(conn, null);
				var aa = innerConnection.GetType().GetProperty("AvailableInternalTransaction", BindingFlags.NonPublic | BindingFlags.Instance);
				if (aa == null) return null;
				var sqlInternalTransaction = aa.GetValue(innerConnection, null);
				if (sqlInternalTransaction == null) return null;
				SqlTransaction transaction = (SqlTransaction)sqlInternalTransaction.GetType().GetProperty("Parent", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(sqlInternalTransaction, null);
				return transaction;
			}
			catch
			{
				return null;
			}
		}
	}

	internal class PreCacheItem
	{
		public string SQL { get; set; }
		public List<System.Data.SqlClient.SqlParameter> Parameters { get; set; }
		public QueryOptimizer Optimizer { get; set; }
	}
	#endregion

}

namespace Gravitybox.LocationService.EFDAL.EventArguments
{
	#region ChangedEventArgs
	/// <summary>
	/// The event argument type of all property setters after the property is changed
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public partial class ChangedEventArgs<T> : System.ComponentModel.PropertyChangingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the ChangingEventArgs class
		/// </summary>
		/// <param name="newValue">The new value of the property being set</param>
		/// <param name="propertyName">The name of the property being set</param>
		public ChangedEventArgs(T newValue, string propertyName)
			: base(propertyName)
		{
			this.Value = newValue;
		}
		/// <summary>
		/// The new value of the property
		/// </summary>
		public T Value { get; set; }
	}
	#endregion

	#region ChangingEventArgs
	/// <summary>
	/// The event argument type of all property setters before the property is changed
	/// </summary>
	public partial class ChangingEventArgs<T> : ChangedEventArgs<T>
	{
		/// <summary>
		/// Initializes a new instance of the ChangingEventArgs class
		/// </summary>
		/// <param name="newValue">The new value of the property being set</param>
		/// <param name="propertyName">The name of the property being set</param>
		public ChangingEventArgs(T newValue, string propertyName)
			: base(newValue, propertyName)
		{
		}
		/// <summary>
		/// Determines if this operation is cancelled.
		/// </summary>
		public bool Cancel { get; set; }
	}
	/// <summary />
	public class EntityEventArgs : System.EventArgs
	{
		/// <summary />
		public IBusinessObject Entity { get; set; }
	}
	/// <summary />
	public class EntityListEventArgs : System.EventArgs
	{
		/// <summary />
		public IEnumerable<System.Data.Entity.Core.Objects.ObjectStateEntry> List { get; set; }
	}
}
	#endregion

namespace Gravitybox.LocationService.EFDAL.Exceptions
{
	#region ConcurrencyException
	/// <summary>
	/// Summary description for ConcurrencyException.
	/// </summary>
	[Serializable]
	public partial class ConcurrencyException : nHydrateException
	{
		/// <summary />
		public ConcurrencyException(string message)
			: base(message)
		{
		}

		/// <summary />
		public ConcurrencyException(string message, System.Exception ex)
			: base(message, ex)
		{
		}
	}
	#endregion

	#region nHydrateException
	/// <summary />
	[Serializable]
	public partial class nHydrateException : System.Exception
	{
		/// <summary />
		public string ErrorCode = null;
		/// <summary />
		public string []Arguments = null;

		/// <summary />
		public nHydrateException (): base ()
		{
		}

		/// <summary />
		public nHydrateException ( string Message ) : base ( Message )
		{
		}
		
		/// <summary />
		public nHydrateException ( string Message, System.Exception InnerException ) : base ( Message, InnerException )
		{
		}

		/// <summary />
		public nHydrateException ( string ErrorCode, string Message ) : base ( Message )
		{
			this.ErrorCode = ErrorCode;
		}

		/// <summary />
		public nHydrateException ( string ErrorCode, params object [] Arguments )
		{
			this.ErrorCode = ErrorCode;
			//this.arguments = arguments;

			this.Arguments = new string [Arguments.Length];

			for ( var length = 0; length < Arguments.Length; ++ length )
			{
				this.Arguments[length] = (string)Arguments [length];
			}
		}

		/// <summary />
		public nHydrateException ( string ErrorCode, string Message, System.Exception InnerException ) : base ( Message, InnerException )
		{
			this.ErrorCode = ErrorCode;
		}

		/// <summary />
		public nHydrateException ( SerializationInfo SerializationInfo, StreamingContext Context ) : base ( SerializationInfo, Context )
		{
			this.ErrorCode = ( string ) SerializationInfo.GetValue ( "errorCode", typeof ( string ) );
		}

		///// <summary />
		//public override void GetObjectData ( SerializationInfo SerializationInfo, StreamingContext Context )
		//{
		//  SerializationInfo.AddValue ( "errorCode", ErrorCode );
		//  base.GetObjectData ( SerializationInfo, Context ) ;
		//}
	}
	#endregion

	#region UniqueConstraintViolatedException
	/// <summary>
	/// Summary description for UniqueConstraintViolatedException.
	/// </summary>
	[Serializable]
	public partial class UniqueConstraintViolatedException : nHydrateException
	{
		/// <summary />
		public UniqueConstraintViolatedException(string message)
			: base(message)
		{
		}
		/// <summary />
		public UniqueConstraintViolatedException(string message, System.Exception ex)
			: base(message, ex)
		{
		}
	}
	#endregion

}
